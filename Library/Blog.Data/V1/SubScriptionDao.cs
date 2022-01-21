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
    public class SubScriptionDao : AbstractSubScriptionDao
    {
        public override PagedList<AbstractSubScription> SubscriptionAll(string Key)
        {
            PagedList<AbstractSubScription> classes = new PagedList<AbstractSubScription>();
            var param = new DynamicParameters();

            param.Add("@Key", Key, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubscriptionAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<SubScription>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override PagedList<AbstractSubScription> SubscriptionSelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractSubScription> classes = new PagedList<AbstractSubScription>();
            var param = new DynamicParameters();

            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubscriptionSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<SubScription>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractSubScription> SubScriptionUpsert(AbstractSubScription abstractSubScription)
        {
            SuccessResult<AbstractSubScription> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractSubScription.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@SubjectId", abstractSubScription.SubjectId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@SubscriptionName", abstractSubScription.SubscriptionName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", abstractSubScription.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ActualPrice", abstractSubScription.ActualPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("@OfferPrice", abstractSubScription.OfferPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("@IsActive", abstractSubScription.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@NoOfDays", abstractSubScription.NoOfDays, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ExpiryDate", abstractSubScription.ExpiryDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Key", abstractSubScription.Key, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubScriptionUpsert, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractSubScription>>().SingleOrDefault();
                users.Item = task.Read<SubScription>().SingleOrDefault();
            }

            return users;
        }

        public override SuccessResult<AbstractSubScription> SubScriptionById(int Id)
        {
            SuccessResult<AbstractSubScription> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubScriptionById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractSubScription>>().SingleOrDefault();
                users.Item = task.Read<SubScription>().SingleOrDefault();
            }
            return users;
        }

    }
}
