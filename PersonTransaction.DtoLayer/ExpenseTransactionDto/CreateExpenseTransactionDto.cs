using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DtoLayer.ExpenseTransactionDto
{
    public class CreateExpenseTransactionDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string TCKimlik { get; set; }
    }
}
