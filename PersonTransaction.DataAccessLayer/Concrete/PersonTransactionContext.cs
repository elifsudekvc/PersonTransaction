using Microsoft.EntityFrameworkCore;
using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.Concrete
{
    public class PersonTransactionContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ELIF;initial Catalog=PersonTransactionDb;integrated Security=true");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }
    }
}
