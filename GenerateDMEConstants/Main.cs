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

namespace GenerateDMEConstants
{
    public partial class Main : Form
    {


        public Main()
        {
            InitializeComponent();
        }

        private void SelectExtFile_Click(object sender, EventArgs e)
        {
            DialogResult result = ExtensionFileDlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = ExtensionFileDlg.FileName;

                ExtensionFileName.Text = file;
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

                OutputFileName.Text = file;
            }
            else
            {
                //TODO: Add errorhandling
            }
        }

        private void GenerateFile_Click(object sender, EventArgs e)
        {
            string snamespace = tnamespace.Text; //TODO: Check that it actually has a content
            string soutputfilename = OutputFileName.Text; //TODO: Check that it actually has a content
            StreamWriter swOutputFile = new StreamWriter(soutputfilename);

            //Read Extension file
            XmlDocument xd = new XmlDocument();
            xd.Load(ExtensionFileName.Text);

            //Get the name of the Extension
            string ExtensionName = GetExtensionName(xd);

            //Put tables into one list, and columns into another
            List<TableList> lTables = CreateTableList(xd);

            List<ColumnList> lColumns = CreateColumnList(xd);


            //Write class file
            if (LanguageCSharp.Checked)
            {
                CsharpFile c = new CsharpFile(soutputfilename, snamespace, swOutputFile);
                c.AddClassContent(swOutputFile, ExtensionName, lTables, lColumns);


            }
            else
            {
                //TODO
            }

            Console.WriteLine("heisann");
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

      
    }
}
