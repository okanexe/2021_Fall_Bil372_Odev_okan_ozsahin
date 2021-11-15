öncelikle MSSQL server kurulu olması gerek

min .NET 4.6 gereklidir

SQLEXPRESS ile windows auth modunda giriş yapılmalı

veritabanını yüklemek için kurulu SQL management studio üzerinde veritabanına script.sql dosyasını import edilmesi gerek

veritabanı ve uygulama ile ilgili ayarlar app.config dosyası içerisinde ayarlanmıştır

veritabanı tabloları oluşturulurken normalizasyon kurallarına uyulmaya çalışılmıştır

main method WinTicket/Program.cs içerisinde tanımlanmıştır

user role'leri Model/UserRole.cs dosyasında admin ve çalışan olmak üzere tanımlanmıştır

arayüz BaseForm.cs dosyasında tanımlanmış Form sınıfından inherit etmiştir. Diğer tablo arayüzleri için bu BaseForm referans alınmıştır

WinTicketDataSet.xsd içerisinde veri tabanı şemaları incelenebilir

SQLDataAdapter sınıfı veritabanı nesneleri üzerinde işlem yapmak ve veritabanı nesnelerini çekmek için kullanılmaktadır

tanımlı kullanıcı -> <b>ADI:</b> admin <b>ŞİFRE:</b> admin

Visual studio community 2022 yüklenebilir.
Visual studio üzerinde kodlar derlendiğinde çalışmaktadır.

```
WinTicket derleniyor (Debug)
Oluşturma başlatıldı: 15.11.2021 20:19:39.
__________________________________________________
"/Users/okans/Downloads/Proje/WinTicket/WinTicket.csproj" projesi (Build hedef):

GenerateBindingRedirects hedefi:
    ResolveAssemblyReferences öğesinden hiçbir önerilen bağlama yeniden yönlendirmesi yok.
CoreResGen hedefi:
    İlgili kaynak dosyalarına göre kaynakların tümü güncel. Kaynak oluşturma atlanıyor.
GenerateTargetFrameworkMonikerAttribute hedefi:
  Tüm çıkış dosyaları, giriş dosyalarına göre güncel durumda olduğundan "GenerateTargetFrameworkMonikerAttribute" hedefi atlanıyor.
CoreCompile hedefi:
  Tüm çıkış dosyaları, giriş dosyalarına göre güncel durumda olduğundan "CoreCompile" hedefi atlanıyor.
_CopyFilesMarkedCopyLocal hedefi:
    "/Users/okans/Downloads/Proje/WinTicket/obj/Debug/WinTicket.csproj.CopyComplete" öğesine erişiliyor.
_CopyAppConfigFile hedefi:
  Tüm çıkış dosyaları, giriş dosyalarına göre güncel durumda olduğundan "_CopyAppConfigFile" hedefi atlanıyor.
CopyFilesToOutputDirectory hedefi:
    WinTicket -> /Users/okans/Downloads/Proje/WinTicket/bin/Debug/WinTicket.exe

Oluşturma başarılı oldu.
    0 Uyarı
    0 Hata

Geçen Süre 00:00:00.84

========== ========== Derleme: 1 başarılı, 0 başarısız, 0 güncel, 0 atlandı ========== ==========

Derleme başarılı oldu.
```

2011011051
Okan Özşahin
