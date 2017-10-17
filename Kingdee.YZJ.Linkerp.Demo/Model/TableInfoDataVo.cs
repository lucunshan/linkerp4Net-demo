using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 数据表数据
    /// </summary>
    [Serializable]
    public class TableInfoDataVo
    {
        /**
        * 企业工作圈eid
        */
        public string eid { get; set; }
        /**
         * 批次id,有线下产生，每次传不重复随机值，建议使用uuid
         */
        public string batchId { get; set; }
        /**
         * 报表分类Id
         */
        public string reportCategoryId { get; set; }
        /**
         * 数据表Id，来源于创建数据表头返回值或已有数据表
         */
        public string tableInfoId { get; set; }
        /**
         * 数据新增类型 1：增量；2：替换
         */
        public int addType { get; set; }
        /**
         * 数据
         */
        public string data { get; set; }
    }
}
