﻿namespace PersonTransaction.EntityLayer.Entities
{
    public class ExpenseTransaction
    {
        public int ExpenseTransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

    }
}
