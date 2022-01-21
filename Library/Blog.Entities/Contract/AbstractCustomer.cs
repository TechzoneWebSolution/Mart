using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractCustomer : BaseModel
    {
        public int Id { get; set; }
        public int SequenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string GroupName { get; set; }
        public string CustomerType { get; set; }
        public string DeviceId { get; set; }
        public string DeviceToken { get; set; }
        public string Standard { get; set; }
        public int StandardId { get; set; }
        public string StandardKey { get; set; }
        public string StandardName { get; set; }
        public string Stream { get; set; }
        public bool IsBlog { get; set; }
        public string AppVersion { get; set; }
        public string ExpiryDate { get; set; }
        public bool IsBlock { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
