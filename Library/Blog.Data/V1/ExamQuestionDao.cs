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
    public class ExamQuestionDao : AbstractExamQuestionDao
    {
        public override SuccessResult<AbstractExamQuestion> ExamQuestionUpsert(AbstractExamQuestion abstractExamQuestion)
        {
            SuccessResult<AbstractExamQuestion> exam = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractExamQuestion.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@QuestionKey", abstractExamQuestion.QuestionKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@QuestionImage", abstractExamQuestion.QuestionImage, DbType.String, direction: ParameterDirection.Input);
            param.Add("@AnswerImage", abstractExamQuestion.AnswerImage, DbType.String, direction: ParameterDirection.Input);
            param.Add("@AnswerOptions", abstractExamQuestion.AnswerOptions, DbType.String, direction: ParameterDirection.Input);
            param.Add("@CorrectAnswer", abstractExamQuestion.CorrectAnswer, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamKey", abstractExamQuestion.ExamKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamSubjectKey", abstractExamQuestion.ExamSubjectKey, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExamChapterKey", abstractExamQuestion.ExamChapterKey, DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamQuestionUpsert, param, commandType: CommandType.StoredProcedure);
                exam = task.Read<SuccessResult<AbstractExamQuestion>>().SingleOrDefault();
                exam.Item = task.Read<ExamQuestion>().SingleOrDefault();
            }

            return exam;
        }

        public override PagedList<AbstractExamQuestion> ExamQuestionSelectAll(PageParam pageParam, string search, string ExamKey = "", string SubjectKey = "", string ChapterKey = "")
        {
            PagedList<AbstractExamQuestion> classes = new PagedList<AbstractExamQuestion>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ExamKey", ExamKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SubjectKey", SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ChapterKey", ChapterKey, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ExamQuestionSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ExamQuestion>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool QuestionDelete(int Id)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.QuestionDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }
    }
}
