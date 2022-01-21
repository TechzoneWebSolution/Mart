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
    public class StateDao : AbstractStateDao
    {
        public override PagedList<AbstractState> StateSelectAllForDropdown()
        {
            PagedList<AbstractState> classes = new PagedList<AbstractState>();
            var param = new DynamicParameters();
            //param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StateSelectAllForDropdown, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<State>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override PagedList<AbstractState> StateSelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractState> classes = new PagedList<AbstractState>();

            var param = new DynamicParameters();
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StateSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<State>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractState> StateById(int id)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();
            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StateById, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }
            return State;
        }

        public override SuccessResult<AbstractState> StateUpsert(AbstractState abstractState)
        {
            SuccessResult<AbstractState> State = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractState.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractState.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            if (abstractState.Id > 0)
            {
                param.Add("@ModifiedBy", abstractState.ModifiedBy, DbType.Int32, direction: ParameterDirection.Input);
            }
            else
            {
                param.Add("@CreatedBy", abstractState.CreatedBy, DbType.Int32, direction: ParameterDirection.Input);
            }
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.StateUpsert, param, commandType: CommandType.StoredProcedure);
                State = task.Read<SuccessResult<AbstractState>>().SingleOrDefault();
                State.Item = task.Read<State>().SingleOrDefault();
            }

            return State;
        }

        public override bool StateDelete(int id,int DeletedBy)
        {
            bool isDelete = false;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UserId", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.StateDelete, param, commandType: CommandType.StoredProcedure);
                isDelete = task.SingleOrDefault<bool>();
            }

            return isDelete;
        }

    }
}
