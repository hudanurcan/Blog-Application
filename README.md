Projede kullandığım backend mimarisi : Onion Mimari

Domain Katmanı : hiçbir dış katmana bağımlılığı yoktur. Entities (Post, Category, Tag), Enums (DataStatus) ve Interfaces (IEntity) bu katmanda yer alır.

Application Katmanı : Uygulama mantığının ve iş kurallarının (Business Logic) yönetildiği katmandır. Manager sınıfları, DTO (Data Transfer Object) modelleri burada bulunur. DTO ve Domain modelleri arasındaki dönüşümü (Mapping) sağlar ve servislerin orkestrasyonunu yönetir.

Infrastructure Katmanı : Dış dünya ile iletişim kuran teknik detayların (Persistence) uygulandığı katmandır. DbContext (EF Core), Repository implementasyonları ve Migrations bu katmanda yer alır. Application katmanındaki arayüzlerin (Repository Interfaces) veritabanı somutlaştırmalarını gerçekleştirir.

API Katmanı : Controllers konfigürasyonları burada bulunur 



İş Kuralları : Validation'ları backendde vaktim kalmadığı için yazamadım. FrontEnd kısmında yazdım. 

"Draft" (Taslak) olarak kaydedilen bir yazının daha sonra kullanıcı tarafından "Published" durumuna güncellenebilme esnekliği sağlanmıştır.

Her yazının en az bir kategori ve bir etiket ile ilişkilendirilmesi kuralı, form üzerindeki relation validator'ı (min 1 seçimi) ile zorunlu kılınmıştır.

Kategori ve etiket adlarının veritabanında benzersiz olması kuralı uygulanmıştır

Başlık alanı boş geçilemez uygunluğu Angular tarafında kontrol edilir.


-- Çalıştırma adımlar 
- npm install
- ng serve
  
<img width="1920" height="1080" alt="Ekran Görüntüsü (3734)" src="https://github.com/user-attachments/assets/dd4fa1e0-9680-4e87-aa22-ea35a4edaabf" />

<img width="1920" height="1080" alt="Ekran Görüntüsü (3735)" src="https://github.com/user-attachments/assets/95e5dc08-4e13-49e1-9a3d-fc0b0ee84ce3" />

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/eba7e037-700e-4395-984a-5896c75e0cd3" />



