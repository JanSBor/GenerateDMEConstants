using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using SQLite;

namespace GenerateDMEConstants
{
    public partial class Main : Form
    {


        List<Settings> lSettings = new List<Settings>();
        int iSelectedItemNo = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DoSettingsLoad();
        }


        private void cExtensionFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Find what File name has been selected
            ComboBox cExtensionFileName = (ComboBox)sender;

            // the Extension file's name from the list. 
            string selectedExtensionFileName = (string)cExtensionFileName.SelectedItem;

            FillControls(selectedExtensionFileName);

            iSelectedItemNo = cExtensionFileName.SelectedIndex;


        }

        private void SelectExtFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ExtensionFileDlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = ExtensionFileDlg.FileName;
                
                //TODO: Should check if extension file already exists in the list

                //Add new item to combobox
                cExtensionFileName.Items.Add(file);
                iSelectedItemNo = cExtensionFileName.Items.Count - 1;

                cExtensionFileName.SelectedIndex = iSelectedItemNo;

                //Add new item to list
                 lSettings.Add(new Settings()
                        {
                            ExtensionFile = file,
                            //Language = rSettings.Language,
                            //StructureType = rSettings.StructureType,
                            //OutputFile = rSettings.OutputFile,
                            //NamespaceString = rSettings.NamespaceString
                        }
                   );

            }
            else
            {
                //TODO: Add errorhandling
            }
        }

        private void SelectOutputFile_Click(object sender, EventArgs e)
        {
            DialogResult result = OutputFileDlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = OutputFileDlg.FileName;

                tOutputFileName.Text = file;
            }
            else
            {
                //TODO: Add errorhandling
            }
        }

        private void GenerateFile_Click(object sender, EventArgs e)
        {
            string extensionfilename = cExtensionFileName.Text;//TODO: Check that it actually has a content
            int language=0;
            if (LanguageCSharp.Checked)
            {
            language = 1;
            }
            else if (LanguageVB.Checked)
            {
                language = 2;
            }
            int structuretype=0;
            if (TypeClass.Checked)
            {
                structuretype = 1;
            }
            else if (TypeClass.Checked)
            {
                structuretype = 2;
            }
            string soutputfilename = tOutputFileName.Text; //TODO: Check that it actually has a content
            string snamespace = tNamespace.Text; //TODO: Check that it actually has a content
            
            //Start by saving the settings
            if (SaveSettings.Checked)
            {
                DoSettingsSave(extensionfilename, language, structuretype, soutputfilename, snamespace);
            }

           
            
            StreamWriter swOutputFile = new StreamWriter(soutputfilename);

            //Read Extension file
            XmlDocument xd = new XmlDocument();
            xd.Load(extensionfilename); //TODO: Errorhandling!

            //Get the name of the Extension
            string ExtensionName = GetExtensionName(xd);

            //Put tables into one list, and columns into another
            List<TableList> lTables = CreateTableList(xd);

            List<ColumnList> lColumns = CreateColumnList(xd);


            //Write class file
            if (LanguageCSharp.Checked)
            {
                //TODO: Check on file type
                CsharpFile c = new CsharpFile(soutputfilename, snamespace, swOutputFile);
                c.AddClassContent(swOutputFile, ExtensionName, lTables, lColumns);


            }
            else if(LanguageVB.Checked)
            {
                //TODO: Add VB Code generator. 

            }
            else
            {
                //TODO: Add errorhandling
            }

            
        }

        private string GetExtensionName(XmlDocument xdExtension)
        {
            string ExtensionName = "";
            XmlNodeList nodes = xdExtension.DocumentElement.SelectNodes("/ModelContribution/Contribution");
            XmlNode node = nodes[0]; //Should only be one element
            ExtensionName = node.Attributes["Name"].InnerText; //TODO: Check that not empty

            return ExtensionName;
        }

        private List<TableList> CreateTableList(XmlDocument xdExtension)
        {
            List<TableList> lTables = new List<TableList>();

            XmlNodeList nodes = xdExtension.DocumentElement.SelectNodes("/ModelContribution/Tables/Table");

            foreach (XmlNode node in nodes)
            {
                //TODO: Add more errorhandling in this method. 
                TableList OneTable = new TableList();

                OneTable.identifier = node.Attributes["Identifier"].InnerText;

                long lTableNo;
                string sTableNo = node.Attributes["TableNo"].InnerText;
                if (Int64.TryParse(sTableNo, out lTableNo))
                {
                    OneTable.tableno = lTableNo;
                }

                lTables.Add(OneTable);

            }

            return lTables;
        }

        private List<ColumnList> CreateColumnList(XmlDocument xdExtension)
        {
            List<ColumnList> lColumns = new List<ColumnList>();

            XmlNodeList nodes = xdExtension.DocumentElement.SelectNodes("/ModelContribution/Columns/Column");

            foreach (XmlNode node in nodes)
            {
                //TODO: Add more errorhandling in this method. 
                ColumnList OneColumn = new ColumnList();

                OneColumn.identifier = node.Attributes["Identifier"].InnerText;

                long lColumnNo;
                string sTableNo = node.Attributes["ColumnNo"].InnerText;
                if (Int64.TryParse(sTableNo, out lColumnNo))
                {
                    OneColumn.columnNo = lColumnNo;
                }

                lColumns.Add(OneColumn);

            }

            return lColumns;
        }

        void DoSettingsSave(string extensionfilename, int language, int structuretype, string soutputfilename, string snamespace)
        {
            //We will store the data in a SQLite database, using the sqlite-net nuget package. 
            //This is of course a total overkill for a simple functionality, but hey, we gotta have some fun at work too!
            
            var db = new SQLiteConnection("GenerateDME.db");
            db.CreateTable<Settings>(); //Note: Executes a "create table if not exists"


            var s = db.Insert(new Settings()
            {
                ExtensionFile = extensionfilename,
                Language = language,
                StructureType = structuretype,
                OutputFile = soutputfilename,
                NamespaceString = snamespace
            }, "OR REPLACE");

            //Need to update the list as well
            //Remove from List 
            //lSettings.RemoveAt(iSelectedItemNo);
            IEnumerable<Settings> iFoundItem = lSettings.Where(v => v.ExtensionFile.Equals(extensionfilename));
            //should find only one item here. 
            //TODO: Check if something is actually found

            if (iFoundItem.Count() == 0)
            {
                //New item. Add to list
                lSettings.Add(new Settings()
                        {
                            ExtensionFile = extensionfilename,
                            Language = language,
                            StructureType = structuretype,
                            OutputFile = soutputfilename,
                            NamespaceString = snamespace
                        }
                        );

            }

            if (iFoundItem.Count() == 1)
            {
                //Existing item. Update
                iFoundItem.ElementAt(0).ExtensionFile = extensionfilename;
                iFoundItem.ElementAt(0).Language= language;
                iFoundItem.ElementAt(0).StructureType = structuretype;
                iFoundItem.ElementAt(0).OutputFile = soutputfilename;
                iFoundItem.ElementAt(0).NamespaceString =snamespace;


            }

        }

        void DoSettingsLoad()
        {
         
            try
            { 
                var db = new SQLiteConnection("GenerateDME.db");
                
                //Need to create an array containing the settings
                foreach (Settings rSettings in db.Table<Settings>())
                { 

                    lSettings.Add(new Settings()
                        {
                            ExtensionFile = rSettings.ExtensionFile,
                            Language = rSettings.Language,
                            StructureType = rSettings.StructureType,
                            OutputFile = rSettings.OutputFile,
                            NamespaceString = rSettings.NamespaceString
                        }
                   );

                    cExtensionFileName.Items.Add(rSettings.ExtensionFile); //Currently one extension file can contain only one set of settings

                }

                
            }
            catch (Exception ex)
            {
                //Catch if DB does not exist etc. 

            }


          

        }

        void FillControls(string selectedExtensionFileName)
        {
            //List<Settings> lFoundItem;

            IEnumerable<Settings> iFoundItem = lSettings.Where(v => v.ExtensionFile.Equals(selectedExtensionFileName));
            //should find only one item here. 
            //TODO: Check if something is actually found

            if (iFoundItem.Count() == 0)
            {
                ClearControls();
            }

            if (iFoundItem.Count() == 1)
            {
                cExtensionFileName.Text = iFoundItem.ElementAt(0).ExtensionFile;//TODO: Check that it actually has a content
            
                if (iFoundItem.ElementAt(0).Language == 1)
                {
                    LanguageCSharp.Checked = true;
                }
                else if (iFoundItem.ElementAt(0).Language == 2)
                {
                    LanguageVB.Checked = true;
                }

                if (iFoundItem.ElementAt(0).StructureType == 1)
                {
                    TypeClass.Checked = true;
                }
                else if (iFoundItem.ElementAt(0).StructureType == 2)
                {
                    TypeEnum.Checked = true;
                }
                tOutputFileName.Text = iFoundItem.ElementAt(0).OutputFile; //TODO: Check that it actually has a content
                tNamespace.Text = iFoundItem.ElementAt(0).NamespaceString; //TODO: Check that it actually has a content
            }

        }

        private void DeleteSettings_Click(object sender, EventArgs e)
        {
            string selectedExtensionFileName = cExtensionFileName.Text;

            var conn = new SQLiteConnection("GenerateDME.db");
            conn.Delete<Settings>(selectedExtensionFileName);

            //Remove from combobox
            cExtensionFileName.Items.Remove(iSelectedItemNo);

            //Remove from List 
            lSettings.RemoveAt(iSelectedItemNo);

            //Clear controls
            ClearControls();

        }

        private void ClearControls()
        {
            //ExtensionFileName is removed earlier

            //Do not reset Language/Type

            tOutputFileName.Text = "";
            tNamespace.Text = "";

        }

       
    }
}
