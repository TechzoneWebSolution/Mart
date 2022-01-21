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
    public class ExamStandardServices : AbstractExamStandardServices
    {
        private AbstractExamStandardDao abstractExamStandardDao;

        public ExamStandardServices(AbstractExamStandardDao abstractExamStandardDao)
        {
            this.abstractExamStandardDao = abstractExamStandardDao;
        }
        public override SuccessResult<AbstractExamStandard> ExamStandardUpsert(AbstractExamStandard abstractExam)
        {
            return this.abstractExamStandardDao.ExamStandardUpsert(abstractExam);
        }
        public override PagedList<AbstractExamStandard> ExamStandardSelectAll(PageParam pageParam, string search)
        {
            return this.abstractExamStandardDao.ExamStandardSelectAll(pageParam, search);
        }
        public override bool ExamStandardDelete(string StandardKey)
        {
            return this.abstractExamStandardDao.ExamStandardDelete(StandardKey);
        }
        public override SuccessResult<AbstractExamStandard> ExamStandardById(string StandardKey)
        {
            return this.abstractExamStandardDao.ExamStandardById(StandardKey);
        }
    }
}
