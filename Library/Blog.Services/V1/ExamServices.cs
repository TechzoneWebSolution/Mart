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
    public class ExamServices : AbstractExamServices
    {
        private AbstractExamDao abstractExamDao;

        public ExamServices(AbstractExamDao abstractExamDao)
        {
            this.abstractExamDao = abstractExamDao;
        }

        public override SuccessResult<AbstractExam> ExamUpsert(AbstractExam abstractExam)
        {
            return this.abstractExamDao.ExamUpsert(abstractExam);
        }

        public override PagedList<AbstractExam> ExamSelectAll(PageParam pageParam, string search)
        {
            return this.abstractExamDao.ExamSelectAll(pageParam, search);
        }

        public override bool ExamDelete(string ExamKey)
        {
            return this.abstractExamDao.ExamDelete(ExamKey);
        }

        public override SuccessResult<AbstractExam> ExamById(string ExamKey)
        {
            return this.abstractExamDao.ExamById(ExamKey);
        }

        public override SuccessResult<ExamList> ExamListByKey(string Key)
        {
            return this.abstractExamDao.ExamListByKey(Key);
        }
        public override SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam)
        {
            return this.abstractExamDao.QuestionsListAPI(questionsAPIParam);
        }
    }
}
