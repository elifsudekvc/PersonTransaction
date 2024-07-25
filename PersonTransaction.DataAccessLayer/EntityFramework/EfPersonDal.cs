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
    //Bu sınıf, Person varlığı için Entity Framework kullanarak veri erişim işlemlerini gerçekleştirir.
    //GenericRepository<Person> sınıfını genişleterek Person varlığı için CRUD işlemlerini sağlar.
    public class EfPersonDal : GenericRepository<Person>, IPersonDal
    {
        public EfPersonDal(PersonTransactionContext context) : base(context)
        {
        }

        public List<Person> GetPersonsWithExpenses()
        {
            var context = new PersonTransactionContext();
            var values =  context.Persons.Include(p => p.ExpenseTransactions).ToList();
            return values;
        }
    }
}
