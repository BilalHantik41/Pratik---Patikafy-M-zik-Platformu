using Pratik___Patikafy_Müzik_Platformu;

List<Artist> artist = new List<Artist>();

artist.Add(new Artist{ Name = "Ajda", SurName = "Pekkan", Type = "Pop", ReleaseYear = "1968", Sales = 20000000 });
artist.Add(new Artist{ Name = "Sezen", SurName = "Aksu", Type = "Türk Halk Müziği / Pop", ReleaseYear = "1971", Sales = 1000000 });
artist.Add(new Artist{ Name = "Funda", SurName = "Arrar", Type = "Pop", ReleaseYear = "1999", Sales = 3000000 });
artist.Add(new Artist { Name = "Sertab", SurName = "Erener", Type = "Pop", ReleaseYear = "1994", Sales = 5000000 });
artist.Add(new Artist{ Name = "Sıla", SurName = " ", Type = "Pop", ReleaseYear = "2009", Sales = 3000000 });
artist.Add(new Artist{ Name = "Serdar", SurName = "Ortaç", Type = "Pop", ReleaseYear = "1994", Sales = 1000000 });
artist.Add(new Artist{ Name = "Tarkan", SurName = " ", Type = "Pop", ReleaseYear = "1992", Sales = 40000000 });
artist.Add(new Artist{ Name = "Hande", SurName = "Yener", Type = "Pop", ReleaseYear = "1999", Sales = 7000000 });
artist.Add(new Artist{ Name = "Hadise", SurName = " ", Type = "Pop", ReleaseYear = "2005", Sales = 5000000 });
artist.Add(new Artist{ Name = "Gülben", SurName = "Ergen", Type = "Pop / Türk Halk Müziği", ReleaseYear = "1997", Sales = 1000000 });
artist.Add(new Artist{ Name = "Neşet", SurName = "Ertaş", Type = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = "1960", Sales = 2000000 });

Console.WriteLine("Adı 'S' ile başlayan şarkıcılar");
Console.WriteLine("--------------------------------------------------------------");
var sList = from s in artist
            where s.Name.StartsWith("S", StringComparison.OrdinalIgnoreCase)
            select s;

foreach (var Artist in sList)
{
    Console.WriteLine($"{Artist.Name} {Artist.SurName} ");
};

Console.WriteLine("--------------------------------------------------------------");


var salesList = artist
    .Where(a => a.Sales >= 10_000_000)      // filtre: Sales >= 10M
    .OrderByDescending(a => a.Sales)        // sıralama: en çok satış olandan aşağılara
    .ToList();

Console.WriteLine("10 Milyon ve Üzeri Satış Yapan Sanatçılar");
Console.WriteLine("--------------------------------------------------------------");
foreach (var sale in salesList)
{
    
    Console.WriteLine($"{sale.Name} {sale.SurName}: {sale.Sales}");
    
}

Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar. ");
Console.WriteLine("--------------------------------------------------------------");

var sonuc = artist
    // 1) 2000 öncesi ve türünde "Pop" geçenler
    .Where(a => int.Parse(a.ReleaseYear) < 2000
             && a.Type.Contains("Pop", StringComparison.OrdinalIgnoreCase)) // Burayı Chatgpt'den aldım büyük küçük harf duyarlılığını kaldırıyor.

    // 2) Yıla göre grupla
    .GroupBy(a => a.ReleaseYear)

    // 3) Yılları int olarak artan sıraya göre sırala
    .OrderBy(g => int.Parse(g.Key));


foreach (var grup in sonuc)
{
    Console.WriteLine($"Çıkış Yılı: {grup.Key}");
    // 4) Her grubun içindekileri isme göre sırala
    foreach (var art in grup.OrderBy(a => a.Name))
    {
        Console.WriteLine($"    {art.Name} {art.SurName.Trim()}");
    }
}


Console.WriteLine("--------------------------------------------------------------");
//  Satış adedine göre azalan sırala ve ilkini al
var enCokSatan = artist
    .OrderByDescending(a => a.Sales)
    .First();

Console.WriteLine($"En çok albüm satan sanatçı: {enCokSatan.Name} {enCokSatan.SurName.Trim()} - Satış: {enCokSatan.Sales:N0}");

Console.WriteLine("--------------------------------------------------------------");

// En yeni
var enYeni = artist
    .OrderByDescending(a => int.Parse(a.ReleaseYear))
    .First();
Console.WriteLine($"En yeni çıkış yapan şarkıcı: {enYeni.Name} {enYeni.SurName} ({enYeni.ReleaseYear})");

Console.WriteLine("--------------------------------------------------------------");

// En eski
var enEski = artist
    .OrderBy(a => int.Parse(a.ReleaseYear))
    .First();
Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEski.Name} {enEski.SurName} ({enEski.ReleaseYear})");
Console.WriteLine("--------------------------------------------------------------");
