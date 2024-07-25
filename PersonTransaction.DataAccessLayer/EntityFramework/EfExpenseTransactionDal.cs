using Microsoft.EntityFrameworkCore;
using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Concrete;
using PersonTransaction.DataAccessLayer.Repositories;
using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.EntityFramework
{
    public class EfExpenseTransactionDal : GenericRepository<ExpenseTransaction>, IExpenseTransactionDal
    {
        public EfExpenseTransactionDal(PersonTransactionContext context) : base(context)
        {
        }

        public List<ExpenseTransaction> GetExpenseTransactionWithPerson()
        {
            var context = new PersonTransactionContext();
            var values = context.ExpenseTransactions.Include(x=> x.Person).ToList();
            return values;
        }
    }
}
