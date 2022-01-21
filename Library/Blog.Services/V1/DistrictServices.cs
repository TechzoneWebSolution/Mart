using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Services.Contract;

namespace Blog.Services.V1
{
    public class DistrictServices : AbstractDistrictServices
    {
        private AbstractDistrictDao abstractDistrictDao;

        public DistrictServices(AbstractDistrictDao abstractDistrictDao)
        {
            this.abstractDistrictDao = abstractDistrictDao;
        }
        
        public override PagedList<AbstractDistrict> DistrictSelectAllForDropdown(int StateId)
        {
            return this.abstractDistrictDao.DistrictSelectAllForDropdown(StateId);
        }

        public override PagedList<AbstractDistrict> DistrictSelectAllByStateId(PageParam pageParam, string search, int StateId)
        {
            return this.abstractDistrictDao.DistrictSelectAllByStateId(pageParam, search,StateId);
        }

        public override SuccessResult<AbstractDistrict> DistrictById(int id)
        {
            return this.abstractDistrictDao.DistrictById(id);
        }

        public override SuccessResult<AbstractDistrict> DistrictUpsert(AbstractDistrict abstractDistrict)
        {
            return this.abstractDistrictDao.DistrictUpsert(abstractDistrict);
        }

        public override bool DistrictDelete(int id, int DeletedBy)
        {
            return this.abstractDistrictDao.DistrictDelete(id, DeletedBy);
        }
    }
}
