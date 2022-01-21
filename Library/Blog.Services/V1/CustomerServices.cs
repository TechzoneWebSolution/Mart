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
    public class CustomerServices : AbstractCustomerServices
    {
        private AbstractCustomerDao abstractCustomerDao;

        public CustomerServices (AbstractCustomerDao abstractCustomerDao)
        {
            this.abstractCustomerDao = abstractCustomerDao;
        }

        public override SuccessResult<AbstractCustomer> CustomerUpsert(AbstractCustomer abstractCustomer)
        {
            return this.abstractCustomerDao.CustomerUpsert(abstractCustomer);
        }

        public override SuccessResult<AbstractCustomer> CustomerByDeviceId(string DeviceId, string DeviceToken = "")
        {
            return this.abstractCustomerDao.CustomerByDeviceId(DeviceId,DeviceToken);
        }

        public override PagedList<AbstractCustomer> CustomerSelectAll(PageParam pageParam, string search, string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "", string SchoolName = "")
        {
            return this.abstractCustomerDao.CustomerSelectAll(pageParam, search,StartDate,EndDate, StandardId, IsBlock,IsBlog,GroupName,Type,City,ExpiryStartDate,ExpiryEndDate,SchoolName);
        }

        public override bool CustomerActiveInActive(int Id)
        {
            return this.abstractCustomerDao.CustomerActiveInActive(Id);
        }

        public override bool CustomerDelete(int Id)
        {
            return this.abstractCustomerDao.CustomerDelete(Id);
        }

        public override SuccessResult<AbstractCustomer> CustomerUpdateWebSide(AbstractCustomer abstractCustomer)
        {
            return this.abstractCustomerDao.CustomerUpdateWebSide(abstractCustomer);
        }
        public override SuccessResult<AbstractCustomer> CustomerById(int Id)
        {
            return this.abstractCustomerDao.CustomerById(Id);
        }
        public override PagedList<AbstractCustomer> CustomerSelectAllForNotification(string Ids = "")
        {
            return this.abstractCustomerDao.CustomerSelectAllForNotification(Ids);
        }
    }
}
