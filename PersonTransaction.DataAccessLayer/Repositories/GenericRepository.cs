using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.Repositories
{
    //Burada veritabanı işlemleri Entity Framework kullanılarak gerçekleştirilir.
    //Örneğin, Add metodu yeni bir entity ekler ve SaveChanges ile değişiklikleri kaydeder.
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly PersonTransactionContext _context;

        public GenericRepository(PersonTransactionContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
