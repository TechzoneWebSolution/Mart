using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractSubject : BaseModel
    {
        public int Id { get; set; }
        public int StandardId { get; set; }
        public string Name { get; set; }
        public string StandardName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
