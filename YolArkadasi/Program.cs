using System;

namespace yolArkadasi
{
    class Program
    {
        static void Main(string[] args) 
        {
            bool active = true;
            //program çalışma kontrol eğer active false olur ise program çalışmaz
           while (active)
            {

                string choice = "";
                string name = "";
                int transport;
                bool transportControl;
                string locationOne = "bodrum";
                string locationTwo = "marmaris";
                string locationTree = "çeşme";
                int locationPrice = 0;
                bool control;
                int entryCount = 3;

                Console.Write("Yol Arkadaşıma Hoşgeldiniz - İsminizi Giriniz: ");
                name = Console.ReadLine();
                Console.WriteLine("--------------------------------------------");
                do
                {
                    //kullancıya gitmek istediği lokasyonu soruyoruz
                    Console.WriteLine("Yol Arkadaşı Tatil Uygulamasına Hoşgeldiniz ,Gitmek İstediğiniz Lokasyonu Seçiniz (Bodrum/Marmaris/Çeşme) ");
                    //Girilen değeri choice değişkenine atıyoruz
                    choice = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("-------------------");
                    //kullanıcının verdiğimiz 3 seçeneği girip girmediğini bir değişkende tutuyoruz
                    control = (choice == locationOne || choice == locationTwo || choice == locationTree);
                    //eğer 3 seçenekten biri girilmedi ise if kontrolüne sokup hata mesajı verip tekrar girmesini istiyoruz
                    // bu sırada kullanıcının girdiği hatalı işlemleri bir değişken de saklayıp 3 kere hata lı girince programı sonlandırıyoruz.
                    if (!control)
                    {
                        Console.WriteLine("YANLIŞ BİR SEÇİM Yaptınız Lütfen Tekrar Lokasyon Giriniz !");
                        Console.WriteLine();
                        //yanlış işlem sonucu giriş hakkını düşürüyoruz
                        entryCount--;
                        if (entryCount == 0)
                        {

                            Console.WriteLine("3 Kere Hatalı İşlem Yaptınız.Program Kendini Kapatacaktır.Lütfen daha sonra tekrar deneyiniz");
                            //programı sonlandırmak için
                            Environment.Exit(0);
                        }
                    }
                    //Girilen Lokasyon doğru ise while döngüsü içerisine giriyoruz
                } while (!control);
                {
                    //Kişi Sayısını alıyoruz
                    Console.WriteLine("Harika Bir Seçim ! Tatil Planınızı Kaç Kişi olarak Rezerve edelim? ");
                    int numberPeople = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-------------------------------------------");
                    //seçilen lokasyon a göre yapılacak olan faaliyetleri listeliyoruz
                    switch (choice)
                    {
                        case "bodrum":
                            Console.WriteLine($"Harika {name.ToUpper()}! Gitmek İstediğiniz Lokasyon {choice.ToUpper()}.Yapılabilecek Faaliyetler: (Kaydıraklı Su Parkları,Doğa Koşusu,Yüzme vb)");
                            //Lokasyona ait fiyatı belirliyoruz
                            locationPrice = 4000;
                            Console.WriteLine("-----------------------");
                            break;
                        case "marmaris":
                            Console.WriteLine($"Harika {name.ToUpper()}! Gitmek İstediğiniz Lokasyon {choice.ToUpper()}.Yapılabilecek Faaliyetler: (Sahil Koşusu,Orman Koşusu,Yüzme vb)");
                            locationPrice = 3000;
                            Console.WriteLine("-----------------------");
                            break;
                        case "çeşme":
                            Console.WriteLine($"Harika {name.ToUpper()}! Gitmek İstediğiniz Lokasyon {choice.ToUpper()}.Yapılabilecek Faaliyetler: (Su Aerobiki,Parkur Koşusu,Yüzme vb)");
                            locationPrice = 5000;
                            Console.WriteLine("-----------------------");
                            break;
                        default:
                            Console.WriteLine("Beklenmedik bir HATA OLUŞTU");
                            Environment.Exit(0);
                            break;
                    }
                    //Kullanıcının tatile hangi ulaşım yolu ile gideceğini seçiyoruz
                    do
                    {
                        //Kullanıcıdan Seç
                        Console.WriteLine("Seçim Yaptığınız Lokasyon a Hangi Ulaşım Yolunu Tercih Edersiniz.Seçimi RAKAM olarak yapınız \n (1) KARA YOLU \n (2) HAVA YOLU ");
                        //Girilen Değeri Değişkene Atadık
                        string vote = Console.ReadLine();
                        Console.WriteLine("---------------------------------------");
                        //1 VE 2 olarak cevap alacağımız için ilk öncelikle veriyi string olarak aldık daha sonra tryParse ile transport değişkenine tam sayı olarak atadık
                        transportControl = int.TryParse(vote, out transport) && (transport == 1 || transport == 2);
                        if (!transportControl)
                        {
                            Console.WriteLine("Hatalı Giriş Yaptınız.Lütfen SEÇİMİNİZİ 1 VEYA 2 yapınız");
                        }
                    } while (!transportControl);
                    {
                        //Ternary kullanımı girilen değere karşı metinsel ifadesini ve bir altında fiyatını belirledik
                        string transportType = transport == 1 ? "Kara Yolu" : "Hava Yolu";
                        int transportPrice = transport == 1 ? 1500 : 4000;
                        //ulaşım fiyatı * kişi sayısı
                        int transportTotal = transportPrice * numberPeople;
                        //konum fiyatı * kişi sayısı
                        int locationTotal = locationPrice * numberPeople;
                        //toplam fiyat
                        int totalPrice = transportTotal + locationTotal;
                        //Kullanıcı Bilgi Sunumları
                        Console.WriteLine($"HARİKA ! {name} tüm seçimleri tamamladın ,hesaplamları yapıyoruz güzel bir tatil için çok az kaldı :)");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Fiyatlamalar Kişi Sayısı ,Gideceğiniz Lokasyon ve Ulaşım Tercihine Göre Hesaplanmıştır.");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"Toplam Tatil İçin Ödemen Gereken Miktar -> {totalPrice} ' TL dir.Tatil Detayları Aşağıda Listelenmiştir. ");
                        Console.WriteLine($"{name} seçimlerin Burada listelenmiştir.\n Gideceğin Lokasyon : {choice.ToUpper()} \n Kişi Sayısı: {numberPeople} \n Ulaşım Tercihin: {transportType}");
                        Console.WriteLine("------------------------------------------------");
                        //Kullanıcının yeniden tatil planı yapıp yapmak istemediğini sorduk
                       
                        Console.WriteLine("Yeni Bir Tatil Planmak İstermisin ? (evet / hayır) ");
                        string newPerson = Console.ReadLine().ToLower();
                        Console.WriteLine("-----------------------------------------");
                        //gelen değer evet ise active değeri ni true yaptık
                        if ( newPerson == "evet")
                        {
                            active = true;
                        }else if ( newPerson == "hayır")
                        {
                            active = false;
                            Console.WriteLine("İyi Bir Tatil Geçirmenizi Dileriz Teşekkürler");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı bir işlem Yaptınız Program Sonlanıyor");
                            //progrmaı sonlandır
                            Environment.Exit(0);
                        }

                    }


                }//End Base While 
            }
        } 
    }
}