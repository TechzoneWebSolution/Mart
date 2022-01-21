using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Services.Contract;

namespace Blog.Services.V1
{
    public class SubjectServices : AbstractSubjectServices
    {
        private AbstractSubjectDao abstractSubjectDao;

        public SubjectServices(AbstractSubjectDao abstractSubjectDao)
        {
            this.abstractSubjectDao = abstractSubjectDao;
        }

        public override SuccessResult<AbstractSubject> SubjectUpsert(AbstractSubject abstractSubject)
        {
            return this.abstractSubjectDao.SubjectUpsert(abstractSubject);
        }

        public override SuccessResult<AbstractSubject> SubjectById(int Id)
        {
            return this.abstractSubjectDao.SubjectById(Id);
        }
        public override PagedList<AbstractSubject> SubjectSelectAll(PageParam pageParam, string search, int StandardId = 0)
        {
            return this.abstractSubjectDao.SubjectSelectAll(pageParam, search, StandardId);
        }

        public override PagedList<AbstractSubject> SubjectSelectAllForDropdown()
        {
            return this.abstractSubjectDao.SubjectSelectAllForDropdown();
        }

    }
}
