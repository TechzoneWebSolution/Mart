using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Entities.V1;

namespace Blog.Data.V1
{
    public class StandardDao : AbstractStandardDao
    {
        public override SuccessResult<AbstractStandard> StandardById(int Id)
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardById, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override PagedList<AbstractStandard> StandardSelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractStandard> classes = new PagedList<AbstractStandard>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Standard>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractStandard> InsertUpdateStandards(AbstractStandard abstractStandard)
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractStandard.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractStandard.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Live_json", abstractStandard.Live_json, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Blog_json", abstractStandard.Blog_json, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@News_json", abstractStandard.News_json, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", abstractStandard.Key, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@BlogVersion", abstractStandard.BlogVersion, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LiveVersion", abstractStandard.LiveVersion, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardUpsert, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDate(string Key,string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDate, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override bool StandardBannerJsonUpdate(int StandardId,string Banner_json)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardId", StandardId ,dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Banner_json", Banner_json, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StandardBannerJsonUpdate, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override bool StandardHomeScrrenJsonUpdate(int StandardId, string HomeScreen_json)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardId", StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@HomeScreen_json", HomeScreen_json, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StandardHomeScrrenJsonUpdate, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForHomeScreenJson(string Key, string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDateForHomeScreenJson, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForBannerJson(string Key, string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDateForBannerJson, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override SuccessResult<AbstractStandard> StandardByKeyLetestVersion(string Key)
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByKeyLetestVersion, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }
        public override bool StandardOtherAppDataJsonUpdate(int StandardId, string OtherAppDataJson)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardId", StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OtherAppDataJson", OtherAppDataJson, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StandardOtherAppDataJsonUpdate, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override bool StandardCompetativeExamsJsonUpdate(int StandardId, string CompetativeExamsJson)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardId", StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CompetativeExamsJson", CompetativeExamsJson, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StandardCompetativeExamsJsonUpdate, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForOtherAppData(string Key, string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDateForOtherAppData, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }


        public override SuccessResult<AbstractStandard> StandardByIdByDateForCompetativeExams(string Key, string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDateForCompetativeExams, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }

        public override bool StandardOtherPDFMeterialUpdate(int StandardId, string OtherPDFMeterial)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardId", StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@OtherPDFMeterial", OtherPDFMeterial, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StandardOtherPDFMeterialUpdate, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override SuccessResult<AbstractStandard> StandardByIdByDateForOtherPDFMeterial(string Key, string Date = "")
        {
            SuccessResult<AbstractStandard> Standards = null;
            var param = new DynamicParameters();
            param.Add("@Date", Date, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StandardByIdByDateForOtherPDFMeterial, param, commandType: CommandType.StoredProcedure);
                Standards = task.Read<SuccessResult<AbstractStandard>>().SingleOrDefault();
                Standards.Item = task.Read<Standard>().SingleOrDefault();
            }
            return Standards;
        }


    }
}
