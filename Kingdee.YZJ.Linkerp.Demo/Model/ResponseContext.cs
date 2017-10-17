using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 返回值通用类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResponseContext<T>
    {
        public ResponseContext()
        {
            data = default(T);
        }
        //数据
        public T data { get; set; }

        //错误信息
        public string error { set; get; }
        //错误码
        public int errorCode { set; get; }
        //是否成功
        public bool success { get; set; }
    }

}
