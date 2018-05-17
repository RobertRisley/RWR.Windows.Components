using System.Data;
using System.Windows.Forms;

namespace RWR.Common
{
	#region AsyncDataSetCompleted
	/// <summary>
	/// Provides data and a DataSet for the MethodNameCompleted event.
	/// </summary>
	public class AsyncDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{
		private readonly object[] results;

		/// <summary>
		/// Provides data for the MethodNameCompleted event.
		/// </summary>
		/// <param name="results">An Object array that contains the results. [0] contains the DataSet.</param>
		/// <param name="exception">Any error that occurred during the asynchronous operation.</param>
		/// <param name="cancelled">A value indicating whether the asynchronous operation was cancelled.</param>
		/// <param name="userState">The optional user-supplied state object passed to the System.ComponentModel.BackgroundWorker.RunWorkerAsync(System.Object) method.</param>
		public AsyncDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
			: base(exception, cancelled, userState)
		{
			this.results = results;
		}
		/// <summary>
		/// The Result DataSet.
		/// </summary>
		public DataSet Result
		{
			get { return ((DataSet)(results[0])); }
		}
	}
	/// <summary>
	/// Delegate for Async DataSet events.
	/// </summary>
	/// <param name="sender">sender</param>
	/// <param name="e">event args</param>
	public delegate void AsyncDataSetCompletedEventHandler(object sender, AsyncDataSetCompletedEventArgs e);
	#endregion

	#region FilterApply
	/// <summary>
	/// Delegate for FilterApply events.
	/// </summary>
	public delegate void FilterApplyEventHandler();
	#endregion

	#region GridDoubleClick
	/// <summary>
	/// The EventArgs for the GridDoubleClick event.
	/// </summary>
	public class GridDoubleClickEventArgs
	{
		/// <summary>
		/// The DataRow object.
		/// </summary>
		public DataRow Row;

		/// <summary>
		/// Provides data for the GridViewDoubleClick event.
		/// </summary>
		public GridDoubleClickEventArgs() { }

		/// <summary>
		/// Provides data for the GridViewDoubleClick event.
		/// </summary>
		/// <param name="row"></param>
		public GridDoubleClickEventArgs(DataRow row) { Row = row; }
	}

	/// <summary>
	/// Delegate for GridViewDoubleClick events.
	/// </summary>
	/// <param name="sender">sender</param>
	/// <param name="e">event args</param>
	public delegate void GridDoubleClickEventHandler(object sender, GridDoubleClickEventArgs e);
	#endregion

	#region RetrieveData
	/// <summary>
	/// Delegate for RetrieveData events.
	/// </summary>
	public delegate void RetrieveDataEventHandler();
	#endregion

	#region TreeViewDoubleClick
	/// <summary>
	/// The EventArgs for the TreeViewDoubleClick event.
	/// </summary>
	public class TreeViewDoubleClickEventArgs : System.EventArgs
	{
		/// <summary>
		/// The selected TreeNode object.
		/// </summary>
		public TreeNode SelectedNode;

		/// <summary>
		/// Provides data for the TreeViewDoubleClick event.
		/// </summary>
		/// <param name="selectedNode"></param>
		public TreeViewDoubleClickEventArgs(TreeNode selectedNode) { SelectedNode = selectedNode; }
	}

	/// <summary>
	/// Delegate for TreeViewDoubleClick events.
	/// </summary>
	/// <param name="sender">sender</param>
	/// <param name="e">event args</param>
	public delegate void TreeViewDoubleClickEventHandler(object sender, TreeViewDoubleClickEventArgs e);
	#endregion
}
