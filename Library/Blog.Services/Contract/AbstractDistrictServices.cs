using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Services.Contract
{
    public abstract class AbstractDistrictServices : AbstractBaseService
    {
        public abstract PagedList<AbstractDistrict> DistrictSelectAllForDropdown(int StateId);

        public abstract PagedList<AbstractDistrict> DistrictSelectAllByStateId(PageParam pageParam, string search, int StateId);

        public abstract SuccessResult<AbstractDistrict> DistrictById(int id);

        public abstract SuccessResult<AbstractDistrict> DistrictUpsert(AbstractDistrict abstractDistrict);

        public abstract bool DistrictDelete(int id, int DeletedBy);
    }
}
