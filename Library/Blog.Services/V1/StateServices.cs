using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Services.Contract;

namespace Blog.Services.V1
{
    public class StateServices : AbstractStateServices
    {
        private AbstractStateDao abstractStateDao;

        public StateServices(AbstractStateDao abstractStateDao)
        {
            this.abstractStateDao = abstractStateDao;
        }
        
        public override PagedList<AbstractState> StateSelectAllForDropdown()
        {
            return this.abstractStateDao.StateSelectAllForDropdown();
        }

        public override PagedList<AbstractState> StateSelectAll(PageParam pageParam, string search)
        {
            return this.abstractStateDao.StateSelectAll(pageParam, search);
        }

        public override SuccessResult<AbstractState> StateById(int id)
        {
            return this.abstractStateDao.StateById(id);
        }

        public override SuccessResult<AbstractState> StateUpsert(AbstractState abstractState)
        {
            return this.abstractStateDao.StateUpsert(abstractState);
        }

        public override bool StateDelete(int id, int DeletedBy)
        {
            return this.abstractStateDao.StateDelete(id, DeletedBy);
        }
    }
}
