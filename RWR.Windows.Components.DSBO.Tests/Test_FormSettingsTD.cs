using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RWR.Windows.Components.DSBO.Tests
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class Test_FormSettingsTD
	{
		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		#region Initialize/cleanup
		// Use ClassInitialize to run code before running the first test in the class
		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		[ClassCleanup]
		public static void ClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		[TestInitialize]
		public void TestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		[TestCleanup]
		public void TestCleanup() { }
		#endregion

		#region Constants
		protected const string USER_NAME = "FormSettingsTD_User";
		protected const string FORM_NAME = "FormSettingsTD_Form";
		protected const string FORM_SETTINGS_XML = @"<FormSettingsCD xmlns=""http://www.RobertRisley.com/FormSettingsCD.xsd"">
  <FormSettingsKeyValuePairs>
    <Key>AltColor1</Key>
    <Value>DarkSeaGreen</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>WindowState</Key>
    <Value>Normal</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>Height</Key>
    <Value>789</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>Width</Key>
    <Value>1046</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>X</Key>
    <Value>260</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>Y</Key>
    <Value>379</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>FilterDS</Key>
    <Value>&lt;FilterDS&gt;
  &lt;GridFilters&gt;
    &lt;cboGroup&gt;1&lt;/cboGroup&gt;
    &lt;cboLogic /&gt;
    &lt;cboColumn&gt;Status&lt;/cboColumn&gt;
    &lt;cboOperator&gt;Equals&lt;/cboOperator&gt;
    &lt;txtValue&gt;new&lt;/txtValue&gt;
    &lt;txtMapping&gt;Status&lt;/txtMapping&gt;
  &lt;/GridFilters&gt;
&lt;/FilterDS&gt;</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>SortCol1</Key>
    <Value>Assigned To</Value>
  </FormSettingsKeyValuePairs>
  <FormSettingsKeyValuePairs>
    <Key>SortSrt1</Key>
    <Value>ASC</Value>
  </FormSettingsKeyValuePairs>";
		#endregion

		protected static FormSettingsTD.FormSettingsDataTable _formSettingTable = new FormSettingsTD.FormSettingsDataTable();
		protected static FormSettingsTD.FormSettingsRow _formSettingRow;

		#region IsExistingFormSetting
		private static bool IsExistingFormSetting(string userName, string formName, bool validateResponse)
		{
			try
			{
				bool isExisting = FormSettingsTD.IsExistingFormSettings(userName, formName);
				if (validateResponse)
				{
					Assert.AreEqual(true, isExisting, "FormSetting expected to exist.");
				}
				return isExisting;
			}
			catch
			{
				if (validateResponse)
					throw;
				return false;
			}
		}
		/// <remarks/>
		[TestMethod]
		public void IsExistingFormSetting()
		{
			try
			{
				IsExistingFormSetting(USER_NAME, FORM_NAME, true);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void IsExistingFormSetting_InvalidUserName()
		{
			try
			{
				bool isExisting = IsExistingFormSetting("BAD_USER", FORM_NAME, false);
				Assert.AreEqual(false, isExisting, "BAD_USER should not exist.");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void IsExistingFormSetting_InvalidFormName()
		{
			try
			{
				bool isExisting = IsExistingFormSetting(USER_NAME, "BAD_FORM", false);
				Assert.AreEqual(false, isExisting, "BAD_FORM should not exist.");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		#endregion

		#region GetFormSetting
		private static void GetFormSetting(string userName, string formName, bool validateResponse)
		{
			try
			{
				_formSettingTable.Clear();
				_formSettingTable.Merge(FormSettingsTD.GetFormSetting(userName, formName), false);

				if (_formSettingTable.Rows.Count > 0)
					_formSettingRow = (FormSettingsTD.FormSettingsRow)_formSettingTable.Rows[0];
				else
					_formSettingRow = null;

				if (validateResponse)
				{
					Assert.AreNotEqual(null, _formSettingTable);
					Assert.AreEqual(1, _formSettingTable.Rows.Count);
					if (_formSettingRow != null)
					{
						Assert.AreEqual(userName, _formSettingRow.UserName);
						Assert.AreEqual(formName, _formSettingRow.FormName);
					}
				}
			}
			catch
			{
				if (validateResponse)
					throw;
			}
		}
		/// <remarks/>
		[TestMethod]
		public void GetFormSetting()
		{
			try
			{
				if (!IsExistingFormSetting(USER_NAME, FORM_NAME, false))
					Insert_UpdateFormSettings(USER_NAME, FORM_NAME, FORM_SETTINGS_XML, true); // do insert(validated)

				GetFormSetting(USER_NAME, FORM_NAME, true); // do get(validated)
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void GetFormSetting_InvalidUserName()
		{
			try
			{
				GetFormSetting("BAD_USER", FORM_NAME, false);
				Assert.AreEqual(0, _formSettingTable.Rows.Count, "BAD_USER should not exist.");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void GetFormSetting_InvalidFormName()
		{
			try
			{
				GetFormSetting(USER_NAME, "BAD_FORM", false);
				Assert.AreEqual(0, _formSettingTable.Rows.Count, "BAD_FORM should not exist.");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		#endregion

		#region Delete_UpdateFormSettings
		private static void Delete_UpdateFormSettings(bool validateResponse)
		{
			try
			{
				if (_formSettingTable.Rows.Count > 0)
				{
					_formSettingRow.Delete();

					var delete = new FormSettingsTD();
					delete.Merge(_formSettingTable);
					FormSettingsTD.UpdateFormSettings(delete);
					_formSettingTable.AcceptChanges();
				}
			}
			catch
			{
				if (validateResponse)
					throw;
			}
		}
		/// <remarks/>
		[TestMethod]
		public void Delete_UpdateFormSettings()
		{
			if (IsExistingFormSetting(USER_NAME, FORM_NAME, false))
			{
				GetFormSetting(USER_NAME, FORM_NAME, false); // try get
				Delete_UpdateFormSettings(false); // try delete
			}
			Insert_UpdateFormSettings(USER_NAME, FORM_NAME, FORM_SETTINGS_XML, true); // do insert(validated)
			GetFormSetting(USER_NAME, FORM_NAME, true); // do get(validated)

			Delete_UpdateFormSettings(true); // do delete(validated)
			Assert.AreEqual(false, IsExistingFormSetting(USER_NAME, FORM_NAME, false)); // should not exist
		}
		#endregion

		#region Insert_UpdateFormSettings
		private static void Insert_UpdateFormSettings(string userName, string formName, string formSettingsXml, bool validateResponse)
		{
			try
			{
				_formSettingRow = _formSettingTable.NewFormSettingsRow();
				_formSettingRow.UserName = userName;
				_formSettingRow.FormName = formName;
				_formSettingRow.FormSettingsXml = formSettingsXml;
				_formSettingTable.Rows.Add(_formSettingRow);
				var insert = new FormSettingsTD();
				insert.Merge(_formSettingTable);
				FormSettingsTD.UpdateFormSettings(insert);
				_formSettingTable.AcceptChanges();
			}
			catch
			{
				if (validateResponse)
					throw;
			}
		}
		/// <remarks/>
		[TestMethod]
		public void Insert_UpdateFormSettings()
		{
			if (IsExistingFormSetting(USER_NAME, FORM_NAME, false))
			{
				GetFormSetting(USER_NAME, FORM_NAME, false); // try get
				Delete_UpdateFormSettings(false); // try delete
			}

			Insert_UpdateFormSettings(USER_NAME, FORM_NAME, FORM_SETTINGS_XML, true); // do insert(validated)
			IsExistingFormSetting(USER_NAME, FORM_NAME, true); // do existence(validated)
		}
		#endregion

		#region Update_UpdateFormSettings
		/// <remarks/>
		[TestMethod]
		public void Update_UpdateFormSettings()
		{
			try
			{
				if (_formSettingTable.Rows.Count == 0)
					GetFormSetting();

				//DateTime dueDate = DateUtils.SqlUtcNow;
				//_formSettingRow.DueDt = dueDate;

				var formSettingsDataSet = new FormSettingsTD();
				formSettingsDataSet.Merge(_formSettingTable);

				GetFormSetting();
				//Assert.AreEqual(dueDate, _formSettingRow.DueDt);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		#endregion

		#region UpdateFormSettings
		/// <remarks/>
		[TestMethod]
		public void UpdateFormSettings_NullDataSet()
		{
			try
			{
				FormSettingsTD.UpdateFormSettings(null);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
		}

		/// <remarks/>
		[TestMethod]
		public void UpdateFormSettings_NullDataTable()
		{
			try
			{
				var formSettingsDataSet = new DataSet();
				FormSettingsTD.UpdateFormSettings(formSettingsDataSet);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
		}

		/// <remarks/>
		[TestMethod]
		public void UpdateFormSettings_EmptyDataTable()
		{
			try
			{
				var formSettingsDataSet = new FormSettingsTD();
				FormSettingsTD.UpdateFormSettings(formSettingsDataSet);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
		}
		#endregion
	}
}
