using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;

namespace Blog.Services.Contract
{
    public abstract class AbstractProductsServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractProducts> ProductsUpsert(AbstractProducts abstractProducts);

        public abstract PagedList<AbstractProducts> ProductsSelectAll(PageParam pageParam, string search);

        public abstract bool ProductsDelete(int Id);

        public abstract SuccessResult<AbstractProducts> ProductsById(int Id);

        //public abstract SuccessResult<ExamList> ExamListByKey(string Key);

        //public abstract SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam);
    }
}
