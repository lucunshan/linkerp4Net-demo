using System;
using System.Configuration;

namespace Kingdee.YZJ.Linkerp.Demo.Constant
{
    public static class URLConstant
    {
        /**
         * 获取团队accessToken
         */
        public static String GETTEAMACCESSTOKEN = getHost() + "/gateway/oauth2/token/getTeamAccessToken";
        /**
         * 刷新accessToken
         */
        public static String REFRESHTOKEN = getHost() + "/gateway/oauth2/token/refreshToken";
        /**
         * 获取轻应用管理员权限内所有报表分类及数据表信息
         */
        public static String GETADMINTABLEINFOS = getHost() + "/api/open/linkerp/ReportDataTableapi/getAdminTableInfos";
        /**
         * 创建数据表头
         */
        public static String CREATETABLEINFOHEADER = getHost() + "/api/open/linkerp/customizedapi/createTableInfoHeader";
        /**
         * 上传数据表数据
         */
        public static String SAVETABLEINFODATA = getHost() + "/api/open/linkerp/customizedapi/saveTableInfoData";

        /**
         * 查询上传数据表数据上传结果
         */
        public static String GETTABLEINFODATASAVESTATUS = getHost() + "/api/open/linkerp/customizedapi/getTableInfoDataSaveStatus";

        public static String getHost()
        {
            return ConfigurationManager.AppSettings["yzjHost"].ToString();
        }
    }
}
