using PersonTransaction.DtoLayer.ExpenseTransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.PersonDto
{
    public class ResultPersonWithExpenseTransactionDto
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public List<ResultExpenseTransactionWithPerson> ExpenseTransactions { get; set; }
    }
}
