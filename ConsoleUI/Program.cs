using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("***********"+car.CarId+ ". Araç***********");
                //Console.WriteLine("Car ID:"+car.CarId);
                Console.WriteLine("Brand Name:" + car.BrandName);
                Console.WriteLine("Color Name:" + car.ColorName);
                Console.WriteLine("Daily Price:" + car.DailyPrice);
                Console.WriteLine("Car Description:" + car.Description);
                Console.WriteLine("\n");
            }
        }
    }
}
