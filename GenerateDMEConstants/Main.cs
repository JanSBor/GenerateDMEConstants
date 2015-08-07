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

        const string lconstPrefix = "public const long ";
        const int paddingsize = 4;

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

                bool lRetVal = CreateCSharpFile(ExtensionName, lTables, lColumns);

            }
            else
            {

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

        private bool CreateCSharpFile(string ExtensionName, List<TableList> lTableList, List<ColumnList> lColumnList)
        {
            //The using statments can be removed, but keep them since they are there as default
            
            const string lusing1 = "using System;";
            const string lusing2 = "using System.Collections.Generic;";
            const string lusing3 = "using System.Linq;";
            const string lusing4 = "using System.Text;";
            const string lusing5 = "using System.Threading.Tasks;";
            const string lnamespace = "namespace ";
            
            const string lTableNo = "TableNo = ";
            bool bRes = false;

            //Create the file
            StreamWriter outputfile = new StreamWriter(OutputFileName.Text);

            //TODO: Check write access etc
            outputfile.WriteLine(lusing1);
            outputfile.WriteLine(lusing2);
            outputfile.WriteLine(lusing3);
            outputfile.WriteLine(lusing4);
            outputfile.WriteLine(lusing5);
            outputfile.WriteLine(Environment.NewLine); //This will actually give two empty lines
            outputfile.WriteLine(lnamespace + tnamespace.Text); //TODO: Check that the field has a value
            outputfile.WriteLine("{");

            //Loop through all the tables, and add the constants
            foreach (TableList table in lTableList)
            {
                //The name of the class should be the same as the name of the table
                outputfile.WriteLine("".PadRight(paddingsize) + "class " + table.identifier);
                outputfile.WriteLine("".PadRight(paddingsize) + "{" + Environment.NewLine);

                //Write TableNo
                outputfile.WriteLine("".PadRight(paddingsize) + "".PadRight(paddingsize) + lconstPrefix + lTableNo + table.tableno + ";");

                //Add columns. 
                bRes = AddColumnsCSharp(table.tableno, lColumnList, outputfile);

                //Empty line before closing the class
                outputfile.WriteLine(Environment.NewLine); //This will actually give two empty lines

                outputfile.WriteLine("".PadRight(paddingsize) + "}" + Environment.NewLine);


            }

            outputfile.WriteLine("}");
            outputfile.Close();

            bool retval = true;
            return retval;

        }

        bool AddColumnsCSharp(long tableno, List<ColumnList> lColumnList, StreamWriter outputfile)
        {

            //TODO: Yep, missing errorhandling here as well

            List<ColumnList> filtertedColumnList;

            //Find all columns belonging to this table. 
            filtertedColumnList = lColumnList.FindAll(filter => filter.tableno == tableno);
            foreach (ColumnList Column in lColumnList)
            {

                outputfile.WriteLine("".PadRight(paddingsize) + "".PadRight(paddingsize) + lconstPrefix + Column.identifier + " = " + Column.columnNo + ";");

            }

            return true;
        }

    }
}
