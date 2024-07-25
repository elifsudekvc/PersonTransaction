using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.Abstract
{
    public interface IExpenseTransactionDal : IGenericDal<ExpenseTransaction>
    {
        List<ExpenseTransaction> GetExpenseTransactionWithPerson();
    }
}
