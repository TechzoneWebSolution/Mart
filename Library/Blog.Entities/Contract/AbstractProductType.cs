using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Entities.Contract
{
    public abstract class AbstractProductType : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
