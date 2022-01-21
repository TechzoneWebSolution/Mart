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

        #region Customers
        public const string BindCustomers = "BindCustomers";
        public const string CustomerEdit = "CustomerEdit";
        public const string SendNotification = "SendNotification";
        public const string SendNotificationForAllCustomer = "SendNotificationForAllCustomer";
        #endregion

        #region SubScription
        public const string BindSubScription = "BindSubScription";
        public const string SubScriptionAddEdit = "SubScriptionAddEdit";
        #endregion

        #region Account
        public const string ResetPSW = "ResetPSW";
        public const string LogIn = "LogIn";
        public const string AdminUserResetPassword = "AdminUserResetPassword";
        public const string ForgotPassword = "ForgotPassword";
        public const string Logout = "Logout";
        public const string PrivacyPolicy = "PrivacyPolicy";
        public const string Register = "Register";
        #endregion

        #region Standard
        public const string BindStandard = "BindStandard";
        public const string StandardAddEdit = "StandardAddEdit";
        public const string Banner_json = "Banner_json";
        public const string HomeScreen_json = "HomeScreen_json";
        public const string StandardOtherAppDataJsonUpdate = "StandardOtherAppDataJsonUpdate";
        public const string StandardCompetativeExamsJsonUpdate = "StandardCompetativeExamsJsonUpdate";
        public const string StandardOtherPDFMeterialUpdate = "StandardOtherPDFMeterialUpdate";
        #endregion

        #region Subject
        public const string BindSubject = "BindSubject";
        public const string SubjectAddEdit = "SubjectAddEdit";
        #endregion

        #region Order
        public const string BindOrder = "BindOrder";
        #endregion

        #region ExamChapter
        public const string BindExamChapter = "BindExamChapter";
        public const string ExamChapterAddEdit = "ExamChapterAddEdit";
        #endregion
        #region ExamSubject
        public const string BindExamSubject = "BindExamSubject";
        public const string ExamSubjectAddEdit = "ExamSubjectAddEdit";
        #endregion
        #region Exam
        public const string BindExam = "BindExam";
        public const string ExamAddEdit = "ExamAddEdit";
        #endregion
        #region ExamVSStandard
        public const string BindExamVSStandard = "BindExamVSStandard";
        public const string ExamVSStandardAddEdit = "ExamVSStandardAddEdit";
        #endregion

        #region ExamStandard
        public const string BindExamStandard = "BindExamStandard";
        public const string ExamStandardAddEdit = "ExamStandardAddEdit";
        #endregion

        #region ExamQuestion
        public const string BindExamQuestion = "BindExamQuestion";
        public const string Search1 = "Search1";
        public const string Search2 = "Search2";
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