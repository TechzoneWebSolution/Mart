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
    public abstract class AbstractSubScriptionServices : AbstractBaseService
    {
        public abstract PagedList<AbstractSubScription> SubscriptionAll(string Key);

        public abstract PagedList<AbstractSubScription> SubscriptionSelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractSubScription> SubScriptionUpsert(AbstractSubScription abstractSubScription);

        public abstract SuccessResult<AbstractSubScription> SubScriptionById(int Id);

    }
}
