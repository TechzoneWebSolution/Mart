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
    public abstract class AbstractExam : BaseModel
    {
        public int Id { get; set; }
        public string ExamKey { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int IsSubject { get; set; }
        public bool IsSubjectCheckBox { get; set; }
        public string CorrectAnswerMark { get; set; }
        public string WrongAnswerMark { get; set; }
        public string ExamFormats { get; set; }
        public string PracticeFormat { get; set; }
        public string ExamViewNTA { get; set; }
        public bool ExamViewNTACheckBox { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string QuestionTime { get; set; }
        public IEnumerable<HttpPostedFileBase> ExcelFile { get; set; }
        public List<AbstractExamSubject> Subjects { get; set; }
    }

    public class ExportExcel
    {
        public string SubjectKey { get; set; }
        public string SubjectName { get; set; }
        public string ChapterKey { get; set; }
        public string ChapterName { get; set; }
        public string QuestionKey { get; set; }
        public string QuestionImage { get; set; }
        public string AnswerOption { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class ExamList
    {
        public List<AbstractExam> Exams { get; set; }
    }
    public class QuestionList
    {
        public List<AbstractExamQuestion> Questions { get; set; }
    }

    public class QuestionsAPIParam
    {
        public string Key { get; set; }
        public int ExamId { get; set; }
        public string SubjectKey { get; set; }
        public List<string> ChapterKeys { get; set; }
        public int ExamFormat { get; set; }
    }
}
