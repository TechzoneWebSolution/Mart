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
    public class ExamChapterDao : AbstractExamChapterDao
    {
        public override SuccessResult<AbstractExamChapter> ExamChapterUpsert(AbstractExamChapter abstractExamChapter)
        {
            SuccessResult<AbstractExamChapter> exam = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractExamChapter.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ChapterKey", abstractExamChapter.ChapterKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", abstractExamChapter.SubjectKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ChapterName", abstractExamChapter.ChapterName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractExamChapter.CreatedBy, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ModifiedBy", abstractExamChapter.ModifiedBy, DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamChapterUpsert, param, commandType: CommandType.StoredProcedure);
                exam = task.Read<SuccessResult<AbstractExamChapter>>().SingleOrDefault();
                exam.Item = task.Read<ExamChapter>().SingleOrDefault();
            }

            return exam;
        }

        public override PagedList<AbstractExamChapter> ExamChapterSelectAll(PageParam pageParam, string search, string SubjectKey = "")
        {
            PagedList<AbstractExamChapter> classes = new PagedList<AbstractExamChapter>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamChapterSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ExamChapter>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool ExamChapterDelete(string ChapterKey, string SubjectKey)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@ChapterKey", ChapterKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.ExamChapterDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractExamChapter> ExamChapterById(string ChapterKey, string SubjectKey)
        {
            SuccessResult<AbstractExamChapter> users = null;
            var param = new DynamicParameters();
            param.Add("@ChapterKey", ChapterKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamChapterById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractExamChapter>>().SingleOrDefault();
                users.Item = task.Read<ExamChapter>().SingleOrDefault();
            }
            return users;
        }
    }
}
