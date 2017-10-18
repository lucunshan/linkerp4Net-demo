using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kingdee.YZJ.Linkerp.Demo.Model;
using Kingdee.YZJ.Linkerp.Demo.Service;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kingdee.YZJ.Linkerp.DemoTest
{
    [TestClass]
    public class DemoTest
    {
        private AccessTokenService accessTokenService = new AccessTokenService();
        private OpenApiService openApiService = new OpenApiService();


        /// <summary>
        /// 获取令牌
        /// </summary>
        [TestMethod]
        public void TestGetAccessToken()
        {
            AccessToken accessToken = accessTokenService.GetAccessToken();
            Console.WriteLine(accessToken);
        }


        /// <summary>
        /// 刷新令牌
        /// </summary>
        [TestMethod]
        public void TestRefreshToken()
        {
            AccessToken accessToken = accessTokenService.RefreshToken();
            Console.WriteLine(accessToken);

        }

        /// <summary>
        /// 获取轻应用管理员权限内所有报表分类及OpenApi创建的数据表信息
        /// </summary>
        [TestMethod]
        public void TestGetAdminTableInfos()
        {
            AccessToken accessToken = accessTokenService.GetAccessToken();
            string eid = "11738174";

            List<CategoryWithReportTableVo> categoryWithReportTableVos = openApiService.GetAdminTableInfos(eid, accessToken.accessToken);

            string jsonData = JsonConvert.SerializeObject(categoryWithReportTableVos);

            Console.WriteLine(jsonData);

        }

        /// <summary>
        /// 创建数据表头
        /// </summary>
        [TestMethod]
        public void TestCreateReportTableInfoHeader()
        {
            AccessToken accessToken = accessTokenService.GetAccessToken();

            TableInfoHeaderVo header = new TableInfoHeaderVo();
            header.eid = "11738174";
            header.name = "自定义API测试";
            header.reportCategoryId = "59cf54bd59b4462841b12c85"; // 报表分类Id
                                                                  // 来源于AdminTableInfos

            List<HeaderItemVo> headerItems = new List<HeaderItemVo>();
            headerItems.Add(new HeaderItemVo("表头1", "string"));
            headerItems.Add(new HeaderItemVo("表头2", "number"));
            headerItems.Add(new HeaderItemVo("表头3", "timestamp"));
            header.headerItems = headerItems;

            TableInfoIdParam tableInfoIdParam = openApiService.CreateReportTableInfoHeader(header, accessToken.accessToken);
            Console.WriteLine(tableInfoIdParam);
        }

        /// <summary>
        /// 上传数据表数据
        /// </summary>
        [TestMethod]
        public void TestSaveReportTableInfoData()
        {
            AccessToken accessToken = accessTokenService.GetAccessToken();
            TableInfoDataVo tableData = new TableInfoDataVo();
            string testData = "[{\"表头1\":\"中国\",\"表头2\":\"100\",\"表头3\":\"2008-08-08 20:00:00\"},{\"表头1\":\"美国\",\"表头2\":\"80\",\"表头3\":\"2009-09-08 20:00:00\"},{\"表头1\":\"法国\",\"表头2\":\"115\",\"表头3\":\"2008-08-08 20:00:00\"}]";
            tableData.eid = "11738174";
            tableData.reportCategoryId = "59cf54bd59b4462841b12c85"; // 来源于AdminTableInfos,与表头保持一致
            tableData.tableInfoId = "59e48733b449296dae8bacc2";// 来源于表头创建或已有数据表Id
            tableData.addType = 1;
            tableData.data = testData;
            tableData.batchId = "GmdGyrsuqqPqZcZRLpwzxXvjbDXu89";// 批次id,每次传不重复随机值，建议使用uuid

            bool status = openApiService.SaveReportTableInfoData(tableData, accessToken.accessToken);

            Console.WriteLine(status);
        }

        /// <summary>
        /// 查询上传数据表数据上传结果
        /// </summary>
        [TestMethod]
        public void TestGetReportTableInfoDataSaveStatus()
        {
            AccessToken accessToken = accessTokenService.GetAccessToken();

            string eid = "11738174";

            string batchId = "GmdGyrsuqqPqZcZRLpwzxXvjbDXu89";// 批次id,每次传不重复随机值，建议使用uuid

            DataSaveStatus status = openApiService.GetReportTableInfoDataSaveStatus(eid, batchId, accessToken.accessToken);

            Console.WriteLine(status);
        }
    }
}
