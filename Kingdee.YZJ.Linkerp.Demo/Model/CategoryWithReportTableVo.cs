using System;
using System.Collections.Generic;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 报表分类及自定义数据表值对象
    /// </summary>
    [Serializable]
    public class CategoryWithReportTableVo
    {
        /**
        * 报表分类ID
        */
        public string id { get; set; }

        /**
         * 模板报表主题名称
         */
        public string name { get; set; }

        /**
         * 数据表
         */
        public List<TableVo> tableInfos { get; set; }

    }
}
