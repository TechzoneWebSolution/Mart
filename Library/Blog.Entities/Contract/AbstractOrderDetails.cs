using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractOrderDetails : BaseModel
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int NoofDays { get; set; }
        public string ExpiryDate { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public int TransactionId { get; set; }
        public string Signature { get; set; }
        public string RazorpayOrderID { get; set; }
        public string CustomerName { get; set; }
    }
}
