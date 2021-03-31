using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCars();
            //GetRenkSecenekleri();
            //GetCarByColorId();
            //GetCarByBrandId();
            //AddCar();
            Console.ReadKey();
        }
        
        static void GetCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Araç kiralama sistemimize hoşgeldiniz");
            Console.WriteLine("<<<<<<<<<< Araçlarımız >>>>>>>>>> \n");

            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine("<<<" + car.Description + ">>>");
                Console.WriteLine("Günlük fiyatı: " + car.DailyPrice);
                Console.WriteLine("Model yılı: " + car.ModelYear);
                Console.WriteLine();
            }
        }
        
        static void GetRenkSecenekleri()
        {
            Console.WriteLine("<<<<<<<<<< Renk seçenekleri >>>>>>>>>> \n");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("<<<" + color.ColorName + ">>>");
            }
            Console.WriteLine();
        }
    
        static void GetCarByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Hangi renkteki araçları görmek istiyorsunuz?");
            Console.WriteLine("Renk seçin--> 1:kırmızı 2:siyah 3:mavi 4:beyaz");

            int renkSecim = Convert.ToInt32(Console.ReadLine());

            foreach (var cars in carManager.GetCarsByColorId(renkSecim))
            {
                Console.WriteLine(cars.Description);
            }
        }
    
        static void GetCarByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Hangi marka araçları görmek istiyorsunuz?");
            Console.WriteLine("Marka seçin--> 1:kırmızı 2:siyah 3:mavi 4:beyaz");

            int markaSecim = Convert.ToInt32(Console.ReadLine());

            foreach (var cars in carManager.GetCarsByBrandId(markaSecim))
            {
                Console.WriteLine(cars.Description);
            }
        }
        static void AddCar()
        {
            Car car = new Car();
           
            CarManager carManager = new CarManager(new EfCarDal());   
         
            Console.Write("Aracın marka Id sini giriniz:");
            car.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Aracın renk Id sini giriniz:");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
                   
            Console.Write("Lütfen Günlük Kiralama Ücretini Giriniz:");
            car.DailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Lütfen Açıklama Giriniz:");
            car.Description = Convert.ToString(Console.ReadLine());

            Console.Write("Lütfen Araç model yılını Giriniz:");
            car.ModelYear = (short)Convert.ToInt32(Console.ReadLine());
          
            carManager.Add(car);

           
        }
    }
}
