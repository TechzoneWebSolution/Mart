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
    public class ExamSubjectDao : AbstractExamSubjectDao
    {
        public override SuccessResult<AbstractExamSubject> ExamSubjectUpsert(AbstractExamSubject abstractExamSubject)
        {
            SuccessResult<AbstractExamSubject> exam = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractExamSubject.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ExamKey", abstractExamSubject.ExamKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", abstractExamSubject.SubjectKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectName", abstractExamSubject.SubjectName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractExamSubject.CreatedBy, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ModifiedBy", abstractExamSubject.ModifiedBy, DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamSubjectUpsert, param, commandType: CommandType.StoredProcedure);
                exam = task.Read<SuccessResult<AbstractExamSubject>>().SingleOrDefault();
                exam.Item = task.Read<ExamSubject>().SingleOrDefault();
            }

            return exam;
        }

        public override PagedList<AbstractExamSubject> ExamSubjectSelectAll(PageParam pageParam, string search, string ExamKey = "")
        {
            PagedList<AbstractExamSubject> classes = new PagedList<AbstractExamSubject>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamSubjectSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ExamSubject>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool ExamSubjectDelete(string ExamKey, string SubjectKey)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.ExamSubjectDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractExamSubject> ExamSubjectById(string ExamKey, string SubjectKey)
        {
            SuccessResult<AbstractExamSubject> users = null;
            var param = new DynamicParameters();
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamSubjectById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractExamSubject>>().SingleOrDefault();
                users.Item = task.Read<ExamSubject>().SingleOrDefault();
            }
            return users;
        }
    }
}
