using ODET.APICommon;
using ODET.Common;
using ODET.Entities.Contract;
using ODET.Entities.V1;
using ODET.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ODETApi.Controllers.V1
{
    public class CustomerV1Controller : AbstractBaseController
    {
        #region Fields        
        private readonly AbstractCustomerServices abstractCustomerServices;
        #endregion

        #region Cnstr
        public CustomerV1Controller(AbstractCustomerServices abstractCustomerServices)
        {
            this.abstractCustomerServices = abstractCustomerServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [InheritedRoute("CustomerUpsert")]
        public async Task<IHttpActionResult> CustomerUpsert([FromBody]Customer obj)
        {
            var result = abstractCustomerServices.CustomerUpsert(obj);
            return this.Content((HttpStatusCode)result.Code, result);
        }

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [InheritedRoute("CustomerByDeviceId")]
        public async Task<IHttpActionResult> CustomerByDeviceId(string DeviceId, string DeviceToken = "")
        {
            var result = abstractCustomerServices.CustomerByDeviceId(DeviceId, DeviceToken);
            return this.Content((HttpStatusCode)result.Code, result);
        }


        #endregion
    }
}