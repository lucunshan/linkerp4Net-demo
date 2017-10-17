using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    [Serializable]
    public class TableInfoIdParam
    {
        /**
         * 数据表Id
        */
        public string tableInfoId { get; set; }

        public override string ToString()
        {
            return "TableInfoIdParam [tableInfoId=" + tableInfoId + "]";
        }
    }
}
