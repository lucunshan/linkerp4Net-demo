using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 自定义数据表信息
    /// </summary>
    [Serializable]
    public class TableVo
    {

        /**
        * 表信息id
        */
        public string id { get; set; }

        /**
         * 表名称(中文)
         */
        public string name { get; set; }

        /**
         * 数据库表数据更新时间(时间戳)
         */
        public long dataUpdateTime { get; set; }

    }
}
