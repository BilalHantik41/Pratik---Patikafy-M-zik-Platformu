# Pratik - Patikafy Müzik Platformu

Bu projede, basit bir müzik platformu benzeri uygulama geliştirilmiştir. Amaç; `Artist` nesneleri üzerinden müzik sanatçılarını listelemek, filtrelemek, gruplamak ve yönetmek için temel CRUD ve LINQ kullanımını pratik etmektir.

## Özellikler

* Sanatçı (`Artist`) bilgilerini yönetme (Ekleme, Listeleme)
* Satış adedine göre sıralama ve filtreleme
* Çıkış yılına göre gruplama ve sıralama
* Tür (`Type`) bazlı arama ve büyük-küçük harf duyarsızlığıyla sorgulama

## Proje Yapısı

* **`Artist`** sınıfı: `Name`, `SurName`, `Type`, `ReleaseYear`, `Sales` gibi temel özellikleri barındırır.
* **`Program.cs`**: Konsol uygulaması içerisinde LINQ sorguları ve kullanıcı etkileşiminin demo kodlarını içerir.

## Gereksinimler

* .NET 6.0 SDK veya üzeri
* IDE (Visual Studio, Visual Studio Code vb.)

## Kurulum ve Çalıştırma

1. Depoyu klonlayın:

   ```bash
   git clone https://github.com/BilalHantik41/Pratik---Patikafy-M-zik-Platformu.git
   ```
2. Proje klasörüne gidin:

   ```bash
   cd Pratik---Patikafy-M-zik-Platformu
   ```
3. Projeyi derleyin ve çalıştırın:

   ```bash
   dotnet run --project Pratik.PatikafyMusicPlatformu
   ```

## Kullanım

* Uygulama açıldığında, ön tanımlı `Artist` listesi üzerinden çeşitli örnek LINQ sorguları çalıştırılır.
* Kod içerisindeki bölümleri özelleştirerek farklı filtre, sıralama ve gruplama senaryolarını deneyebilirsiniz.

## Örnek LINQ Sorguları

```csharp
// 1. 10M satış üzeri en çok satan sanatçılar
var topArtists = artist
    .Where(a => a.Sales >= 10_000_000)
    .OrderByDescending(a => a.Sales)
    .ToList();

// 2. Yıla göre gruplama ve sıralama
var groupedByYear = artist
    .GroupBy(a => a.ReleaseYear)
    .OrderBy(g => int.Parse(g.Key));

// 3. Pop türündeki, 2000 öncesi çıkış yapan sanatçılar
var popBefore2000 = artist
    .Where(a => int.Parse(a.ReleaseYear) < 2000 &&
                a.Type.Contains("Pop", StringComparison.OrdinalIgnoreCase))
    .GroupBy(a => a.ReleaseYear)
    .OrderBy(g => int.Parse(g.Key));
```

## Katkıda Bulunma

Proje açık kaynaklıdır ve katkıda bulunmak isteyenler için pull request’ler memnuniyetle karşılanır. Herhangi bir öneri, iyileştirme veya hata raporu için lütfen issue açınız.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakabilirsiniz.
