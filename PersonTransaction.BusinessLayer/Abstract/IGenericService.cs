using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.BusinessLayer.Abstract
{
    //İş Mantığı Katmanı, uygulamanın iş gereksinimlerini karşılar.
    //Burada iş kuralları uygulanır ve veri erişim katmanı aracılığıyla veritabanı işlemleri yapılır.
    //Genel iş mantığı işlemlerini tanımlayan bir arayüz
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        T TGetByID(int id);
        List<T> TGetListAll();
    }
}
