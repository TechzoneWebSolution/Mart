//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="Dexoc Solutions">
//     Copyright Dexoc Solutions. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Blog.Data
{
    /// <summary>
    /// SQL configuration class which holds stored procedure name.
    /// </summary>
    internal sealed class SQLConfig
    {
        

        public const string UsersUpsert = "dbo.UsersUpsert";
        public const string UserById = "dbo.UserById";
        public const string CustomerUpsert = "dbo.CustomerUpsert";
        public const string CustomerByDeviceId = "dbo.CustomerByDeviceId";
        public const string SubscriptionAll = "dbo.SubscriptionAll";
        public const string UserLogin = "dbo.UserLogin";
        public const string CustomerSelectAll = "dbo.CustomerSelectAll";
        public const string SubscriptionSelectAll = "dbo.SubscriptionSelectAll";
        public const string StandardById = "dbo.StandardById";
        public const string StandardByIdByDate = "dbo.StandardByIdByDate";
        public const string StandardSelectAll = "dbo.StandardSelectAll";
        public const string StandardUpsert = "dbo.StandardUpsert";
        public const string SubjectById = "dbo.SubjectById";
        public const string SubjectUpsert = "dbo.SubjectUpsert";
        public const string SubjectSelectAll = "dbo.SubjectSelectAll";
        public const string SubScriptionUpsert = "dbo.SubScriptionUpsert";
        public const string SubjectSelectAllForDropdown = "dbo.SubjectSelectAllForDropdown";
        public const string SubScriptionById = "dbo.SubScriptionById";
        public const string CustomerActiveInActive = "dbo.CustomerActiveInActive";
        public const string OrderDetailsUpsert = "dbo.OrderDetailsUpsert";
        public const string OrderDetailsById = "dbo.OrderDetailsById";
        public const string OrderDetailsByCustomer = "dbo.OrderDetailsByCustomer";
        public const string OrderDetailsByCustomerWeb = "dbo.OrderDetailsByCustomerWeb";
        public const string OrderStatusUpdate = "dbo.OrderStatusUpdate";
        public const string CustomerDelete = "dbo.CustomerDelete";
        public const string OrderDetailsUpdateSignaturePaymentId = "dbo.OrderDetailsUpdateSignaturePaymentId";
        public const string CustomerUpdateWebSide = "dbo.CustomerUpdateWebSide";
        public const string CustomerById = "dbo.CustomerById";
        public const string StandardBannerJsonUpdate = "dbo.StandardBannerJsonUpdate";
        public const string StandardHomeScrrenJsonUpdate = "dbo.StandardHomeScrrenJsonUpdate";
        public const string StandardByIdByDateForHomeScreenJson = "dbo.StandardByIdByDateForHomeScreenJson";
        public const string StandardByIdByDateForBannerJson = "dbo.StandardByIdByDateForBannerJson";
        public const string StandardByKeyLetestVersion = "dbo.StandardByKeyLetestVersion";
        public const string CustomerSelectAllForNotification = "dbo.CustomerSelectAllForNotification";
        public const string StandardOtherAppDataJsonUpdate = "dbo.StandardOtherAppDataJsonUpdate";
        public const string StandardCompetativeExamsJsonUpdate = "dbo.StandardCompetativeExamsJsonUpdate";
        public const string StandardByIdByDateForOtherAppData = "dbo.StandardByIdByDateForOtherAppData";
        public const string StandardByIdByDateForCompetativeExams = "dbo.StandardByIdByDateForCompetativeExams";
        public const string ExamChapterById = "dbo.ExamChapterById";
        public const string ExamChapterUpsert = "dbo.ExamChapterUpsert";
        public const string ExamChapterSelectAll = "dbo.ExamChapterSelectAll";
        public const string ExamChapterDelete = "dbo.ExamChapterDelete";
        public const string ExamSubjectById = "dbo.ExamSubjectById";
        public const string ExamSubjectUpsert = "dbo.ExamSubjectUpsert";
        public const string ExamSubjectSelectAll = "dbo.ExamSubjectSelectAll";
        public const string ExamSubjectDelete = "dbo.ExamSubjectDelete";
        public const string ExamUpsert = "dbo.ExamUpsert";
        public const string ExamSelectAll = "dbo.ExamSelectAll";
        public const string ExamDelete = "dbo.ExamDelete";
        public const string ExamById = "dbo.ExamById";
        public const string ExamVSStandardUpsert = "dbo.ExamVSStandardUpsert";
        public const string ExamVSStandardSelectAll = "dbo.ExamVSStandardSelectAll";
        public const string ExamVSStandardDelete = "dbo.ExamVSStandardDelete";
        public const string ExamVSStandardById = "dbo.ExamVSStandardById";
        public const string ExamQuestionSelectAll = "dbo.ExamQuestionSelectAll";
        public const string ExamQuestionUpsert = "dbo.ExamQuestionUpsert";
        public const string ExamListByKey = "dbo.ExamListByKey";
        public const string QuestionsListAPI = "dbo.QuestionsListAPI";
        public const string ExamStandardSelectAll = "dbo.ExamStandardSelectAll";
        public const string ExamStandardUpsert = "dbo.ExamStandardUpsert";
        public const string ExamStandardDelete = "dbo.ExamStandardDelete";
        public const string ExamStandardById = "dbo.ExamStandardById";
        public const string StandardOtherPDFMeterialUpdate = "dbo.StandardOtherPDFMeterialUpdate";
        public const string StandardByIdByDateForOtherPDFMeterial = "dbo.StandardByIdByDateForOtherPDFMeterial";
        public const string QuestionDelete = "dbo.QuestionDelete";

        #region State
        public const string StateSelectAllForDropdown = "dbo.StateSelectAllForDropdown";
        public const string StateSelectAll = "dbo.StateSelectAll";
        public const string StateById = "dbo.StateById";
        public const string StateUpsert = "dbo.StateUpsert";
        public const string StateDelete = "dbo.StateDelete";
        #endregion

        #region District
        public const string DistrictSelectAllForDropdown = "dbo.DistrictSelectAllForDropdown";
        public const string DistrictSelectAllByStateId = "dbo.DistrictSelectAllByStateId";
        public const string DistrictById = "dbo.DistrictById";
        public const string DistrictUpsert = "dbo.DistrictUpsert";
        public const string DistrictDelete = "dbo.DistrictDelete";
        #endregion

        #region ProductType
        public const string ProductTypeUpsert = "dbo.ProductTypeUpsert";
        public const string ProductTypeSelectAll = "dbo.ProductTypeSelectAll";
        public const string ProductTypeDelete = "dbo.ProductTypeDelete";
        public const string ProductTypeById = "dbo.ProductTypeById";
        #endregion
        
        #region Products
        public const string ProductsUpsert = "dbo.ProductsUpsert";
        public const string ProductsSelectAll = "dbo.ProductsSelectAll";
        public const string ProductsDelete = "dbo.ProductsDelete";
        public const string ProductsById = "dbo.ProductsById";
        #endregion

        #region Product Stock Ledger
        public const string ProductStockLedgerUpsert = "dbo.ProductStockLedgerUpsert";
        public const string ProductStockLedgerSelectAllByProductId = "dbo.ProductStockLedgerSelectAllByProductId";
        public const string ProductStockLedgerDelete = "dbo.ProductStockLedgerDelete";
        public const string ProductStockLedgerById = "dbo.ProductStockLedgerById";
        #endregion

    }
}
