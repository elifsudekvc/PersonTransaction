using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.BusinessLayer.Concrete
{
    public class ExpenseTransactionManager : IExpenseTransactionService
    {
        private readonly IExpenseTransactionDal _expenseTransactionDal;

        public ExpenseTransactionManager(IExpenseTransactionDal expenseTransactionDal)
        {
            _expenseTransactionDal = expenseTransactionDal;
        }

        public void TAdd(ExpenseTransaction entity)
        {
            _expenseTransactionDal.Add(entity);
        }

        public void TDelete(ExpenseTransaction entity)
        {
            _expenseTransactionDal.Delete(entity);
        }

        public ExpenseTransaction TGetByID(int id)
        {
            return _expenseTransactionDal.GetByID(id);
        }

        public List<ExpenseTransaction> TGetExpenseTransactionWithPerson()
        {
            return _expenseTransactionDal.GetExpenseTransactionWithPerson();
        }

        public List<ExpenseTransaction> TGetListAll()
        {
            return _expenseTransactionDal.GetListAll();
        }

        public void TUpdate(ExpenseTransaction entity)
        {
            _expenseTransactionDal.Update(entity);
        }
    }
}
