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
    public class ProductTypeDao : AbstractProductTypeDao
    {
        public override SuccessResult<AbstractProductType> ProductTypeUpsert(AbstractProductType abstractProductType)
        {
            SuccessResult<AbstractProductType> productType = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractProductType.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractProductType.Name, DbType.String, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", ProjectSession.UserID, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ModifiedBy", ProjectSession.UserID, DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ProductTypeUpsert, param, commandType: CommandType.StoredProcedure);
                productType = task.Read<SuccessResult<AbstractProductType>>().SingleOrDefault();
                productType.Item = task.Read<ProductType>().SingleOrDefault();
            }

            return productType;
        }

        public override PagedList<AbstractProductType> ProductTypeSelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractProductType> classes = new PagedList<AbstractProductType>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ProductTypeSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<ProductType>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool ProductTypeDelete(int Id)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.ProductTypeDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractProductType> ProductTypeById(int Id)
        {
            SuccessResult<AbstractProductType> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.ProductTypeById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractProductType>>().SingleOrDefault();
                users.Item = task.Read<ProductType>().SingleOrDefault();
            }
            return users;
        }

        //public override SuccessResult<ExamList> ExamListByKey(string Key)
        //{
        //    SuccessResult<ExamList> examlist = new SuccessResult<ExamList>();
        //    PagedList<AbstractExam> exam = new PagedList<AbstractExam>();
        //    PagedList<AbstractExamSubject> examSubject = new PagedList<AbstractExamSubject>();
        //    PagedList<AbstractExamChapter> examChapter = new PagedList<AbstractExamChapter>();
        //    var param = new DynamicParameters();
        //    param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.ExamListByKey, param, commandType: CommandType.StoredProcedure);
        //        examlist = task.Read<SuccessResult<ExamList>>().SingleOrDefault();
        //        exam.Values.AddRange(task.Read<Exam>());
        //        examSubject.Values.AddRange(task.Read<ExamSubject>());
        //        examChapter.Values.AddRange(task.Read<ExamChapter>());
        //        if (exam.Values.Count > 0)
        //        {
        //            foreach (var item in exam.Values)
        //            {
        //                var selectedQuestions = examSubject.Values.Where(x => x.ExamKey == item.ExamKey).ToList();
        //                item.Subjects = selectedQuestions;
        //                foreach (var item1 in item.Subjects)
        //                {
        //                    var selectedQuestions1 = examChapter.Values.Where(x => x.SubjectKey == item1.SubjectKey).ToList();
        //                    item1.Chapters = selectedQuestions1;
        //                    if (item1.Chapters.Count() <= 0)
        //                    {
        //                        item1.Chapters = null;
        //                    }
        //                }
        //                if (item.Subjects.Count() <= 0)
        //                {
        //                    item.Subjects = null;
        //                }
        //            }
        //        }
        //    }
        //    ExamList examList1 = new ExamList();
        //    examList1.Exams = exam.Values;
        //    if(examList1.Exams.Count() > 0) {
        //        examlist.Item = examList1;
        //    }
        //    else
        //    {
        //        examlist.Item = null;
        //    }
        //    return examlist;
        //}


        //public override SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam)
        //{
        //    SuccessResult<QuestionList> questionList1 = new SuccessResult<QuestionList>();
        //    PagedList<AbstractExamQuestion> examQuestion = new PagedList<AbstractExamQuestion>();
        //    var param = new DynamicParameters();
        //    string chkey = "";
        //    if(questionsAPIParam.ChapterKeys.Count() > 0)
        //    {
        //        for (var i =0; i < questionsAPIParam.ChapterKeys.Count(); i++)
        //        {
        //            if(i == (questionsAPIParam.ChapterKeys.Count() - 1))
        //            {
        //                chkey += questionsAPIParam.ChapterKeys[i];
        //            }
        //            else
        //            {
        //                chkey += questionsAPIParam.ChapterKeys[i] + ",";
        //            }
        //        }
        //    }
        //    param.Add("@StandardKey", questionsAPIParam.Key, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@ExamId", questionsAPIParam.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@SubjectKey", questionsAPIParam.SubjectKey, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@ChapterKeys", chkey, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@ExamFormat", questionsAPIParam.ExamFormat, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.QuestionsListAPI, param, commandType: CommandType.StoredProcedure);
        //        questionList1 = task.Read<SuccessResult<QuestionList>>().SingleOrDefault();
        //        examQuestion.Values.AddRange(task.Read<ExamQuestion>());
        //    }
        //    QuestionList questionList = new QuestionList();
        //    questionList.Questions = examQuestion.Values;
        //    if (questionList.Questions.Count() > 0)
        //    {
        //        questionList1.Item = questionList;
        //    }
        //    else
        //    {
        //        questionList1.Item =null;
        //    }
        //    return questionList1;
        //}
    }
}
