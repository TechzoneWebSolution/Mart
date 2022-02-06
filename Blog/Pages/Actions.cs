using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Pages
{
    public class Actions
    {
        //Commin Actions

        #region Dashboard
        public const string Index = "Index";
        public const string Manage = "Manage";
        public const string Success = "Success";
        public const string ChangeStatus = "ChangeStatus";
        public const string Delete = "Delete";
        #endregion

        #region User
        public const string Profile = "Profile";
        public const string BindUser = "BindUser";
        public const string UserEdit = "UserEdit";
        #endregion


        #region Account
        public const string ResetPSW = "ResetPSW";
        public const string LogIn = "LogIn";
        public const string AdminUserResetPassword = "AdminUserResetPassword";
        public const string ForgotPassword = "ForgotPassword";
        public const string Logout = "Logout";
        public const string PrivacyPolicy = "PrivacyPolicy";
        public const string Register = "Register";
        public const string Search1 = "Search1";
        #endregion

        #region Order
        public const string BindOrder = "BindOrder";
        #endregion

        #region State
        public const string BindState = "BindState";
        public const string AddEditState = "AddEditState";
        public const string DeleteState = "DeleteState";
        #endregion

        #region District
        public const string BindDistrict = "BindDistrict";
        public const string AddEditDistrict = "AddEditDistrict";
        public const string DeleteDistrict = "DeleteDistrict";
        #endregion
        
        #region ProductType
        public const string BindProductType = "BindProductType";
        public const string AddEditProductType = "AddEditProductType";
        public const string DeleteProductType = "DeleteProductType";
        #endregion
        #region Products
        public const string BindProducts = "BindProducts";
        public const string AddEditProducts = "AddEditProducts";
        public const string DeleteProducts = "DeleteProducts";
        #endregion

        #region Product Stock Ledger
        public const string BindProductStockLedger = "BindProductStockLedger";
        public const string AddEditProductStockLedger = "AddEditProductStockLedger";
        public const string DeleteProductStockLedger = "DeleteProductStockLedger";
        #endregion
    }
}