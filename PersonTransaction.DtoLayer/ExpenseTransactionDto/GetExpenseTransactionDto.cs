using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.ExpenseTransactionDto
{
    public class GetExpenseTransactionDto
    {
        public int ExpenseTransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
