using Microsoft.EntityFrameworkCore;
using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Concrete;
using PersonTransaction.DataAccessLayer.Repositories;
using PersonTransaction.DtoLayer.PersonDto;
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

        public Person GetOnePersonByTCKimlik(string tcKimlik)
        {
            var context = new PersonTransactionContext();
            return context.Persons.FirstOrDefault(p => p.TCKimlik == tcKimlik);
        }

        public Person GetPersonByTCKimlik(string tcKimlik)
        {
            var context = new PersonTransactionContext();
            return context.Persons.FirstOrDefault(p => p.TCKimlik == tcKimlik);
        }

        public List<Person> GetPersonsWithExpenses()
        {
            var context = new PersonTransactionContext();
            var values =  context.Persons.Include(p => p.ExpenseTransactions).ToList();
            return values;
        }

        public List<PersonTotalExpenseTransactionDto> GetPersonTotalExpenseTransaction()
        {
            var context = new PersonTransactionContext();
            var totalExpenses = context.Persons.Include(p => p.ExpenseTransactions).Select(person => new PersonTotalExpenseTransactionDto
            {
                TCKimlik = person.TCKimlik,
                Name = person.Name,
                TotalExpense = person.ExpenseTransactions.Sum(e => e.Amount)
            }).ToList();

            return totalExpenses;
        }

        public void Save()
        {
            var context = new PersonTransactionContext();
            context.SaveChanges();
        }

        public void UpdatePersonByTCKimlik(string tcKimlik, Person updatedPerson)
        {
            var context = new PersonTransactionContext();
            var existingPerson = context.Persons.FirstOrDefault(p => p.TCKimlik == tcKimlik);

            if (existingPerson != null)
            {
                existingPerson.Name = updatedPerson.Name;
                // Gerekirse diğer alanları da güncelle
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Person not found.");
            }
        }
    }
}
