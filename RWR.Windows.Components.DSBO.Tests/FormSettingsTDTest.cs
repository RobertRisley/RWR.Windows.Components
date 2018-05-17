using RWR.Windows.Components.DSBO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Data;

namespace RWR.Windows.Components.DSBO.Tests
{
    
    
    /// <summary>
    ///This is a test class for FormSettingsTDTest and is intended
    ///to contain all FormSettingsTDTest Unit Tests
    ///</summary>
	[TestClass()]
	public class FormSettingsTDTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for Tables
		///</summary>
		[TestMethod()]
		public void TablesTest()
		{
			FormSettingsTD target = new FormSettingsTD(); // TODO: Initialize to an appropriate value
			DataTableCollection actual;
			actual = target.Tables;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for FormSettings
		///</summary>
		[TestMethod()]
		public void FormSettingsTest()
		{
			FormSettingsTD target = new FormSettingsTD(); // TODO: Initialize to an appropriate value
			FormSettingsTD.FormSettingsDataTable actual;
			actual = target.FormSettings;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateFormSettings
		///</summary>
		[TestMethod()]
		public void UpdateFormSettingsTest()
		{
			DataSet formSettingsDataSet = null; // TODO: Initialize to an appropriate value
			DataSet expected = null; // TODO: Initialize to an appropriate value
			DataSet actual;
			actual = FormSettingsTD.UpdateFormSettings(formSettingsDataSet);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsExistingFormSettings
		///</summary>
		[TestMethod()]
		public void IsExistingFormSettingsTest()
		{
			string userName = string.Empty; // TODO: Initialize to an appropriate value
			string formName = string.Empty; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = FormSettingsTD.IsExistingFormSetting(userName, formName);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetFormSettings
		///</summary>
		[TestMethod()]
		public void GetFormSettingsTest()
		{
			DataSet expected = null; // TODO: Initialize to an appropriate value
			DataSet actual;
			actual = FormSettingsTD.GetFormSettings();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetFormSetting
		///</summary>
		[TestMethod()]
		public void GetFormSettingTest()
		{
			string userName = string.Empty; // TODO: Initialize to an appropriate value
			string formName = string.Empty; // TODO: Initialize to an appropriate value
			DataTable expected = null; // TODO: Initialize to an appropriate value
			DataTable actual;
			actual = FormSettingsTD.GetFormSetting(userName, formName);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for CheckTableRow
		///</summary>
		[TestMethod()]
		public void CheckTableRowTest()
		{
			DataRow row = null; // TODO: Initialize to an appropriate value
			DataColumnCollection cols = null; // TODO: Initialize to an appropriate value
			FormSettingsTD.CheckTableRow(row, cols);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for CheckGridColumn
		///</summary>
		[TestMethod()]
		public void CheckGridColumnTest()
		{
			object sender = null; // TODO: Initialize to an appropriate value
			DataGridViewCellValidatingEventArgs e = null; // TODO: Initialize to an appropriate value
			FormSettingsTD.CheckGridColumn(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}
	}
}
