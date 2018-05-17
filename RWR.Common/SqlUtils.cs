using System.Data;
using System.Data.SqlClient;

namespace RWR.Common
{
	/// <summary>
	/// Common SQL Utilities (static).
	/// </summary>
	public class SqlUtils
	{
		/// <summary>
		/// Commits a SqlTransaction if it exists, and closes the connection to the database.
		/// (SQL2000 compatibility)
		/// </summary>
		/// <param name="sqlTransaction">The transaction to perform the Commit with.</param>
		public static void CommitTransaction(SqlTransaction sqlTransaction)
		{
			if (sqlTransaction == null) return;

			var sqlConnection = sqlTransaction.Connection;
			sqlTransaction.Commit();
			if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
				sqlConnection.Close();
			sqlTransaction.Dispose();
		}

		/// <summary>
		/// Rolls back a SqlTransaction if it exists, and closes the connection to the database.
		/// (SQL2000 compatibility)
		/// </summary>
		/// <param name="sqlTransaction">The transaction to Rollback.</param>
		public static void RollbackTransaction(SqlTransaction sqlTransaction)
		{
			if (sqlTransaction == null) return;

			var sqlConnection = sqlTransaction.Connection;
			sqlTransaction.Rollback();
			if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
				sqlConnection.Close();
			sqlTransaction.Dispose();
		}
	}
}
