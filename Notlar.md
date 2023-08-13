# 30.07.2023

- Cms.Data içerisindeki Utility klasöründekileri ana dizine alalım.
- Cms.Web.Mvc Program.cs içerisinde Area route tanımı default tanımın üstünde olmalıdır.
- Home/Index view içeriğini kontrol edelim.
- Page/Detail, Post/Search, Post/Detail view içeriğinde html/body kalıpları olmamalı.
- Dto içerisinde Db Annotation ları kaldıralım. Ama Validation amaçlı olanlar kalabilir.
- Department tablosunda departmanları tutalım.
- Doctor tablosuna Content alanı ve DepartmentId alanını ekleyelim. Sayfa şablounda bu bilgiler var.
- Page yapısını; About, Privacy gibi sayfaların gösteriminde kullanalım.
- Service tablosunda; Service kayıtlarını tutalım. Post.cs içerisindeki kolonları kullanabiliriz.

# 13.08.2023

- Sayfa içeriklerini Türkçe kullanalım. Menüler ve genel içerik.
- Departmanlar altında Tüm Departmanlara tıklanınca tüm departmanlar listelenecek.
    - Listelenen departmanlardan birine tıklanınca o departmanın detaylarını gösterecek.
- Doktorlar menüsünde Tüm Doktorlara tıklanınca tüm doktorlar listelenecek.
    - Listelenen doktorlardan birine tıklanınca o doktorun detay sayfasına gidecek.

- Randevu formu tamamlanacak.

- Blog menüsünde blog kategorileri listelenecek. O kategoriye tıklanınca o kategorideki yazılar gelecek. 
    - Yazılardan Detay butonuna tıklanınca blog detay sayfası açılacak.