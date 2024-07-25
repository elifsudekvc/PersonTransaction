using PersonTransaction.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.BusinessLayer.Abstract
{
    //Bu arabirim, Person varlığına özgü iş mantığı işlemlerini tanımlar.
    //IGenericService<Person> arabirimini genişleterek Person için temel iş mantığı işlemlerini sağlar.
    public interface IPersonService : IGenericService<Person>
    {
        List<Person> TGetPersonsWithExpenses();
        Person GetPersonByTCKimlik(string tcKimlik);
        void UpdatePersonByTCKimlik(string tcKimlik, Person updatedPerson);
        Person GetOnePersonByTCKimlik(string tcKimlik);
    }
}
