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
    public class OrderDetailsServices : AbstractOrderDetailsServices
    {
        private AbstractOrderDetailsDao abstractOrderDetailsDao;

        public OrderDetailsServices(AbstractOrderDetailsDao abstractOrderDetailsDao)
        {
            this.abstractOrderDetailsDao = abstractOrderDetailsDao;
        }

        public override SuccessResult<AbstractOrderDetails> OrderDetailsUpsert(AbstractOrderDetails abstractOrderDetails)
        {
            return this.abstractOrderDetailsDao.OrderDetailsUpsert(abstractOrderDetails);
        }

        public override SuccessResult<AbstractOrderDetails> OrderStatusUpdate(int OrderId, string Status, string RazorpayPaymentId = "", string RazorpaySignature = "")
        {
            return this.abstractOrderDetailsDao.OrderStatusUpdate(OrderId, Status,RazorpayPaymentId,RazorpaySignature);
        }

        public override SuccessResult<AbstractOrderDetails> OrderDetailsById(int OrderId)
        {
            return this.abstractOrderDetailsDao.OrderDetailsById(OrderId);
        }

        public override PagedList<AbstractOrderDetails> OrderDetailsByCustomer(int CustomerId)
        {
            return this.abstractOrderDetailsDao.OrderDetailsByCustomer(CustomerId);
        }
        public override PagedList<AbstractOrderDetails> OrderDetailsByCustomerWeb(PageParam pageParam, int CustomerId, string Search = "")
        {
            return this.abstractOrderDetailsDao.OrderDetailsByCustomerWeb(pageParam,CustomerId, Search);
        }
        public override SuccessResult<AbstractOrderDetails> OrderDetailsUpdateSignaturePaymentId(int OrderId, string RazorpayOrderID)
        {
            return this.abstractOrderDetailsDao.OrderDetailsUpdateSignaturePaymentId(OrderId, RazorpayOrderID);
        }

    }
}
