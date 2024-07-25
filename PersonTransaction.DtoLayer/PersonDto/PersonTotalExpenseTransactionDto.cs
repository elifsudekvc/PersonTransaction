using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.PersonDto
{
    public class PersonTotalExpenseTransactionDto
    {
        public string TCKimlik { get; set; }
        public string Name { get; set; }
        public decimal TotalExpense { get; set; }
    }
}
