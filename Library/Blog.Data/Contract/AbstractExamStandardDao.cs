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
   public abstract class AbstractExamStandardDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractExamStandard> ExamStandardUpsert(AbstractExamStandard abstractExam);

        public abstract PagedList<AbstractExamStandard> ExamStandardSelectAll(PageParam pageParam, string search);

        public abstract bool ExamStandardDelete(string StandardKey);

        public abstract SuccessResult<AbstractExamStandard> ExamStandardById(string StandardKey);


    }
}
