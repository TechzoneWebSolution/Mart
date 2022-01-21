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
    public class OrderPaymentServices : AbstractOrderPaymentServices
    {
        private AbstractOrderPaymentDao abstractOrderPaymentDao;

        public OrderPaymentServices(AbstractOrderPaymentDao abstractOrderPaymentDao)
        {
            this.abstractOrderPaymentDao = abstractOrderPaymentDao;
        }

        //public override SuccessResult<AbstractOrderDetails> OrderDetailsUpsert(AbstractOrderDetails abstractOrderDetails)
        //{
        //    return this.abstractOrderDetailsDao.OrderDetailsUpsert(abstractOrderDetails);
        //}
        
    }
}
