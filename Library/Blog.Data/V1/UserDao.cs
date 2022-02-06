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
    public class UserDao : AbstractUserDao
    {
        public override SuccessResult<AbstractUser> Login(string Email, string Password)
        {
            SuccessResult<AbstractUser> users = null;
            var param = new DynamicParameters();

            param.Add("@UserName", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UserLogin, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUser>>().SingleOrDefault();
                users.Item = task.Read<User>().SingleOrDefault();
            }
            return users;
        }


        //public override SuccessResult<AbstractUsers> VerifyEmail(string email)
        //{
        //    SuccessResult<AbstractUsers> users = null;
        //    var param = new DynamicParameters();

        //    param.Add("@Email", email, dbType: DbType.String, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.VerifyEmail, param, commandType: CommandType.StoredProcedure);
        //        users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
        //        users.Item = task.Read<Users>().SingleOrDefault();
        //    }
        //    return users;
        //}

        ////public override int UserPasswordUpdate(AbstractUsers abstractUsers)
        ////{
        ////    int usersId = -1;
        ////    var param = new DynamicParameters();

        ////    param.Add("@Password", abstractUsers.Password, dbType: DbType.String, direction: ParameterDirection.Input);

        ////    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        ////    {
        ////        if (abstractUsers.Id > 0)
        ////        {
        ////            param.Add("@Id", abstractUsers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        ////            var task = con.Query<int>(SQLConfig.UserPasswordUpdate, param, commandType: CommandType.StoredProcedure);
        ////            usersId = task.SingleOrDefault<int>();
        ////        }
        ////    }
        ////    return usersId;
        ////}

        //public override PagedList<AbstractUsers> SelectAll(PageParam pageParam, string search)
        //{
        //    PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
        //    var param = new DynamicParameters();

        //    param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.UsersAll, param, commandType: CommandType.StoredProcedure);
        //        classes.Values.AddRange(task.Read<Users>());
        //        classes.TotalRecords = task.Read<long>().SingleOrDefault();
        //    }
        //    return classes;
        //}

        //public override PagedList<AbstractUsers> TopFiveUserFlatsSelectAll()
        //{
        //    PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
        //    var param = new DynamicParameters();

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.TopFiveUserFlatsSelectAll, param, commandType: CommandType.StoredProcedure);
        //        classes.Values.AddRange(task.Read<Users>());
        //        classes.TotalRecords = task.Read<long>().SingleOrDefault();
        //    }
        //    return classes;
        //}

        //public override PagedList<AbstractUsers> GetMembers(PageParam pageParam, string search)
        //{
        //    PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
        //    var param = new DynamicParameters();

        //    //param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.GetMembers, param, commandType: CommandType.StoredProcedure);
        //        classes.Values.AddRange(task.Read<Users>());
        //        classes.TotalRecords = task.Read<long>().SingleOrDefault();
        //    }
        //    return classes;
        //}

        public override SuccessResult<AbstractUser> UserById(int id)
        {
            SuccessResult<AbstractUser> users = null;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UserById, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUser>>().SingleOrDefault();
                users.Item = task.Read<User>().SingleOrDefault();
            }
            return users;
        }

        public override SuccessResult<AbstractUser> InsertUpdateUsers(AbstractUser abstractusers)
        {
            SuccessResult<AbstractUser> users = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractusers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractusers.FirstName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractusers.LastName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractusers.Email, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Mobile", abstractusers.Mobile, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractusers.Password, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Address", abstractusers.Address, DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", abstractusers.StateId, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DistrictId", abstractusers.DistrictId, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@UserType", abstractusers.UserType, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CreatedBy", abstractusers.CreatedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ModifiedBy", abstractusers.ModifiedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UsersUpsert, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUser>>().SingleOrDefault();
                users.Item = task.Read<User>().SingleOrDefault();
            }

            return users;
        }

        //public override SuccessResult<AbstractUsers> UsersChangePassword(AbstractUsers abstractusers)
        //{
        //    SuccessResult<AbstractUsers> users = null;
        //    var param = new DynamicParameters();

        //    param.Add("@Id", abstractusers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@Password", abstractusers.Password, DbType.String, direction: ParameterDirection.Input);
        //    param.Add("@Salt", abstractusers.Salt, DbType.String, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.UsersChangePassword, param, commandType: CommandType.StoredProcedure);
        //        users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
        //        users.Item = task.Read<Users>().SingleOrDefault();
        //    }

        //    return users;
        //}

        //public override bool Delete(int id)
        //{
        //    bool isDelete = false;
        //    var param = new DynamicParameters();

        //    param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.Query<bool>(SQLConfig.UsersDelete, param, commandType: CommandType.StoredProcedure);
        //        isDelete = task.SingleOrDefault<bool>();
        //    }

        //    return isDelete;
        //}

        ////public override PagedList<AbstractUsers> MenuSelectAll()
        ////{
        ////    PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
        ////    var param = new DynamicParameters();

        ////    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        ////    {
        ////        var task = con.QueryMultiple(SQLConfig.MenuSelectAll, param, commandType: CommandType.StoredProcedure);
        ////        classes.Values.AddRange(task.Read<Users>());
        ////        classes.TotalRecords = task.Read<long>().SingleOrDefault();
        ////    }
        ////    return classes;
        ////}

        //public override bool ChangeStatusByTableName(string Table, int Id)
        //{
        //    bool isDelete = false;
        //    var param = new DynamicParameters();
        //    param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    param.Add("@Table", Table, dbType: DbType.String, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.Query<bool>(SQLConfig.ChangeStatusByTableName, param, commandType: CommandType.StoredProcedure);
        //        isDelete = task.SingleOrDefault<bool>();
        //    }

        //    return isDelete;
        //}

        //public override PagedList<string> GetUsersDeviceToken()
        //{
        //    PagedList<string> users = new PagedList<string>();

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.GetUsersDeviceToken, null, commandType: CommandType.StoredProcedure);
        //        users.Values.AddRange(task.Read<string>());
        //    }

        //    return users;
        //}

        //public override SuccessResult<AbstractUsers> SelectChairman()
        //{
        //    SuccessResult<AbstractUsers> users = null;
        //    var param = new DynamicParameters();

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.SelectChairman, param, commandType: CommandType.StoredProcedure);
        //        users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
        //        users.Item = task.Read<Users>().SingleOrDefault();
        //    }
        //    return users;
        //}

        //public override PagedList<AbstractUsers> GetMembersByflatId(int flatid)
        //{
        //    PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
        //    var param = new DynamicParameters();
        //    param.Add("@FlatId", flatid, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.QueryMultiple(SQLConfig.GetMembersByflatId, param, commandType: CommandType.StoredProcedure);
        //        classes.Values.AddRange(task.Read<Users>());
        //        classes.TotalRecords = task.Read<long>().SingleOrDefault();
        //    }
        //    return classes;
        //}

    }
}
