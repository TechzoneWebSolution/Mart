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
    public class SubjectDao : AbstractSubjectDao
    {
        public override SuccessResult<AbstractSubject> SubjectUpsert(AbstractSubject abstractSubject)
        {
            SuccessResult<AbstractSubject> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", abstractSubject.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StandardId", abstractSubject.StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", abstractSubject.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubjectUpsert, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractSubject>>().SingleOrDefault();
                users.Item = task.Read<Subject>().SingleOrDefault();
            }

            return users;
        }

        public override SuccessResult<AbstractSubject> SubjectById(int Id)
        {
            SuccessResult<AbstractSubject> users = null;
            var param = new DynamicParameters();
            param.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubjectById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractSubject>>().SingleOrDefault();
                users.Item = task.Read<Subject>().SingleOrDefault();
            }
            return users;
        }

        public override PagedList<AbstractSubject> SubjectSelectAll(PageParam pageParam, string search, int StandardId = 0)
        {
            PagedList<AbstractSubject> classes = new PagedList<AbstractSubject>();
            var param = new DynamicParameters();

            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@StandardId", StandardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubjectSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Subject>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }
        public override PagedList<AbstractSubject> SubjectSelectAllForDropdown()
        {
            PagedList<AbstractSubject> classes = new PagedList<AbstractSubject>();
            var param = new DynamicParameters();
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.SubjectSelectAllForDropdown, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Subject>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }
    }
}
