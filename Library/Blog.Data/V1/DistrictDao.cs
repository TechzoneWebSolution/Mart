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
    public class DistrictDao : AbstractDistrictDao
    {
        public override PagedList<AbstractDistrict> DistrictSelectAllForDropdown(int StateId)
        {
            PagedList<AbstractDistrict> classes = new PagedList<AbstractDistrict>();
            var param = new DynamicParameters();
            param.Add("@StateId", StateId, dbType: DbType.String, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DistrictSelectAllForDropdown, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<District>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override PagedList<AbstractDistrict> DistrictSelectAllByStateId(PageParam pageParam, string search,int StateId)
        {
            PagedList<AbstractDistrict> classes = new PagedList<AbstractDistrict>();

            var param = new DynamicParameters();
            param.Add("@StateId", StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DistrictSelectAllByStateId, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<District>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractDistrict> DistrictById(int id)
        {
            SuccessResult<AbstractDistrict> District = null;
            var param = new DynamicParameters();
            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DistrictById, param, commandType: CommandType.StoredProcedure);
                District = task.Read<SuccessResult<AbstractDistrict>>().SingleOrDefault();
                District.Item = task.Read<District>().SingleOrDefault();
            }
            return District;
        }

        public override SuccessResult<AbstractDistrict> DistrictUpsert(AbstractDistrict abstractDistrict)
        {
            SuccessResult<AbstractDistrict> District = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractDistrict.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractDistrict.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", abstractDistrict.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            if (abstractDistrict.Id > 0)
            {
                param.Add("@ModifiedBy", abstractDistrict.ModifiedBy, DbType.Int32, direction: ParameterDirection.Input);
            }
            else
            {
                param.Add("@CreatedBy", abstractDistrict.CreatedBy, DbType.Int32, direction: ParameterDirection.Input);
            }
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.DistrictUpsert, param, commandType: CommandType.StoredProcedure);
                District = task.Read<SuccessResult<AbstractDistrict>>().SingleOrDefault();
                District.Item = task.Read<District>().SingleOrDefault();
            }

            return District;
        }

        public override bool DistrictDelete(int id, int DeletedBy)
        {
            bool isDelete = false;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UserId", DeletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.DistrictDelete, param, commandType: CommandType.StoredProcedure);
                isDelete = task.SingleOrDefault<bool>();
            }

            return isDelete;
        }
    }
}
