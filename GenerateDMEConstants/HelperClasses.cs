using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public long ColumnNo { get; set; }
        public long tableno { get; set; }
    }

}
