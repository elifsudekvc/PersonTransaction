using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Abstract;
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
    }
}
