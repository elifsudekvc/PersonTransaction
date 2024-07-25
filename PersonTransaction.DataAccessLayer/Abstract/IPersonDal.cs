using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.Abstract
{
    //Bu arabirim, Person varlığına özgü veri erişim işlemlerini tanımlar.
    //IGenericDal<Person> arabirimini genişleterek Person varlığı için temel CRUD işlemlerini sağlar.
    public interface IPersonDal : IGenericDal<Person>
    {
        List<Person> GetPersonsWithExpenses();
        Person GetPersonByTCKimlik(string tcKimlik);
        void UpdatePersonByTCKimlik(string tcKimlik, Person updatedPerson);
        Person GetOnePersonByTCKimlik(string tcKimlik);
        List<PersonTotalExpenseTransactionDto> GetPersonTotalExpenseTransaction();
    }
}
