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
    public class ExamVSStandardDao : AbstractExamVSStandardDao
    {
        public override SuccessResult<AbstractExamVSStandard> ExamVSStandardUpsert(AbstractExamVSStandard abstractExamVSStandard)
        {
            SuccessResult<AbstractExamVSStandard> exam = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractExamVSStandard.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StandardKey", abstractExamVSStandard.StandardKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamKey", abstractExamVSStandard.ExamKey, DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamVSStandardUpsert, param, commandType: CommandType.StoredProcedure);
                exam = task.Read<SuccessResult<AbstractExamVSStandard>>().SingleOrDefault();
                exam.Item = task.Read<ExamVSStandard>().SingleOrDefault();
            }

            return exam;
        }

        public override PagedList<AbstractExamVSStandard> ExamVSStandardSelectAll(PageParam pageParam, string search, string ExamKey = "", string StandardKey = "")
        {
            PagedList<AbstractExamVSStandard> classes = new PagedList<AbstractExamVSStandard>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StandardKey", StandardKey, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamVSStandardSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ExamVSStandard>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool ExamVSStandardDelete(string StandardKey, string ExamKey)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardKey", StandardKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.ExamVSStandardDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractExamVSStandard> ExamVSStandardById(string StandardKey, string ExamKey)
        {
            SuccessResult<AbstractExamVSStandard> users = null;
            var param = new DynamicParameters();
            param.Add("@StandardKey", StandardKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamVSStandardById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractExamVSStandard>>().SingleOrDefault();
                users.Item = task.Read<ExamVSStandard>().SingleOrDefault();
            }
            return users;
        }
    }
}
