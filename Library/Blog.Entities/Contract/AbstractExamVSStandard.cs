using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractExamVSStandard : BaseModel
    {
        public int Id { get; set; }
        public string StandardKey { get; set; }
        public string StandardName { get; set; }
        public string ExamKey { get; set; }
        public string ExamName { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
