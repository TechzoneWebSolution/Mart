using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractExamStandard : BaseModel
    {
        public int Id { get; set; }
        public string StandardKey { get; set; }
        public string Name { get; set; }
    }
}
