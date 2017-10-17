using System;

namespace Kingdee.YZJ.Linkerp.Demo.Model
{
    /// <summary>
    /// 访问令牌
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// 授权Token
        /// </summary>
        public string accessToken { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expireIn { get; set; }
        /// <summary>
        /// 刷新Token
        /// </summary>
        public string refreshToken { get; set; }

        public AccessToken()
        {
            this.createTime = DateTime.Now.Millisecond;
        }

        /**
         * 创建时间
         */
        private long createTime;

        public bool isExpire()
        {
            return this.createTime + this.expireIn * 1000 < DateTime.Now.Millisecond - 1000 * 60 * 5;
        }

        public override String ToString()
        {
            return "AccessToken [accessToken=" + accessToken + ", expireIn=" + expireIn + ", refreshToken=" + refreshToken + ", createTime=" + createTime
                    + "]";
        }
    }
}
