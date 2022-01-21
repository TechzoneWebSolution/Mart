using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;
using System.Collections.Generic;
using System.Web;

namespace Blog.Services.Contract
{
    public abstract class AbstractStandardServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractStandard> StandardById(int Id);

        public abstract PagedList<AbstractStandard> StandardSelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractStandard> InsertUpdateStandards(AbstractStandard abstractStandard, IEnumerable<HttpPostedFileBase> news_Json, IEnumerable<HttpPostedFileBase> Live_Json = null, IEnumerable<HttpPostedFileBase> Blog_Json = null);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDate(string Key, string Date = "");

        public abstract bool StandardBannerJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> Banner_json = null);

        public abstract bool StandardHomeScrrenJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> HomeScreen_json = null);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForHomeScreenJson(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForBannerJson(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByKeyLetestVersion(string Key);

        public abstract bool StandardOtherAppDataJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> OtherAppData_JSON = null);

        public abstract bool StandardCompetativeExamsJsonUpdate(int StandardId, IEnumerable<HttpPostedFileBase> CompetativeExams_JSON = null);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForOtherAppData(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForCompetativeExams(string Key, string Date = "");

        public abstract bool StandardOtherPDFMeterialUpdate(int StandardId, IEnumerable<HttpPostedFileBase> OtherPDFMeterialFile = null);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForOtherPDFMeterial(string Key, string Date = "");


    }
}
