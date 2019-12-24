# yazilim-mimarisi-ve-tasarim
Yazılım Mimarisi ve Tasarımı Ödevi
## Bridge Tasarım Deseni
Bridge tasarım deseni implementasyonları abstractlardan ayırabilmek için kullanılır.

![Image of Class](https://github.com/dogukankayhan/yazilim-mimarisi-ve-tasarim/blob/master/bridge.png)

mplementationA , ImplementationB : Esas fonksiyonaliteyi içerisinde barındıran classlar.

Bridge  :  ImplementionA ve ImplementationB classının türediği interface. Bu interface’in görevi abstraction ile Implementation classları arasında köprü görevi görmesi ve onları bağlamasıdır.

Abstraction : Abstraction classı, bridge üzerinden esas classlara ve onların metotlarına ulaşarak bunları clienta ulaştırır. Böylece implementasyon classlarını clienttan soyutlamış olur.



```.css
interface Bridge
  {
    string OperationImp();
  }
```

```.css
class ImplementationA : Bridge
  {
     public string OperationImp()
     {
       return "Implementation A";
     }
  }
```

```.css
class ImplementationB : Bridge
  {
     public string OperationImp()
     {
       return "Implementation B";
     }
  }
```

```.css
class Abstraction 
 { 
   Bridge bridge;  

   public Abstraction(Bridge Implementation) 
   {  bridge = Implementation;  }  

   public string Operation()  
   {  
     return "Abstraction <<bridge>> " + bridge.OperationImp();  
   }  
}
```

```.css
class Program
 {
   static void Main(string[] args)
   {
      Console.WriteLine("Bridge Pattern \n");
      Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
      Console.WriteLine(new Abstraction(new ImplementationB()).Operation());

     Console.ReadKey();
   }
 }
```
```.css
  interface Bridge
  {
    string OperationImp();
  }

  class ImplementationA : Bridge
  {
     public string OperationImp()
     {
       return "Implementation A";
     }
  }

  class ImplementationB : Bridge
  {
     public string OperationImp()
     {
       return "Implementation B";
     }
  }
 
 class Abstraction 
 { 
   Bridge bridge;  

   public Abstraction(Bridge Implementation) 
   {  bridge = Implementation;  }  

   public string Operation()  
   {  
     return "Abstraction <<bridge>> " + bridge.OperationImp();  
   }  
}
 class Program
 {
   static void Main(string[] args)
   {
      Console.WriteLine("Bridge Pattern \n");
      Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
      Console.WriteLine(new Abstraction(new ImplementationB()).Operation());

     Console.ReadKey();
   }
 }
```









## Strategy Tasarım Deseni
Bir fonksiyonun birden fazla yapılış şekli olduğu takdirde, bu fonksiyonelliği farklı versiyonlarıyla kullanmak isteyen içerik nesnesinin davranışlarına ilişkin bir design patternidir.

Birden fazla concrete strategy classımız olduğunda bunları bir strategy class üzerinden clienta sunmak, strategy classına da bu concrete tiplere ait ortak ata olan interfaceyi vermek , ilerleyen zamanlarda bu concrete tiplere bir yenisi daha eklendiğinde , işimizi kolaylaştıracak, bu durumda tek yapmamız gereken bu concrete tipi ortak interfaceden türetmek yeterli olacaktır. Strategy tasarım kalıbının da yaptığı tam olarak budur.
![Image of Class](https://github.com/dogukankayhan/yazilim-mimarisi-ve-tasarim/blob/master/strategy.png)

Aşağıda biri XmlSerialize yapmak diğeri ise BinarySerilalize yapmak üzere iki adet concrete tipimiz var ve bunların ikisi de ISerializeable interfacesinden türetilmiştir.

```.cs
//Base Interface
 interface ISerializable
 {
    void Serialize(string str);
    void Deserialize(string str);
 }

//Concrete tip 1
 class XmlSerializer : ISerializable
 {
    public void Deserialize(string str)
    {
      Console.WriteLine("xml ters serileştirme");
    }

    public void Serialize(string str)
    {
      Console.WriteLine("xml serileştirme");
    }
 }

 //Concrete tip 2
 class BinarySeriazlier : ISerializable
 {
    public void Deserialize(string str)
    {
      Console.WriteLine("binary ters serileştirme");
    }

    public void Serialize(string str)
    {
      Console.WriteLine("binary serileştirme");
    }
  }
```
Serializer sınıfı ise bizim strategy sınıfımızdır. Client tamamiyle bu class ile iletişime geçecek ve gönderilen argumanlar bu sınıf üzerinden değerlendirilecektir.

```.cs
//Context tip
 class Serializer
 {
    ISerializable _serializer;

    public Serializer(ISerializable serializer)
    {
     _serializer = serializer;
    }

    public void Serialize(string str)
    {
    _serializer.Serialize(str);
    }

    public void Deserialize(string str)
   {
    _serializer.Deserialize(str);
   }
 }

```
Client tarafından yapılması gereken tek şey strategy classımız olan Serializer sınıfına ilgili parametrenin gönderilmesi ve çalıştırılmasıdır. İlerleyen zamanlarda Json serializer gibi bir yapının da yapıya eklenmek istendiğini düşünürsek yapılması gereken tek şey bunu ISerializable’dan kalıtmak olacak ve bu şekilde yeni concrete sınıfımız sisteme entegre olmuş olacak.
```.cs
class Program
 {
   static void Main(string[] args)
   {
       Serializer srz = new Serializer(new XmlSerializer());

       srz.Serialize("Stragey");
       srz.Deserialize("Stragey");

       srz = new Serializer(new BinarySeriazlier());

       srz.Serialize("");
       srz.Deserialize("");
    }
 }
```




