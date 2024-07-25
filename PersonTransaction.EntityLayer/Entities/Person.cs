namespace PersonTransaction.EntityLayer.Entities
{
    //Entity Katmanı:
    //Bu katman, uygulamanın veri modelini (entity) içerir.
    //Örneğin, Person sınıfı burada tanımlanır ve uygulamanın temel veri yapılarını oluşturur.
    //bu classlar veritabanında tabloya dönüşür.
    public class Person
    {
        public int PersonID { get; set; } //PersonID TC kimlik no gibi düşünülebilir.
        public string Name { get; set; }
        public List<ExpenseTransaction> ExpenseTransactions { get; set; }
    }
}
