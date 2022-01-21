using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ODET.APICommon;
using ODET.Common;
using ODET.Common.Paging;
using ODET.Entities.Contract;
using ODET.Entities.V1;
using ODET.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ODETApi.Controllers.V1
{
    public class StandardV1Controller : AbstractBaseController
    {
        #region Fields        
        private readonly AbstractStandardServices abstractStandardServices;
        #endregion

        #region Cnstr
        public StandardV1Controller(AbstractStandardServices abstractStandardServices)
        {
            this.abstractStandardServices = abstractStandardServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDate")]
        public async Task<IHttpActionResult> StandardByIdByDate([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDate(obj.Key, obj.Date);
            if(result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.Live_json))
                {
                    result.Item.Live_json = GeneratePreSignedURL(result.Item.Live_json);
                }
                else
                {
                    result.Item.Live_json = "";
                }
                if (!string.IsNullOrWhiteSpace(result.Item.Demo_json))
                {
                    result.Item.Demo_json = GeneratePreSignedURL(result.Item.Demo_json);
                }
                else
                {
                    result.Item.Demo_json = "";
                }
                if (!string.IsNullOrWhiteSpace(result.Item.News_json))
                {
                    result.Item.News_json = GeneratePreSignedURL(result.Item.News_json);
                }
                else
                {
                    result.Item.News_json = "";
                }
                if (string.IsNullOrWhiteSpace(result.Item.Date))
                {
                    result.Item.Live_json = "";
                }
            }
            
            return this.Content((HttpStatusCode)result.Code, result);
        }

        public virtual string GeneratePreSignedURL(string awsKey)
        {
            string urlString = "";
            try
            {
                using (IAmazonS3 client = new AmazonS3Client(Configurations.S3AccessKeyID, Configurations.S3SecretKey, RegionEndpoint.APSouth1))
                {
                    GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                    {
                        BucketName = Configurations.BucketName,
                        Key = awsKey,
                        Expires = DateTime.Now.AddMinutes(10)
                    };
                    urlString = client.GetPreSignedURL(request1);
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return urlString;
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDateForBannerJson")]
        public async Task<IHttpActionResult> StandardByIdByDateForBannerJson([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDateForBannerJson(obj.Key, obj.Date);
            if (result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.Banner_json))
                {
                    result.Item.Banner_json = GeneratePreSignedURL(result.Item.Banner_json);
                }
                else
                {
                    result.Item.Banner_json = "";
                }
            }

            return this.Content((HttpStatusCode)result.Code, result);
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDateForHomeScreenJson")]
        public async Task<IHttpActionResult> StandardByIdByDateForHomeScreenJson([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDateForHomeScreenJson(obj.Key, obj.Date);
            if (result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.HomeScreen_json))
                {
                    result.Item.HomeScreen_json = GeneratePreSignedURL(result.Item.HomeScreen_json);
                }
                else
                {
                    result.Item.HomeScreen_json = "";
                }
            }

            return this.Content((HttpStatusCode)result.Code, result);
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDateForOtherAppData")]
        public async Task<IHttpActionResult> StandardByIdByDateForOtherAppData([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDateForOtherAppData(obj.Key, obj.Date);
            if (result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.OtherAppData))
                {
                    result.Item.OtherAppData = GeneratePreSignedURL(result.Item.OtherAppData);
                }
                else
                {
                    result.Item.OtherAppData = "";
                }
            }

            return this.Content((HttpStatusCode)result.Code, result);
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDateForCompetativeExams")]
        public async Task<IHttpActionResult> StandardByIdByDateForCompetativeExams([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDateForCompetativeExams(obj.Key, obj.Date);
            if (result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.CompetativeExams))
                {
                    result.Item.CompetativeExams = GeneratePreSignedURL(result.Item.CompetativeExams);
                }
                else
                {
                    result.Item.CompetativeExams = "";
                }
            }

            return this.Content((HttpStatusCode)result.Code, result);
        }

        [System.Web.Http.HttpPost]
        [InheritedRoute("StandardByIdByDateForOtherPDFMeterial")]
        public async Task<IHttpActionResult> StandardByIdByDateForOtherPDFMeterial([FromBody]StandardByDate obj)
        {
            var result = abstractStandardServices.StandardByIdByDateForOtherPDFMeterial(obj.Key, obj.Date);
            if (result.Item != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Item.OtherPDFMeterial))
                {
                    result.Item.OtherPDFMeterial = GeneratePreSignedURL(result.Item.OtherPDFMeterial);
                }
                else
                {
                    result.Item.OtherPDFMeterial = "";
                }
            }

            return this.Content((HttpStatusCode)result.Code, result);
        }


        [System.Web.Http.HttpGet]
        [InheritedRoute("StandardByKeyLetestVersion")]
        public async Task<IHttpActionResult> StandardByKeyLetestVersion(string Key)
        {
            var result = abstractStandardServices.StandardByKeyLetestVersion(Key);
            return this.Content((HttpStatusCode)result.Code, result);
        }

        public class StandardByDate
        {
            public string Date { get; set; }
            public string Key { get; set; }
        }

        #endregion
    }
}
