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
    public class ExamSubjectServices : AbstractExamSubjectServices
    {
        private AbstractExamSubjectDao abstractExamSubjectDao;

        public ExamSubjectServices(AbstractExamSubjectDao abstractExamSubjectDao)
        {
            this.abstractExamSubjectDao = abstractExamSubjectDao;
        }

        public override SuccessResult<AbstractExamSubject> ExamSubjectUpsert(AbstractExamSubject abstractExamSubject)
        {
            return this.abstractExamSubjectDao.ExamSubjectUpsert(abstractExamSubject);
        }

        public override PagedList<AbstractExamSubject> ExamSubjectSelectAll(PageParam pageParam, string search, string ExamKey = "")
        {
            return this.abstractExamSubjectDao.ExamSubjectSelectAll(pageParam, search, ExamKey);
        }

        public override bool ExamSubjectDelete(string ExamKey, string SubjectKey)
        {
            return this.abstractExamSubjectDao.ExamSubjectDelete(ExamKey, SubjectKey);
        }

        public override SuccessResult<AbstractExamSubject> ExamSubjectById(string ExamKey, string SubjectKey)
        {
            return this.abstractExamSubjectDao.ExamSubjectById(ExamKey, SubjectKey);
        }
    }
}
