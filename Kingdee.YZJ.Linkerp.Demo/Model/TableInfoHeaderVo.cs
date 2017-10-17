using System;
using System.Collections.Generic;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 数据表表头信息
    /// </summary>
    [Serializable]
    public class TableInfoHeaderVo
    {
        /**
     * 工作圈eid
     */
        public string eid { get; set; }

        /**
         * 数据表名称
         */
        public string name { get; set; }
        /**
         * 报表类别记录id
         */
        public string reportCategoryId { get; set; }

        /**
         * 表头项
         */
        public List<HeaderItemVo> headerItems { get; set; }
    }
}
