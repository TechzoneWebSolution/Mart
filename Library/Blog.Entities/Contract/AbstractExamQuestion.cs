using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Contract
{
    public abstract class AbstractExamQuestion : BaseModel
    {
        public int Id { get; set; }
        public string QuestionKey { get; set; }
        public string QuestionImage { get; set; }
        public string AnswerImage { get; set; }
        public string AnswerOptions { get; set; }
        public string CorrectAnswer { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ExamKey { get; set; }
        public string ExamSubjectKey { get; set; }
        public string ExamChapterKey { get; set; }
        public string ExamName { get; set; }
        public string SubjectName { get; set; }
        public string ChapterName { get; set; }
    }
}
