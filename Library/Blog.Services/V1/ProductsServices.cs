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
    public class ProductsServices : AbstractProductsServices
    {
        private AbstractProductsDao abstractProductsDao;

        public ProductsServices(AbstractProductsDao abstractProductsDao)
        {
            this.abstractProductsDao = abstractProductsDao;
        }

        public override SuccessResult<AbstractProducts> ProductsUpsert(AbstractProducts abstractProducts)
        {
            return this.abstractProductsDao.ProductsUpsert(abstractProducts);
        }

        public override PagedList<AbstractProducts> ProductsSelectAll(PageParam pageParam, string search)
        {
            return this.abstractProductsDao.ProductsSelectAll(pageParam, search);
        }

        public override bool ProductsDelete(int Id)
        {
            return this.abstractProductsDao.ProductsDelete(Id);
        }

        public override SuccessResult<AbstractProducts> ProductsById(int Id)
        {
            return this.abstractProductsDao.ProductsById(Id);
        }

        //public override SuccessResult<ExamList> ExamListByKey(string Key)
        //{
        //    return this.abstractProductsDao.ExamListByKey(Key);
        //}
        //public override SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam)
        //{
        //    return this.abstractProductsDao.QuestionsListAPI(questionsAPIParam);
        //}
    }
}
