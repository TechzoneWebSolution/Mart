using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractUser : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int TalukaId { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string TalukaName { get; set; }
    }
}
