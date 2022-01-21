using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractSubScription : BaseModel
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; }
        public string Description { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal OfferPrice { get; set; }
        public string ExpiryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsActive { get; set; }
        public int StandardId { get; set; }
        public int NoOfDays { get; set; }
        public string StandardName { get; set; }
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectIds { get; set; }
        public string Key { get; set; }


    }
}
