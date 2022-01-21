using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Services.Contract
{
    public abstract class AbstractExamSubjectServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractExamSubject> ExamSubjectUpsert(AbstractExamSubject abstractExamSubject);

        public abstract PagedList<AbstractExamSubject> ExamSubjectSelectAll(PageParam pageParam, string search, string ExamKey = "");

        public abstract bool ExamSubjectDelete(string ExamKey, string SubjectKey);

        public abstract SuccessResult<AbstractExamSubject> ExamSubjectById(string ExamKey, string SubjectKey);
    }
}
