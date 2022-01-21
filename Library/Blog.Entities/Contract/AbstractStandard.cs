using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractStandard : BaseModel
    {
        public int Id { get; set; }
        public int StandardId { get; set; }
        public int StandardId2 { get; set; }
        public int StandardId3 { get; set; }
        public int StandardId4 { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Live_json { get; set; }
        public string Blog_json { get; set; }
        public string News_json { get; set; }
        public string Banner_json { get; set; }
        public string HomeScreen_json { get; set; }
        public string Date { get; set; }
        public string Banner_Date { get; set; }
        public string HomeScreen_Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string BlogVersion { get; set; }
        public string LiveVersion { get; set; }
        public string OtherAppData { get; set; }
        public string OtherAppDataDate { get; set; }
        public string CompetativeExams { get; set; }
        public string CompetativeExamsDate { get; set; }
        public string OtherPDFMeterial { get; set; }
        public string OtherPDFMeterialDate { get; set; }
        [NotMapped]
        public string AvatarFolder { get; set; }
        [NotMapped]
        public string Path { get; set; }
        [NotMapped]
        public string DocumentPath { get; set; }
    }
}
