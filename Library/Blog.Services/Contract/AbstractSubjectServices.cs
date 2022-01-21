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
    public abstract class AbstractSubjectServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractSubject> SubjectUpsert(AbstractSubject abstractSubject);

        public abstract SuccessResult<AbstractSubject> SubjectById(int Id);

        public abstract PagedList<AbstractSubject> SubjectSelectAll(PageParam pageParam, string search, int StandardId = 0);

        public abstract PagedList<AbstractSubject> SubjectSelectAllForDropdown();

    }
}
