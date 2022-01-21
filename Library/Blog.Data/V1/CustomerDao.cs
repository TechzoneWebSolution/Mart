using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Entities.V1;

namespace Blog.Data.V1
{
    public class CustomerDao : AbstractCustomerDao
    {
        public override SuccessResult<AbstractCustomer> CustomerUpsert(AbstractCustomer abstractCustomer)
        {
            SuccessResult<AbstractCustomer> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractCustomer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractCustomer.FirstName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractCustomer.LastName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractCustomer.Email, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Mobile", abstractCustomer.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SchoolName", abstractCustomer.SchoolName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@City", abstractCustomer.City, DbType.String, direction: ParameterDirection.Input);
            param.Add("@GroupName", abstractCustomer.GroupName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@CustomerType", abstractCustomer.CustomerType, DbType.String, direction: ParameterDirection.Input);
            param.Add("@DeviceId", abstractCustomer.DeviceId, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Standard", abstractCustomer.Standard, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Stream", abstractCustomer.Stream, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@IsBlog", abstractCustomer.IsBlog, DbType.Boolean, direction: ParameterDirection.Input);
            param.Add("@AppVersion", abstractCustomer.AppVersion, DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExpiryDate", abstractCustomer.ExpiryDate, DbType.String, direction: ParameterDirection.Input);
            param.Add("@DeviceToken", abstractCustomer.DeviceToken, DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerUpsert, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                users.Item = task.Read<Customer>().SingleOrDefault();
            }

            return users;
        }

        public override SuccessResult<AbstractCustomer> CustomerByDeviceId(string DeviceId,string DeviceToken = "")
        {
            SuccessResult<AbstractCustomer> users = null;
            var param = new DynamicParameters();
            param.Add("@DeviceId", DeviceId, DbType.String, direction: ParameterDirection.Input);
            param.Add("@DeviceToken", DeviceToken, DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerByDeviceId, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                users.Item = task.Read<Customer>().SingleOrDefault();
            }
            return users;
        }

        public override PagedList<AbstractCustomer> CustomerSelectAll(PageParam pageParam, string search, string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "",string SchoolName="")
        {
            PagedList<AbstractCustomer> classes = new PagedList<AbstractCustomer>();
            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StartDate", StartDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@EndDate", EndDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StandardId", StandardId, dbType: DbType.Int16, direction: ParameterDirection.Input);
            param.Add("@IsBlock", IsBlock, dbType: DbType.Int16, direction: ParameterDirection.Input);
            param.Add("@IsBlog", IsBlog, dbType: DbType.Int16, direction: ParameterDirection.Input);
            param.Add("@GroupName", GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Type", Type, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@City", City, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExpiryStartDate", ExpiryStartDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ExpiryEndDate", ExpiryEndDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SchoolName", SchoolName, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Customer>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool CustomerActiveInActive(int Id)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.CustomerActiveInActive, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }
            return isUpdate;
        }

        public override bool CustomerDelete(int Id)
        {
            bool isUpdate = false;
            var param = new DynamicParameters();
            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.CustomerDelete, param, commandType: CommandType.StoredProcedure);
                isUpdate = task.SingleOrDefault<bool>();
            }

            return isUpdate;
        }

        public override SuccessResult<AbstractCustomer> CustomerUpdateWebSide(AbstractCustomer abstractCustomer)
        {
            SuccessResult<AbstractCustomer> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractCustomer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractCustomer.FirstName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractCustomer.LastName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractCustomer.Email, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Mobile", abstractCustomer.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@SchoolName", abstractCustomer.SchoolName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@City", abstractCustomer.City, DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerUpdateWebSide, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                users.Item = task.Read<Customer>().SingleOrDefault();
            }
            return users;
        }

        public override SuccessResult<AbstractCustomer> CustomerById(int Id)
        {
            SuccessResult<AbstractCustomer> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", Id, DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractCustomer>>().SingleOrDefault();
                users.Item = task.Read<Customer>().SingleOrDefault();
            }
            return users;
        }

        public override PagedList<AbstractCustomer> CustomerSelectAllForNotification(string Ids="")
        {
            PagedList<AbstractCustomer> classes = new PagedList<AbstractCustomer>();
            var param = new DynamicParameters();
            param.Add("@Ids", Ids, DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.CustomerSelectAllForNotification, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Customer>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

    }
}
