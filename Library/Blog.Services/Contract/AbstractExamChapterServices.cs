using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Services.Contract
{
    public abstract class AbstractExamChapterServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractExamChapter> ExamChapterUpsert(AbstractExamChapter abstractExamChapter);

        public abstract PagedList<AbstractExamChapter> ExamChapterSelectAll(PageParam pageParam, string search,string SubjectKey="");

        public abstract bool ExamChapterDelete(string ChapterKey, string SubjectKey);

        public abstract SuccessResult<AbstractExamChapter> ExamChapterById(string ChapterKey, string SubjectKey);
    }
}
