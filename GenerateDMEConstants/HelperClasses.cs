using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GenerateDMEConstants
{
    //class HelperClasses
    //{
    //}
    
    class TableList
    {
        public string identifier { get; set; }
        public long tableno { get; set; }
    }

    class ColumnList
    {
        public string identifier { get; set; }
        public long columnNo { get; set; }
        public long tableno { get; set; }
    }

    public class Settings
    {
        //[PrimaryKey, AutoIncrement]
        //public int Id { get; set; }
        [PrimaryKey]
        public string ExtensionFile { get; set; }
        public int Language { get; set; } //1 = C#, 2 = vb.net
        public int StructureType { get; set; } //1 = class, 2 = enum
        public string OutputFile { get; set; }
        public string NamespaceString { get; set; } //1 = class, 2 = enum

    }

}
