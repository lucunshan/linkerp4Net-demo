using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Kingdee.YZJ.Linkerp.Demo.Utility
{
    public class AuthUtility
    {
        /// <summary>
        /// 随机生成8位字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNonce()
        {
            int number; char code;
            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += code.ToString();
            }
            return checkCode;
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long GetTimestamp()
        {
            DateTime timeStamp = new DateTime(1970, 1, 1); //得到1970年的时间戳
            long a = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000; //注意这里有时区问题，用now就要减掉8个小时
            return a;
        }

        /// <summary>
        /// 获取参数签名
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static string GetSignature(string[] datas)
        {
            //string[] datas = new string[] { appId,secret,nonceStr,timestamp };
            Array.Sort(datas, StringComparer.Ordinal);
            string sortdata = String.Join("", datas);
            string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(sortdata, "SHA1").ToLower();
            return signature;
        }
    }
}
