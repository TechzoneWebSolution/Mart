using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Services.Contract
{
    public abstract class AbstractStateServices : AbstractBaseService
    {
        public abstract PagedList<AbstractState> StateSelectAllForDropdown();

        public abstract PagedList<AbstractState> StateSelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractState> StateById(int id);

        public abstract SuccessResult<AbstractState> StateUpsert(AbstractState abstractState);

        public abstract bool StateDelete(int id, int DeletedBy);
    }
}
