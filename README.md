# Person Transaction API
Bu proje kişileri isim soyisim ve tc kimlik bilgileriyle görüntüleme (GetAllPerson), ekleme (CreatePerson), TC kimlik numarasına göre görüntüleme (GetPersonByTCKimlik), güncelleme (UpdatePerson) 
ve silme (DeletePerson) işlemlerini yapar. Harcamalarda ise harcamaların tamamını görüntüleme (GetAllExpenseTransaction), Harcamayı kişiyle beraber ekleme (CreateExpenseTransaction), 
Harcama silme (DeleteExpenseTransaction), Id'ye göre harcama görüntüleme (GetExpenseTransactionById), Harcama güncelleme (UpdateExpenseTransaction), Harcamaları harcama yapan kişileriyle
birlikte görüntüleme (ExpenseTransactionListWithPerson), Kişilerin tüm harcamalarını görüntüleme (PersonWithExpenseTransaction) işlemlerini içerir.

Login fonksiyonundan login olmadan işlemlere erişilmez (Error: response status is 401 hatası alınır).

Scheduled background job kullanarak kullanıcı bazlı masrafları günlük, haftalık ve aylık olarak toplar.

### Kullanılan Teknolojiler
+	Microsoft SQL Server
+	ASP.NET Core (.NET 6.0)
+	RESTful API
+	JWT
+	Generic Repository pattern
+	Hangfire
+	Çok katmanlı mimari
+	AutoMapper

### Kurulum Talimatları
1.	Depoyu Klonlayın:
Terminal veya komut istemcisini açın ve aşağıdaki komutu çalıştırın:          
```bash
git clone https://github.com/elifsudekvc/PersonTransaction.git
```

2.	Visual Studio'yu açın.
File menüsünden Open -> Project/Solution seçeneğini tıklayın.
Klonladığınız PersonTransaction dizinine gidin ve PersonTransaction.sln dosyasını seçip açın.

3.	Bağımlılıkları Yükleyin:
```bash
dotnet restore
```
4.	Veritabanını Güncelleyin
appsettings.json dosyasında veritabanı ayarlarının doğru yapılandırıldığından emin olun.
```bash
dotnet ef database update
```

5.	Son olarak, projeyi çalıştırın:
```bash
dotnet run
```

###  Ekran görüntüleri
![Ekran görüntüsü 2024-07-26 140902](https://github.com/user-attachments/assets/a234a48c-c6f5-4277-971b-a99c298062b8)
![Ekran görüntüsü 2024-07-26 141016](https://github.com/user-attachments/assets/932cfd55-9fc5-4f77-aac8-3642631daf94)
![Ekran görüntüsü 2024-07-26 141121](https://github.com/user-attachments/assets/23d5086b-047e-4f7c-bf6d-64a3c319536b)
![Ekran görüntüsü 2024-07-26 141147](https://github.com/user-attachments/assets/b00b71cd-1809-4318-82bf-1a0eb2a80911)
![Ekran görüntüsü 2024-07-26 141238](https://github.com/user-attachments/assets/916af882-2538-4fb6-9404-a728c28c3645)
![Ekran görüntüsü 2024-07-26 141322](https://github.com/user-attachments/assets/ca4f13ef-d889-4002-9ea7-10e4dcbb90e3)
![Ekran görüntüsü 2024-07-26 141352](https://github.com/user-attachments/assets/22c7628c-a518-46b2-879c-f344947e6d8b)
![Ekran görüntüsü 2024-07-26 141620](https://github.com/user-attachments/assets/689d6e7f-6442-4f15-9905-4985f2233392)
