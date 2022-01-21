using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Data.Contract;
using Blog.Entities.Contract;
using Blog.Services.Contract;

namespace Blog.Services.V1
{
    public class ProductTypeServices : AbstractProductTypeServices
    {
        private AbstractProductTypeDao abstractProductTypeDao;

        public ProductTypeServices(AbstractProductTypeDao abstractProductTypeDao)
        {
            this.abstractProductTypeDao = abstractProductTypeDao;
        }

        public override SuccessResult<AbstractProductType> ProductTypeUpsert(AbstractProductType abstractProductType)
        {
            return this.abstractProductTypeDao.ProductTypeUpsert(abstractProductType);
        }

        public override PagedList<AbstractProductType> ProductTypeSelectAll(PageParam pageParam, string search)
        {
            return this.abstractProductTypeDao.ProductTypeSelectAll(pageParam, search);
        }

        public override bool ProductTypeDelete(int Id)
        {
            return this.abstractProductTypeDao.ProductTypeDelete(Id);
        }

        public override SuccessResult<AbstractProductType> ProductTypeById(int Id)
        {
            return this.abstractProductTypeDao.ProductTypeById(Id);
        }

        //public override SuccessResult<ExamList> ExamListByKey(string Key)
        //{
        //    return this.abstractProductTypeDao.ExamListByKey(Key);
        //}
        //public override SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam)
        //{
        //    return this.abstractProductTypeDao.QuestionsListAPI(questionsAPIParam);
        //}
    }
}
