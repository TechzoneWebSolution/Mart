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
   public abstract class AbstractExamQuestionDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractExamQuestion> ExamQuestionUpsert(AbstractExamQuestion abstractExamQuestion);

        public abstract PagedList<AbstractExamQuestion> ExamQuestionSelectAll(PageParam pageParam, string search, string ExamKey = "", string SubjectKey = "", string ChapterKey = "");

        public abstract bool QuestionDelete(int Id);

        //public abstract SuccessResult<AbstractExamQuestion> ExamQuestionById(string QuestionKey, string ExamKey);
    }
}
