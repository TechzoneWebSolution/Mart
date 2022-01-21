using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;

namespace Blog.Entities.Contract
{
   public abstract class AbstractDistrict : BaseModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public string StateName { get; set; }

    }
}
