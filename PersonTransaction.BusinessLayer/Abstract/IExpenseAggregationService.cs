using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.BusinessLayer.Abstract
{
    public interface IExpenseAggregationService
    {
        void AggregateDailyExpenses();
        void AggregateWeeklyExpenses();
        void AggregateMonthlyExpenses();
    }
}
