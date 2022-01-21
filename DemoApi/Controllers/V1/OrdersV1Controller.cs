using ODET.APICommon;
using ODET.Common;
using ODET.Entities.Contract;
using ODET.Entities.V1;
using ODET.Services.Contract;
using Razorpay.Api;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ODETApi.Controllers.V1
{
    public class OrdersV1Controller : AbstractBaseController
    {
        #region Fields        
        private readonly AbstractOrderDetailsServices abstractOrderDetailsServices;
        #endregion

        #region Cnstr
        public OrdersV1Controller(AbstractOrderDetailsServices abstractOrderDetailsServices)
        {
            this.abstractOrderDetailsServices = abstractOrderDetailsServices;
        }
        #endregion

        #region Orders
        [System.Web.Http.HttpPost]
        [InheritedRoute("AddOrder")]
        public async Task<IHttpActionResult> AddOrder(int CustomerId, int SubscriptionId)
        {
            AbstractOrderDetails abstractOrderDetails = new OrderDetails();
            abstractOrderDetails.CustomerId = CustomerId;
            abstractOrderDetails.SubscriptionId = SubscriptionId;
            var order = abstractOrderDetailsServices.OrderDetailsUpsert(abstractOrderDetails);

            if (order.Code == 200)
            {
                if (order.Item != null)
                {
                    if (order.Item.Id > 0 && order.Item.OfferPrice > 0)
                    {
                        Dictionary<string, object> options = new Dictionary<string, object>();
                        options.Add("amount", ConvertTo.String(order.Item.OfferPrice).Replace(".", ""));  // amount in the smallest currency unit
                        options.Add("receipt", "order_rcptid_" + order.Item.Id.ToString());
                        options.Add("currency", "INR");
                        RazorpayClient client = new RazorpayClient(Configurations.RazorKey, Configurations.RazorSecret);
                        Razorpay.Api.Order razorpayOrder = client.Order.Create(options);
                        order.Item.RazorpayOrderID = razorpayOrder["id"].ToString();
                        var modal = abstractOrderDetailsServices.OrderDetailsUpdateSignaturePaymentId(order.Item.Id, order.Item.RazorpayOrderID);
                    }
                }
            }
            return this.Content(HttpStatusCode.OK, order);
        }

        [System.Web.Http.HttpGet]
        [InheritedRoute("OrderDetailsById")]
        public async Task<IHttpActionResult> OrderDetailsById(int OrderId)
        {
            var order = abstractOrderDetailsServices.OrderDetailsById(OrderId);
            return this.Content(HttpStatusCode.OK, order);
        }

        [System.Web.Http.HttpGet]
        [InheritedRoute("OrderDetailsByCustomer")]
        public async Task<IHttpActionResult> OrderDetailsByCustomer(int CustomerId)
        {
            var result = this.abstractOrderDetailsServices.OrderDetailsByCustomer(CustomerId);
            return this.Content(HttpStatusCode.OK, result);
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("OrderPaymentCheck")]
        public async Task<IHttpActionResult> OrderPaymentCheck(int OrderId, string RazorpayOrderID, string RazorpayPaymentId, string RazorpaySignature, string Status = "Success")
        {
            var order = abstractOrderDetailsServices.OrderDetailsById(OrderId);
            if (Status == "Success")
            {
                if (order.Item != null)
                {
                    if (order.Item.OfferPrice > 0)
                    {
                        Dictionary<string, object> input = new Dictionary<string, object>();
                        input.Add("amount", order.Item.OfferPrice);
                        RazorpayClient client = new RazorpayClient(Configurations.RazorKey, Configurations.RazorSecret);
                        Dictionary<string, string> attributes = new Dictionary<string, string>();
                        attributes.Add("razorpay_payment_id", RazorpayPaymentId);
                        attributes.Add("razorpay_order_id", RazorpayOrderID);
                        attributes.Add("razorpay_signature", RazorpaySignature);
                        Utils.verifyPaymentSignature(attributes);
                        Payment payment = client.Payment.Fetch(RazorpayPaymentId);
                        if (payment["status"].ToString() == "captured")
                        {
                            var modal = abstractOrderDetailsServices.OrderStatusUpdate(OrderId, Status, RazorpayPaymentId, RazorpaySignature);
                        }
                    }
                }
            }
            else
            {
                var modal = abstractOrderDetailsServices.OrderStatusUpdate(OrderId, Status, RazorpayPaymentId, RazorpaySignature);
            }
            return this.Content(HttpStatusCode.OK, order);
        }

        #endregion
    }
}
