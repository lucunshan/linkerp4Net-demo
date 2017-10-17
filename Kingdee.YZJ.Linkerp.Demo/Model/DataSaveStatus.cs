namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 数据保存状态
    /// </summary>
    public class DataSaveStatus
    {
        /**
     * 数据保存状态: 0：进行中，1：成功，2：失败
     */
        public int status;
        /**
         * 错误信息
         */
        public string error;

        public override string ToString()
        {
            return "ImportStatusVo [status=" + status + ", error=" + error + "]";
        }
    }
}
