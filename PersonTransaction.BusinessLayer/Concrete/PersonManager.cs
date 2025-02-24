﻿using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.BusinessLayer.Concrete
{
    //Bu sınıf, Person varlığı için iş mantığı işlemlerini gerçekleştirir.
    //IPersonDal kullanarak veri erişim işlemlerini çağırır ve iş kurallarını uygular.
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public Person GetOnePersonByTCKimlik(string tcKimlik)
        {
            return _personDal.GetPersonByTCKimlik(tcKimlik);
        }

        public Person GetPersonByTCKimlik(string tcKimlik)
        {
            return _personDal.GetListAll().FirstOrDefault(p => p.TCKimlik == tcKimlik);
        }

        public bool IsTCKimlikExists(string tcKimlik)
        {
            return _personDal.GetListAll().Any(p => p.TCKimlik == tcKimlik);
        }


        public List<PersonTotalExpenseTransactionDto> GetPersonTotalExpenseTransaction()
        {
            {
                var persons = _personDal.GetPersonsWithExpenses();
                var personTotalExpenses = persons.Select(person => new PersonTotalExpenseTransactionDto
                {
                    TCKimlik = person.TCKimlik,
                    Name = person.Name,
                    TotalExpense = person.ExpenseTransactions.Sum(expense => expense.Amount)
                }).ToList();

                return personTotalExpenses;
            }
        }

        public void TAdd(Person entity)
        {
            _personDal.Add(entity);
        }

        public void TDelete(Person entity)
        {
            _personDal.Delete(entity);
        }

        public Person TGetByID(int id)
        {
            return _personDal.GetByID(id);
        }

        public List<Person> TGetListAll()
        {
            return _personDal.GetListAll();
        }

        public List<Person> TGetPersonsWithExpenses()
        {
            return _personDal.GetPersonsWithExpenses();
        }

        public void TUpdate(Person entity)
        {
            _personDal.Update(entity);
        }

        public void UpdatePersonByTCKimlik(string tcKimlik, Person updatedPerson)
        {
            _personDal.UpdatePersonByTCKimlik(tcKimlik, updatedPerson);
        }
    }
}
