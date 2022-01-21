using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Data.Contract
{
   public abstract class AbstractExamDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractExam> ExamUpsert(AbstractExam abstractExam);

        public abstract PagedList<AbstractExam> ExamSelectAll(PageParam pageParam, string search);

        public abstract bool ExamDelete(string ExamKey);

        public abstract SuccessResult<AbstractExam> ExamById(string ExamKey);

        public abstract SuccessResult<ExamList> ExamListByKey(string Key);

        public abstract SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam);
    }
}
