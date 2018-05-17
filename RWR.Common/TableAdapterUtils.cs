using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace RWR.Common
{
	/// <summary>
	/// Common TableAdapter Utilities (static).
	/// </summary>
	public class TableAdapterUtils
	{
		/// <summary>
		/// Allows a TableAdapter to use an existing SqlTransaction (SQL2000 compatibility).
		/// Use in conjunction with SqlUtils (CommitTransaction or RollbackTransaction).
		/// </summary>
		/// <param name="tableAdapter">the TableAdapter.</param>
		/// <param name="sqlTransaction">the SqlTransaction the TableAdapter is to use.</param>
		public static void UseTransaction(object tableAdapter, ref SqlTransaction sqlTransaction)
		{
			var type = tableAdapter.GetType();
			var connectionProperty = type.GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);

			if (sqlTransaction == null)
			{
				var sqlConnection = (SqlConnection)connectionProperty.GetValue(tableAdapter, null);
				if (sqlConnection.State == ConnectionState.Closed)
					sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction();
			}

			var sqlDataAdapter = (SqlDataAdapter)type.GetProperty("Adapter", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(tableAdapter, null);

			if (sqlDataAdapter.InsertCommand != null)
			{
				sqlDataAdapter.InsertCommand.Connection = sqlTransaction.Connection;
				sqlDataAdapter.InsertCommand.Transaction = sqlTransaction;
			}
			if (sqlDataAdapter.UpdateCommand != null)
			{
				sqlDataAdapter.UpdateCommand.Connection = sqlTransaction.Connection;
				sqlDataAdapter.UpdateCommand.Transaction = sqlTransaction;
			}
			if (sqlDataAdapter.DeleteCommand != null)
			{
				sqlDataAdapter.DeleteCommand.Connection = sqlTransaction.Connection;
				sqlDataAdapter.DeleteCommand.Transaction = sqlTransaction;
			}

			var commandsProperty = type.GetProperty("CommandCollection", BindingFlags.NonPublic | BindingFlags.Instance);

			var sqlCommands = (SqlCommand[])commandsProperty.GetValue(tableAdapter, null);

			foreach (SqlCommand sqlCommand in sqlCommands)
			{
				sqlCommand.Connection = sqlTransaction.Connection;
				sqlCommand.Transaction = sqlTransaction;
			}
		}
	}
}
