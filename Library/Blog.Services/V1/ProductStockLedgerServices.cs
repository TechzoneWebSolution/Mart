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
    public class ProductStockLedgerServices : AbstractProductStockLedgerServices
    {
        private AbstractProductStockLedgerDao abstractProductStockLedgerDao;

        public ProductStockLedgerServices(AbstractProductStockLedgerDao abstractProductStockLedgerDao)
        {
            this.abstractProductStockLedgerDao = abstractProductStockLedgerDao;
        }

        public override SuccessResult<AbstractProductStockLedger> ProductStockLedgerUpsert(AbstractProductStockLedger abstractProductStockLedger)
        {
            return this.abstractProductStockLedgerDao.ProductStockLedgerUpsert(abstractProductStockLedger);
        }

        public override PagedList<AbstractProductStockLedger> ProductStockLedgerSelectAllByProductId(PageParam pageParam, string search, int productId)
        {
            return this.abstractProductStockLedgerDao.ProductStockLedgerSelectAllByProductId(pageParam, search, productId);
        }

        public override bool ProductStockLedgerDelete(int Id)
        {
            return this.abstractProductStockLedgerDao.ProductStockLedgerDelete(Id);
        }

        public override SuccessResult<AbstractProductStockLedger> ProductStockLedgerById(int Id)
        {
            return this.abstractProductStockLedgerDao.ProductStockLedgerById(Id);
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
