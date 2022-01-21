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
    public class ExamStandardDao : AbstractExamStandardDao
    {
        public override SuccessResult<AbstractExamStandard> ExamStandardUpsert(AbstractExamStandard abstractExam)
        {
            SuccessResult<AbstractExamStandard> exam = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractExam.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractExam.Name, DbType.String, direction: ParameterDirection.Input);
            param.Add("@StandardKey", abstractExam.StandardKey, DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamStandardUpsert, param, commandType: CommandType.StoredProcedure);
                exam = task.Read<SuccessResult<AbstractExamStandard>>().SingleOrDefault();
                exam.Item = task.Read<ExamStandard>().SingleOrDefault();
            }

            return exam;
        }

        public override PagedList<AbstractExamStandard> ExamStandardSelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractExamStandard> classes = new PagedList<AbstractExamStandard>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamStandardSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ExamStandard>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool ExamStandardDelete(string StandardKey)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@StandardKey", StandardKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.ExamStandardDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractExamStandard> ExamStandardById(string StandardKey)
        {
            SuccessResult<AbstractExamStandard> users = null;
            var param = new DynamicParameters();
            param.Add("@StandardKey", StandardKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamStandardById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractExamStandard>>().SingleOrDefault();
                users.Item = task.Read<ExamStandard>().SingleOrDefault();
            }
            return users;
        }


    }
}
