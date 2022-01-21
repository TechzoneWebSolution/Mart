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
   public abstract class AbstractStateDao : AbstractBaseDao
    {
        public abstract PagedList<AbstractState> StateSelectAllForDropdown();

        public abstract PagedList<AbstractState> StateSelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractState> StateById(int id);

        public abstract SuccessResult<AbstractState> StateUpsert(AbstractState abstractState);

        public abstract bool StateDelete(int id, int DeletedBy);


    }
}
