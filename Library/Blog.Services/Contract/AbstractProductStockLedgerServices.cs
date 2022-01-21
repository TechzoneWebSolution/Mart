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
    public abstract class AbstractProductStockLedgerServices : AbstractBaseService
    {
        public abstract SuccessResult<AbstractProductStockLedger> ProductStockLedgerUpsert(AbstractProductStockLedger abstractProductStockLedger);

        public abstract PagedList<AbstractProductStockLedger> ProductStockLedgerSelectAllByProductId(PageParam pageParam, string search, int productId);

        public abstract bool ProductStockLedgerDelete(int Id);

        public abstract SuccessResult<AbstractProductStockLedger> ProductStockLedgerById(int Id);

        //public abstract SuccessResult<ExamList> ExamListByKey(string Key);

        //public abstract SuccessResult<QuestionList> QuestionsListAPI(QuestionsAPIParam questionsAPIParam);
    }
}
