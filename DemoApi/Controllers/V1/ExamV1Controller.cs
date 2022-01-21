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
    public class ExamV1Controller : AbstractBaseController
    {
        #region Fields        
        private readonly AbstractExamServices abstractExamServices;
        #endregion

        #region Cnstr
        public ExamV1Controller(AbstractExamServices abstractExamServices)
        {
            this.abstractExamServices = abstractExamServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// GET Exams.
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [InheritedRoute("Exams")]
        public async Task<IHttpActionResult> Exams(string Key)
        {
            var result = abstractExamServices.ExamListByKey(Key);
            return this.Content(HttpStatusCode.OK, result);
        }
        
        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [InheritedRoute("Questions")]
        public async Task<IHttpActionResult> Questions(QuestionsAPIParam questionsAPIParam)
        {
            var result = abstractExamServices.QuestionsListAPI(questionsAPIParam);
            if(result.Item != null)
            {
                foreach (var item in result.Item.Questions)
                {
                    item.QuestionImage = Configurations.Exams3Url + item.QuestionImage + "" + item.QuestionKey + "Q.png";
                    item.AnswerImage = Configurations.Exams3Url + item.AnswerImage + "" + item.QuestionKey + "A.png";
                }
            }
            return this.Content(HttpStatusCode.OK, result);
        }

        #endregion
    }
}