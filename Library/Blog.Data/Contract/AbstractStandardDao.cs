using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Data.Contract
{
   public abstract class AbstractStandardDao : AbstractBaseDao
    {

        public abstract SuccessResult<AbstractStandard> StandardById(int Id);

        public abstract PagedList<AbstractStandard> StandardSelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractStandard> InsertUpdateStandards(AbstractStandard abstractStandard);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDate(string Key, string Date = "");

        public abstract bool StandardBannerJsonUpdate(int StandardId, string Banner_json);

        public abstract bool StandardHomeScrrenJsonUpdate(int StandardId, string HomeScreen_json);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForHomeScreenJson(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForBannerJson(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByKeyLetestVersion(string Key);

        public abstract bool StandardOtherAppDataJsonUpdate(int StandardId, string OtherAppDataJson);

        public abstract bool StandardCompetativeExamsJsonUpdate(int StandardId, string CompetativeExamsJson);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForOtherAppData(string Key, string Date = "");

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForCompetativeExams(string Key, string Date = "");

        public abstract bool StandardOtherPDFMeterialUpdate(int StandardId, string OtherPDFMeterial);

        public abstract SuccessResult<AbstractStandard> StandardByIdByDateForOtherPDFMeterial(string Key, string Date = "");


    }
}
