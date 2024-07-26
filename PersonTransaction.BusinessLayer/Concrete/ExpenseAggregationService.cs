using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Abstract;
using System;
using System.Linq;

namespace PersonTransaction.BusinessLayer.Concrete
{
    public class ExpenseAggregationService : IExpenseAggregationService
    {
        private readonly IPersonDal _personDal;
        private readonly IExpenseTransactionDal _expenseTransactionDal;

        public ExpenseAggregationService(IPersonDal personDal, IExpenseTransactionDal expenseTransactionDal)
        {
            _personDal = personDal;
            _expenseTransactionDal = expenseTransactionDal;
        }

        public void AggregateDailyExpenses()
        {
            AggregateExpenses(DateTime.UtcNow.Date.AddDays(-1), DateTime.UtcNow.Date);
        }

        public void AggregateWeeklyExpenses()
        {
            AggregateExpenses(DateTime.UtcNow.Date.AddDays(-7), DateTime.UtcNow.Date);
        }

        public void AggregateMonthlyExpenses()
        {
            AggregateExpenses(DateTime.UtcNow.Date.AddMonths(-1), DateTime.UtcNow.Date);
        }

        private void AggregateExpenses(DateTime startDate, DateTime endDate)
        {
            var persons = _personDal.GetPersonsWithExpenses();

            foreach (var person in persons)
            {
                var totalExpenses = person.ExpenseTransactions
                    .Where(e => e.Date >= startDate && e.Date < endDate)
                    .Sum(e => e.Amount);

            }

            _personDal.Save();
        }
    }
}
