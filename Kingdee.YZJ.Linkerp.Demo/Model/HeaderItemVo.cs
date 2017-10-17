using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 自定义数据表表头项
    /// </summary>
    [Serializable]
    public class HeaderItemVo
    {
        /**
     * 表头项中文名称
     */
        public string name { get; set; }

        /**
         * 表头项数据类型 目前支持string,number,timestamp
         */
        public string dataType { get; set; }

        public HeaderItemVo(string name, string dataType)
        {
            this.name = name;
            this.dataType = dataType;
        }
    }
}
