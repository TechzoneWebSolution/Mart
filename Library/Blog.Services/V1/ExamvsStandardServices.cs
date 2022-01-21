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
    public class ExamVSStandardServices : AbstractExamVSStandardServices
    {
        private AbstractExamVSStandardDao abstractExamVSStandardDao;

        public ExamVSStandardServices(AbstractExamVSStandardDao abstractExamVSStandardDao)
        {
            this.abstractExamVSStandardDao = abstractExamVSStandardDao;
        }

        public override SuccessResult<AbstractExamVSStandard> ExamVSStandardUpsert(AbstractExamVSStandard abstractExamVSStandard)
        {
            return this.abstractExamVSStandardDao.ExamVSStandardUpsert(abstractExamVSStandard);
        }

        public override PagedList<AbstractExamVSStandard> ExamVSStandardSelectAll(PageParam pageParam, string search, string ExamKey = "", string StandardKey = "")
        {
            return this.abstractExamVSStandardDao.ExamVSStandardSelectAll(pageParam, search,ExamKey,StandardKey);
        }

        public override bool ExamVSStandardDelete(string StandardKey, string ExamKey)
        {
            return this.abstractExamVSStandardDao.ExamVSStandardDelete(StandardKey, ExamKey);
        }

        public override SuccessResult<AbstractExamVSStandard> ExamVSStandardById(string StandardKey, string ExamKey)
        {
            return this.abstractExamVSStandardDao.ExamVSStandardById(StandardKey, ExamKey);
        }
    }
}
