using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace GenerateDMEConstants
{
    class CsharpFile
    {
        const string lconstPrefix = "public const long ";
        const int paddingsize = 4;

        public CsharpFile(string FileName, string tNameSpace, StreamWriter outputfile)
        {
            //The using statments can be removed, but keep them since they are there as default

            const string lusing1 = "using System;";
            const string lusing2 = "using System.Collections.Generic;";
            const string lusing3 = "using System.Linq;";
            const string lusing4 = "using System.Text;";
            const string lusing5 = "using System.Threading.Tasks;";
            const string lnamespace = "namespace ";

            //const string lTableNo = "TableNo = ";
            //bool bRes = false;

            //Create the file
            //StreamWriter s = new StreamWriter(FileName);

            //TODO: Check write access etc
            outputfile.WriteLine(lusing1);
            outputfile.WriteLine(lusing2);
            outputfile.WriteLine(lusing3);
            outputfile.WriteLine(lusing4);
            outputfile.WriteLine(lusing5);
            outputfile.WriteLine(Environment.NewLine); //This will actually give two empty lines
            outputfile.WriteLine(lnamespace + tNameSpace); //TODO: Check that the field has a value
            outputfile.WriteLine("{");

            //outputfile = s;


        }

        public bool AddClassContent(StreamWriter outputfile, string ExtensionName, List<TableList> lTableList, List<ColumnList> lColumnList)
        {
            const string lTableNo = "TableNo = ";
            bool bRes;

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
