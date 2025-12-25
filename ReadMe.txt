Projede kullandığım backend mimarisi : Onion Mimari

Domain Katmanı : hiçbir dış katmana bağımlılığı yoktur. Entities (Post, Category, Tag), Enums (DataStatus) ve Interfaces (IEntity) bu katmanda yer alır.

Application Katmanı : Uygulama mantığının ve iş kurallarının (Business Logic) yönetildiği katmandır. Manager sınıfları, DTO (Data Transfer Object) modelleri burada bulunur. DTO ve Domain modelleri arasındaki dönüşümü (Mapping) sağlar ve servislerin orkestrasyonunu yönetir.

Infrastructure Katmanı : Dış dünya ile iletişim kuran teknik detayların (Persistence) uygulandığı katmandır. DbContext (EF Core), Repository implementasyonları ve Migrations bu katmanda yer alır. Application katmanındaki arayüzlerin (Repository Interfaces) veritabanı somutlaştırmalarını gerçekleştirir.

API Katmanı : Controllers konfigürasyonları burada bulunur 



İş Kuralları : Validation'ları backendde vaktim kalmadığı için yazamadım. FrontEnd kısmında yazdım. 

"Draft" (Taslak) olarak kaydedilen bir yazının daha sonra kullanıcı tarafından "Published" durumuna güncellenebilme esnekliği sağlanmıştır.

Her yazının en az bir kategori ve bir etiket ile ilişkilendirilmesi kuralı, form üzerindeki relation validator'ı (min 1 seçimi) ile zorunlu kılınmıştır.

Kategori ve etiket adlarının veritabanında benzersiz olması kuralı uygulanmıştır

Başlık alanı boş geçilemez ve dökümanda istenen uzunluk sınırlarına (en az 5 karakter) uygunluğu hem Angular PostValidators hem de backend PostValidator ile çift taraflı kontrol edilir.


-- Çalıştırma adımlar 
- npm install
- ng serve 