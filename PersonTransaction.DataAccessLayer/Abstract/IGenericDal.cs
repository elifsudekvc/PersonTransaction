using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTransaction.DataAccessLayer.Abstract
{
    //Data Access Layer: 
    //veritabanı işlemlerini yapan kodları içerir.
    //Bu katman, genellikle CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirir
    //ve veritabanıyla iletişim kurar. 

    //Bu arabirim, genel (generic) veri erişim işlemlerini tanımlar.
    //Tüm veri türleri (entity) için ekleme, silme, güncelleme, ID'ye göre getirme
    //ve tüm listeyi getirme gibi temel işlemleri sağlar.
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetByID(int id);
        List<T> GetListAll();

    }
}
