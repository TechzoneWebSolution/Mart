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
    public abstract class AbstractProductTypeServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractProductType> ProductTypeUpsert(AbstractProductType abstractProductType);

        public abstract PagedList<AbstractProductType> ProductTypeSelectAll(PageParam pageParam, string search);

        public abstract bool ProductTypeDelete(int Id);

        public abstract SuccessResult<AbstractProductType> ProductTypeById(int Id);

        //public abstract SuccessResult<ExamList> ExamListByKey(string Key);

        //public abstract SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam);
    }
}
