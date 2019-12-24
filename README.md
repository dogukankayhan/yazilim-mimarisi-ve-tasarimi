# yazilim-mimarisi-ve-tasarim
Yazılım Mimarisi ve Tasarımı Ödevi
## Bridge Tasarım Deseni
Bridge tasarım deseni implementasyonları abstractlardan ayırabilmek için kullanılır.
![Image of Class](https://github.com/sametbilim/yazilim-mimarisi-tasarim/blob/master/bridge.png)

Banka classı:
```.cs
 class Banka
 {
   public bool KrediyiKullan(Musteri m, decimal talepEdilenMiktar)
   {
     return true;
   }
 }
```
Kredi classı : Kredi Kullanma Durumu sorgular
```.cs
class Kredi
  {
    public bool KrediKullanmaDurumu(Musteri m)
    {
     return true;
    }
 }
```

MerkezBanka classı : Müşteri kara listede mi değil mi sorgulayan class
```.cs
 class MerkezBanka
 {
    public bool KaraListeKontrol(string tcNo)
    {
     return false;
    }
 }

```

Musteri classı : Yardımcı class

```.cs
 class Musteri
 {
    public int MusteriNumarasi { get; set; }
    public string TcNo { get; set; }
    public string Ad { get; set; }
 }
```

Facade Classı : Facade class’ı içerisinde müşterinin istediği fonksiyonelliği gerisinde bulunan sistemdeki parçaları organize ederek tek elden sunar.


```.cs
class Facade
{
   private Banka _banka;
   private MerkezBanka _merkezBanka;
   private Kredi _kredi;

   public Facade()
   {
    _banka = new Banka();
    _merkezBanka = new MerkezBanka();
    _kredi = new Kredi();

   }

 public void KrediKullan(Musteri m, decimal talep)
 {
     if(!_merkezBanka.KaraListeKontrol(m.TcNo) && _kredi.KrediKullanmaDurumu(m))
     {
       _banka.KrediyiKullan(m, talep);
        Console.WriteLine("krediyi kullandırdık");
     }
 
    }
 }
```
 Main method:
 
```.cs
static void Main(string[] args)
 {
    Facade fcd = new Facade();

    fcd.KrediKullan(new Musteri { Ad = "Burak", TcNo = "123303", MusteriNumarasi = 4234242 },1000) ;
 }
```
## Factory Tasarım Deseni
Factory Method tasarım kalıbı , kalıtımsal ilişkileri olan asıl nesnelerin üretilmesi amacıyla kullanılan patternlerden birisidir. Burada asıl olan bir metottur. Bu metodun üstlendiği iş ise istemcinin ihtiyacı olan asıl ürünlerin üretilmesini sağlamak.
![Image of Class](https://github.com/sametbilim/yazilim-mimarisi-tasarim/blob/master/factory.png)

Fabrika metodunun özelliği istemciden gelen talebe göre uygun olan ürünün üretilip istemciye verilmesi. Tek bir sınıf ve metodun bunu üstlenebilmesi için polimorfik özelliği olan bir tipe ihtiyacımız vardır. Bu yüzden productların interface olarak bir atası tasarlanır. Yani bizim creatorClassımız bir productu yani IProduct’ın taşıyabilceği türden bir referansı geriye döndürecektir.

Screen Ana Sınıfı:
```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
    public abstract class Screen
    { //Abstract parent class

        public abstract void Draw();
    }
}
```

Screen Sınıfından Türüyen WebScreeen Sınıfı:
```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
    class WebScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Web Ekranı");
        }

    }
}

```

Screen Sınıfından Türüyen MobileScreen Sınıfı:
```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
    class MobileScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Mobile Ekranı");
        }
    }
}

```


Screen Sınıfından Türüyen WinScreen Sınıfı:

```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
    class WinScreen : Screen
    {
        public override void Draw()
        {
            Console.WriteLine("Windows Ekranı");
        }
    }
}

```



Alt Sınıfların Üretiminden Sorumlu Creator Class
```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
    class Creator
    {

        public Screen ScreenFactory(ScreenModel screenModel)
        {
            Screen screen = null;

            switch (screenModel)
            {
                case ScreenModel.Windows:
                    screen = new WinScreen();
                    break;

                case ScreenModel.Web:
                    screen = new WebScreen();
                    break;

                case ScreenModel.Mobile:
                    screen = new MobileScreen();
                    break;

            }

            return screen;
        }

    }
}

```


```.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTORY_METHOD_PATTERN
{
 
    enum ScreenModel
    {
        Windows,
        Web,
        Mobile
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();

            Screen screenWindows = creator.ScreenFactory(ScreenModel.Windows);
            Screen screenWeb = creator.ScreenFactory(ScreenModel.Web);
            Screen screenMobile = creator.ScreenFactory(ScreenModel.Mobile);

            screenWindows.Draw();
            screenWeb.Draw();
            screenMobile.Draw();

            Console.ReadKey();
        }
    }
}

```
