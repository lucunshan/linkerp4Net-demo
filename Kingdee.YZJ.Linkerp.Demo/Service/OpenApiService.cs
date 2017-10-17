using Kingdee.YZJ.Linkerp.Demo.Constant;
using Kingdee.YZJ.Linkerp.Demo.Model;
using Kingdee.YZJ.Linkerp.Demo.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;

namespace Kingdee.YZJ.Linkerp.Demo.Service
{
    /// <summary>
    /// 开放接口服务
    /// </summary>
    public class OpenApiService
    {
        string m_AESKey = ConfigurationManager.AppSettings["aesKey"].ToString();

        /// <summary>
        /// 获取轻应用管理员权限内所有报表分类及OpenApi创建的数据表信息
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public List<CategoryWithReportTableVo> GetAdminTableInfos(string eid, string accessToken)
        {

            string url = URLConstant.GETADMINTABLEINFOS + string.Format("?accessToken={0}", accessToken);

            dynamic dyParams = new ExpandoObject();
            dyParams.eid = eid;

            ResponseContext<string> result = PostGetAction(url, dyParams);

            string decryptData = AESUtility.Decrypt(result.data, m_AESKey);
            List<CategoryWithReportTableVo> categoryWithReportTableVos = JsonConvert.DeserializeObject<List<CategoryWithReportTableVo>>(decryptData);

            return categoryWithReportTableVos;
        }

        /// <summary>
        /// 创建数据表头
        /// </summary>
        /// <param name="header"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public TableInfoIdParam CreateReportTableInfoHeader(TableInfoHeaderVo header, string accessToken)
        {
            TableInfoIdParam tableInfoIdParam = null;
            string url = URLConstant.CREATETABLEINFOHEADER + string.Format("?accessToken={0}", accessToken);

            ResponseContext<string> result = PostGetAction(url, header);

            string decryptData = AESUtility.Decrypt(result.data, m_AESKey);
            tableInfoIdParam = JsonConvert.DeserializeObject<TableInfoIdParam>(decryptData);
            return tableInfoIdParam;
        }

        /// <summary>
        /// 上传数据表数据
        /// </summary>
        /// <param name="tableData"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public bool SaveReportTableInfoData(TableInfoDataVo tableData, string accessToken)
        {
            string url = URLConstant.SAVETABLEINFODATA + string.Format("?accessToken={0}", accessToken);

            ResponseContext<string> result = PostGetAction(url, tableData);
            return result.success;
        }

        /// <summary>
        /// 查询上传数据表数据上传结果
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="batchId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public DataSaveStatus GetReportTableInfoDataSaveStatus(string eid, string batchId, string accessToken)
        {
            string url = URLConstant.GETTABLEINFODATASAVESTATUS + string.Format("?accessToken={0}", accessToken);

            dynamic dyParams = new ExpandoObject();
            dyParams.eid = eid;
            dyParams.batchId = batchId;

            ResponseContext<string> result = PostGetAction(url, dyParams);

            string decryptData = AESUtility.Decrypt(result.data, m_AESKey);
            return JsonConvert.DeserializeObject<DataSaveStatus>(decryptData);

        }

        /// <summary>
        /// 上报数据通用方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dyData"></param>
        /// <returns></returns>
        private ResponseContext<string> PostGetAction(string url, dynamic dyData)
        {
            string jsonData = JsonConvert.SerializeObject(dyData, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            string data = AESUtility.Encrypt(jsonData, m_AESKey);

            var model = new
            {
                data = data
            };

            ResponseContext<string> result = new ResponseContext<string>() { success = false };
            return HttpUtility.PostData<ResponseContext<string>>(url, model);

        }
    }
}
