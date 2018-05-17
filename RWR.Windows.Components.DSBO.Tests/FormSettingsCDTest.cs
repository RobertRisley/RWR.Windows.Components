using RWR.Windows.Components.DSBO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using RWR.Windows.Components.DSBO.SettingsServiceASMX;
using System.Data;
using System.Xml.Schema;
using System.Xml;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RWR.Windows.Components.DSBO.Tests
{
    
    
    /// <summary>
    ///This is a test class for FormSettingsCDTest and is intended
    ///to contain all FormSettingsCDTest Unit Tests
    ///</summary>
	[TestClass()]
	public class FormSettingsCDTest
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
		///A test for WindowState
		///</summary>
		[TestMethod()]
		public void WindowStateTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			FormWindowState actual;
			actual = target.WindowState;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Width
		///</summary>
		[TestMethod()]
		public void WidthTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			int actual;
			actual = target.Width;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Tables
		///</summary>
		[TestMethod()]
		public void TablesTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			DataTableCollection actual;
			actual = target.Tables;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Settings
		///</summary>
		[TestMethod()]
		public void SettingsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			FormSettingsCD.SettingsDataTable actual;
			actual = target.Settings;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SchemaSerializationMode
		///</summary>
		[TestMethod()]
		public void SchemaSerializationModeTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			SchemaSerializationMode expected = new SchemaSerializationMode(); // TODO: Initialize to an appropriate value
			SchemaSerializationMode actual;
			target.SchemaSerializationMode = expected;
			actual = target.SchemaSerializationMode;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Relations
		///</summary>
		[TestMethod()]
		public void RelationsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			DataRelationCollection actual;
			actual = target.Relations;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Location
		///</summary>
		[TestMethod()]
		public void LocationTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			Point actual;
			actual = target.Location;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Height
		///</summary>
		[TestMethod()]
		public void HeightTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			int actual;
			actual = target.Height;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for FormSettings
		///</summary>
		[TestMethod()]
		public void FormSettingsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			FormSettingsCD.FormSettingsDataTable actual;
			actual = target.FormSettings;
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for wcf_ClientUpdateFormSettingsCompleted
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void wcf_ClientUpdateFormSettingsCompletedTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			IAsyncResult ar = null; // TODO: Initialize to an appropriate value
			target.wcf_ClientUpdateFormSettingsCompleted(ar);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for wcf_ClientGetFormSettingsCompleted
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void wcf_ClientGetFormSettingsCompletedTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			IAsyncResult ar = null; // TODO: Initialize to an appropriate value
			target.wcf_ClientGetFormSettingsCompleted(ar);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for UpdateFormSettings
		///</summary>
		[TestMethod()]
		public void UpdateFormSettingsTest()
		{
			FormSettingsCD cd = null; // TODO: Initialize to an appropriate value
			FormSettingsCD expected = null; // TODO: Initialize to an appropriate value
			FormSettingsCD actual;
			actual = FormSettingsCD.UpdateFormSettings(cd);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ShouldSerializeTables
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void ShouldSerializeTablesTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ShouldSerializeTables();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ShouldSerializeSettings
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void ShouldSerializeSettingsTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ShouldSerializeSettings();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ShouldSerializeRelations
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void ShouldSerializeRelationsTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ShouldSerializeRelations();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ShouldSerializeFormSettings
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void ShouldSerializeFormSettingsTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ShouldSerializeFormSettings();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SetValue
		///</summary>
		[TestMethod()]
		public void SetValueTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			string key = string.Empty; // TODO: Initialize to an appropriate value
			string value = string.Empty; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.SetValue(key, value);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SchemaChanged
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void SchemaChangedTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			object sender = null; // TODO: Initialize to an appropriate value
			CollectionChangeEventArgs e = null; // TODO: Initialize to an appropriate value
			target.SchemaChanged(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ReadXmlSerializable
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void ReadXmlSerializableTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			XmlReader reader = null; // TODO: Initialize to an appropriate value
			target.ReadXmlSerializable(reader);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for PrepareDataBeforeUpdate
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void PrepareDataBeforeUpdateTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.PrepareDataBeforeUpdate();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for PrepareDataAfterUpdate
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void PrepareDataAfterUpdateTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.PrepareDataAfterUpdate();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for PrepareDataAfterGet
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void PrepareDataAfterGetTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.PrepareDataAfterGet();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for InitVars
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void InitVarsTest1()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			bool initTable = false; // TODO: Initialize to an appropriate value
			target.InitVars(initTable);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for InitVars
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void InitVarsTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.InitVars();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for InitializeDerivedDataSet
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void InitializeDerivedDataSetTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.InitializeDerivedDataSet();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for InitClass
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void InitClassTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			target.InitClass();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetValue
		///</summary>
		[TestMethod()]
		public void GetValueTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			string key = string.Empty; // TODO: Initialize to an appropriate value
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			actual = target.GetValue(key);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetTypedDataSetSchema
		///</summary>
		[TestMethod()]
		public void GetTypedDataSetSchemaTest()
		{
			XmlSchemaSet xs = null; // TODO: Initialize to an appropriate value
			XmlSchemaComplexType expected = null; // TODO: Initialize to an appropriate value
			XmlSchemaComplexType actual;
			actual = FormSettingsCD.GetTypedDataSetSchema(xs);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetSchemaSerializable
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void GetSchemaSerializableTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			XmlSchema expected = null; // TODO: Initialize to an appropriate value
			XmlSchema actual;
			actual = target.GetSchemaSerializable();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetFormSettings
		///</summary>
		[TestMethod()]
		public void GetFormSettingsTest()
		{
			string userName = string.Empty; // TODO: Initialize to an appropriate value
			string formName = string.Empty; // TODO: Initialize to an appropriate value
			FormSettingsCD expected = null; // TODO: Initialize to an appropriate value
			FormSettingsCD actual;
			actual = FormSettingsCD.GetFormSettings(userName, formName);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Clone
		///</summary>
		[TestMethod()]
		public void CloneTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			DataSet expected = null; // TODO: Initialize to an appropriate value
			DataSet actual;
			actual = target.Clone();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ClientUpdateFormSettings
		///</summary>
		[TestMethod()]
		public void ClientUpdateFormSettingsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			bool async = false; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ClientUpdateFormSettings(async);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ClientSetCaptions
		///</summary>
		[TestMethod()]
		public void ClientSetCaptionsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			target.ClientSetCaptions();
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ClientGetFormSettings
		///</summary>
		[TestMethod()]
		public void ClientGetFormSettingsTest()
		{
			FormSettingsCD target = new FormSettingsCD(); // TODO: Initialize to an appropriate value
			string userName = string.Empty; // TODO: Initialize to an appropriate value
			string formName = string.Empty; // TODO: Initialize to an appropriate value
			bool async = false; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.ClientGetFormSettings(userName, formName, async);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for asmx_ClientUpdateFormSettingsCompleted
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void asmx_ClientUpdateFormSettingsCompletedTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			object sender = null; // TODO: Initialize to an appropriate value
			UpdateFormSettingsCompletedEventArgs e = null; // TODO: Initialize to an appropriate value
			target.asmx_ClientUpdateFormSettingsCompleted(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for asmx_ClientGetFormSettingsCompleted
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void asmx_ClientGetFormSettingsCompletedTest()
		{
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(); // TODO: Initialize to an appropriate value
			object sender = null; // TODO: Initialize to an appropriate value
			GetFormSettingsCompletedEventArgs e = null; // TODO: Initialize to an appropriate value
			target.asmx_ClientGetFormSettingsCompleted(sender, e);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for FormSettingsCD Constructor
		///</summary>
		[TestMethod()]
		public void FormSettingsCDConstructorTest1()
		{
			FormSettingsCD target = new FormSettingsCD();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for FormSettingsCD Constructor
		///</summary>
		[TestMethod()]
		[DeploymentItem("RWR.Windows.Components.DSBO.dll")]
		public void FormSettingsCDConstructorTest()
		{
			SerializationInfo info = null; // TODO: Initialize to an appropriate value
			StreamingContext context = new StreamingContext(); // TODO: Initialize to an appropriate value
			FormSettingsCD_Accessor target = new FormSettingsCD_Accessor(info, context);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}
	}
}
