using Kingdee.YZJ.Linkerp.Demo.Constant;
using Kingdee.YZJ.Linkerp.Demo.Model;
using Kingdee.YZJ.Linkerp.Demo.Utility;
using System.Configuration;

namespace Kingdee.YZJ.Linkerp.Demo.Service
{
    /// <summary>
    /// 令牌服务类
    /// </summary>
    public class AccessTokenService
    {
        private static AccessToken m_AccessToken = null;
        string m_AppID = ConfigurationManager.AppSettings["appId"].ToString();
        string m_Secret = ConfigurationManager.AppSettings["secret"].ToString();

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        public AccessToken GetAccessToken()
        {
            string url = URLConstant.GETTEAMACCESSTOKEN;

            string nonceStr = AuthUtility.GetNonce(), timestamp = AuthUtility.GetTimestamp().ToString();

            string[] datas = new string[] { m_AppID, m_Secret, nonceStr, timestamp };

            string signature = AuthUtility.GetSignature(datas);

            var model = new
            {
                appId = m_AppID,
                nonceStr = nonceStr,
                signature = signature,
                timestamp = timestamp
            };


            if (m_AccessToken == null || m_AccessToken.isExpire())
            {
                ResponseContext<AccessToken> result = HttpUtility.PostData<ResponseContext<AccessToken>>(url, model);
                if (result != null && result.success)
                {
                    // access_token
                    m_AccessToken = result.data;
                }
            }

            return m_AccessToken;
        }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <returns></returns>
        public AccessToken RefreshToken()
        {
            AccessToken token = GetAccessToken();
            if (token == null)
            {
                return null;
            }
            string url = URLConstant.REFRESHTOKEN;

            string nonceStr = AuthUtility.GetNonce(), timestamp = AuthUtility.GetTimestamp().ToString();

            string[] datas = new string[] { m_AppID, m_Secret, nonceStr, timestamp, token.refreshToken };

            string signature = AuthUtility.GetSignature(datas);

            var model = new
            {
                appId = m_AppID,
                nonceStr = nonceStr,
                signature = signature,
                refreshToken = token.refreshToken,
                timestamp = timestamp
            };

            ResponseContext<AccessToken> result = HttpUtility.PostData<ResponseContext<AccessToken>>(url, model);
            if (result != null && result.success)
            {
                // access_token
                m_AccessToken = result.data;
            }

            return m_AccessToken;
        }
    }
}
