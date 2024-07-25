using System.ComponentModel.DataAnnotations;

namespace PersonTransaction.EntityLayer.Entities
{
    //Entity Katmanı:
    //Bu katman, uygulamanın veri modelini (entity) içerir.
    //Örneğin, Person sınıfı burada tanımlanır ve uygulamanın temel veri yapılarını oluşturur.
    //bu classlar veritabanında tabloya dönüşür.
    public class Person
    {
        public int PersonID { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik 11 Haneli Olmalı.")]
        public string TCKimlik { get; set; }
        public string Name { get; set; }
        public List<ExpenseTransaction> ExpenseTransactions { get; set; }
    }
}
