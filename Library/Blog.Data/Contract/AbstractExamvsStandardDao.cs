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
   public abstract class AbstractExamVSStandardDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractExamVSStandard> ExamVSStandardUpsert(AbstractExamVSStandard abstractExamVSStandard);

        public abstract PagedList<AbstractExamVSStandard> ExamVSStandardSelectAll(PageParam pageParam, string search, string ExamKey = "", string StandardKey = "");

        public abstract bool ExamVSStandardDelete(string StandardKey, string ExamKey);

        public abstract SuccessResult<AbstractExamVSStandard> ExamVSStandardById(string QuestionKey, string ExamKey);
    }
}
