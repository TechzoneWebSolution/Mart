using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Services.Contract;

namespace Blog.Services.V1
{
    public class ExamQuestionServices : AbstractExamQuestionServices
    {
        private AbstractExamQuestionDao abstractExamQuestionDao;

        public ExamQuestionServices(AbstractExamQuestionDao abstractExamQuestionDao)
        {
            this.abstractExamQuestionDao = abstractExamQuestionDao;
        }

        public override SuccessResult<AbstractExamQuestion> ExamQuestionUpsert(AbstractExamQuestion abstractExamQuestion)
        {
            return this.abstractExamQuestionDao.ExamQuestionUpsert(abstractExamQuestion);
        }

        public override PagedList<AbstractExamQuestion> ExamQuestionSelectAll(PageParam pageParam, string search, string ExamKey = "", string SubjectKey = "", string ChapterKey = "")
        {
            return this.abstractExamQuestionDao.ExamQuestionSelectAll(pageParam, search,ExamKey,SubjectKey,ChapterKey);
        }
        

        public override bool QuestionDelete(int Id)
        {
            return this.abstractExamQuestionDao.QuestionDelete(Id);
        }

        //public override bool ExamVSStandardDelete(string QuestionKey, string ExamKey)
        //{
        //    return this.abstractExamVSStandardDao.ExamVSStandardDelete(QuestionKey, ExamKey);
        //}

        //public override SuccessResult<AbstractExamVSStandard> ExamVSStandardById(string QuestionKey, string ExamKey)
        //{
        //    return this.abstractExamVSStandardDao.ExamVSStandardById(QuestionKey, ExamKey);
        //}
    }
}
