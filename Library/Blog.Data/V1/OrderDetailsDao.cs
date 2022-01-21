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
    public class OrderDetailsDao : AbstractOrderDetailsDao
    {
        public override SuccessResult<AbstractOrderDetails> OrderDetailsUpsert(AbstractOrderDetails abstractOrderDetails)
        {
            SuccessResult<AbstractOrderDetails> users = null;
            var param = new DynamicParameters();
            param.Add("@CustomerId", abstractOrderDetails.CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@SubscriptionId", abstractOrderDetails.SubscriptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderDetailsUpsert, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractOrderDetails>>().SingleOrDefault();
                users.Item = task.Read<OrderDetails>().SingleOrDefault();
            }
            return users;
        }

        public override SuccessResult<AbstractOrderDetails> OrderStatusUpdate(int OrderId,string Status,string RazorpayPaymentId = "",string RazorpaySignature = "")
        {
            SuccessResult<AbstractOrderDetails> users = null;
            var param = new DynamicParameters();
            param.Add("@OrderId", OrderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Status", Status, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@RazorpayPaymentId", RazorpayPaymentId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@RazorpaySignature", RazorpaySignature, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderStatusUpdate, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractOrderDetails>>().SingleOrDefault();
                users.Item = task.Read<OrderDetails>().SingleOrDefault();
            }
            return users;
        }

        public override SuccessResult<AbstractOrderDetails> OrderDetailsById(int OrderId)
        {
            SuccessResult<AbstractOrderDetails> users = null;
            var param = new DynamicParameters();
            param.Add("@OrderId", OrderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderDetailsById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractOrderDetails>>().SingleOrDefault();
                users.Item = task.Read<OrderDetails>().SingleOrDefault();
            }
            return users;
        }

        public override PagedList<AbstractOrderDetails> OrderDetailsByCustomer(int CustomerId)
        {
            PagedList<AbstractOrderDetails> classes = new PagedList<AbstractOrderDetails>();
            var param = new DynamicParameters();
            param.Add("@CustomerId", CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderDetailsByCustomer, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<OrderDetails>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override PagedList<AbstractOrderDetails> OrderDetailsByCustomerWeb(PageParam pageParam, int CustomerId,string Search="")
        {
            PagedList<AbstractOrderDetails> classes = new PagedList<AbstractOrderDetails>();
            var param = new DynamicParameters();
            param.Add("@Search", Search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CustomerId", CustomerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderDetailsByCustomerWeb, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<OrderDetails>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractOrderDetails> OrderDetailsUpdateSignaturePaymentId(int OrderId,string RazorpayOrderID)
        {
            SuccessResult<AbstractOrderDetails> users = null;
            var param = new DynamicParameters();
            param.Add("@OrderId", OrderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@RazorpayOrderID", RazorpayOrderID, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.OrderDetailsUpdateSignaturePaymentId, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractOrderDetails>>().SingleOrDefault();
                users.Item = task.Read<OrderDetails>().SingleOrDefault();
            }
            return users;
        }

    }
}
