using ODET.APICommon;
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
    public class SubScriptionV1Controller : AbstractBaseController
    {
        #region Fields        
        private readonly AbstractSubScriptionServices abstractSubScriptionServices;
        #endregion

        #region Cnstr
        public SubScriptionV1Controller(AbstractSubScriptionServices abstractSubScriptionServices)
        {
            this.abstractSubScriptionServices = abstractSubScriptionServices;
        }
        #endregion

        #region eventattendees
        /// <summary>
        /// Get All Event Attendees
        /// </summary>
        /// <param name="Offset"></param>
        /// <param name="Limit"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [InheritedRoute("SubscriptionAll")]
        public async Task<IHttpActionResult> SubscriptionAll(string Key)
        {
            var eventattendees = abstractSubScriptionServices.SubscriptionAll(Key);
            return this.Content(HttpStatusCode.OK, eventattendees);
        } 
        #endregion
    }
}
