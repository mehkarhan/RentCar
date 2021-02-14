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
            int i = 10;
            while(i!=4)
            {
                Console.WriteLine("Welcome to Rent Car System");
                Console.WriteLine(" 1-Car\n 2-Brand\n 3-Color\n 4-Exit\n ");
                Console.Write("Seçiminiz: ");
                i = int.Parse(Console.ReadLine());

                if (i==1)
                {
                    Console.WriteLine("Car Manage Page");
                    Console.WriteLine(" 1-Car Add\n 2-Car Update\n 3-Car Delete\n 4-Car List\n");
                    Console.Write("Seçiminiz: ");
                    int carChoose = int.Parse(Console.ReadLine());
                    switch (carChoose)
                    {
                        case 1:
                            CarAddTest();
                            break;
                        case 2:
                            CarUpdateTest();
                            break;
                        case 3:
                            CarDeleteTest();
                            break;
                        case 4:
                            CarTest();
                            break;
                        default:
                            break;
                    }
                }
                else if (i==2)
                {
                    Console.WriteLine("Brand Manage Page");
                    Console.WriteLine(" 1- Brand Add\n 2-Brand Update\n 3-Brand Delete\n 4-Brand List\n");
                    int brandChoose = int.Parse(Console.ReadLine());
                    switch (brandChoose)
                    {
                        case 1:
                            BrandAddTest();
                            break;
                        case 2:
                            BrandUpdateTest();
                            break;
                        case 3:
                            BrandDeleteTest();
                            break;
                        case 4:
                            BrandTest();
                            break;
                        default:
                            break;
                    }
                }
                else if (i==3)
                {
                    Console.WriteLine("Color Manage Page");
                    Console.WriteLine(" 1- Color Add\n 2-Color Update\n 3-Color Delete\n 4-Color List\n");
                    int colorChoose = int.Parse(Console.ReadLine());
                    switch (colorChoose)
                    {
                        case 1:
                            ColorAddTest();
                            break;
                        case 2:
                            ColorUpdateTest();
                            break;
                        case 3:
                            ColorDeleteTest();
                            break;
                        case 4:
                            ColorTest();
                            break;
                        default:
                            break;
                    }
                }
            }
            //CarAddTest();
            //CarUpdateTest();
            //carManager.GetById(carId);
            //CarTest();
            //BrandTest();
            //ColorTest();
            //carDeleteTest();
            //CarDeleteTest();
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Araç Listesi");
            CarTest();
            Console.Write("Silinecek Aracın ID'sini giriniz:");
            int deleteId = int.Parse(Console.ReadLine());
            Car deletedCar = carManager.GetById(deleteId).Data;
            var result=carManager.Delete(deletedCar);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarTest();
            Console.Write("Güncelleme yapmak istediğiniz Aracın ID'sini giriniz:");
            int updateId = int.Parse(Console.ReadLine());
            Car updateCar = carManager.GetById(updateId).Data;
            Console.WriteLine("BrandID:" + updateCar.BrandId);
            BrandTest();
            Console.Write("Yeni Marka nosunu yazınız:");
            updateCar.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Renk Kodu:" + updateCar.ColorId);
            ColorTest();
            Console.Write("Yeni Renk Kodunu yazınız:");
            updateCar.ColorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Yılı:" + updateCar.ModelYear);
            Console.Write("Model yılını giriniz:");
            updateCar.ModelYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Fiyatı:" + updateCar.DailyPrice);
            Console.Write("Fiyatı Güncelleyiniz:");
            updateCar.DailyPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Açıklaması:" + updateCar.Description);
            Console.Write("Açıklamayı yeniden giriniz:");
            updateCar.Description = Console.ReadLine();

            var result=carManager.Update(updateCar);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            

        }
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandTest();
            Console.Write("Marka seçiniz:");
            int brandChoose = int.Parse(Console.ReadLine());
            ColorTest();
            Console.Write("Renk seçiniz:");
            int colorChoose = int.Parse(Console.ReadLine());
            Console.Write("Araç Yılını giriniz:");
            int modelYear = int.Parse(Console.ReadLine());
            Console.Write("Fiyatını giriniz:");
            decimal fiyat = decimal.Parse(Console.ReadLine());
            Console.Write("Açıklamayı giriniz:");
            string aciklama = Console.ReadLine();
            var result = carManager.Add(new Car { BrandId = brandChoose, ColorId = colorChoose, ModelYear = modelYear, DailyPrice = fiyat, Description = aciklama });
            
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " - " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId+" - "+brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("***********" + car.CarId + ". Araç***********");
                    //Console.WriteLine("Car ID:"+car.CarId);
                    Console.WriteLine("Brand Name:" + car.BrandName);
                    Console.WriteLine("Color Name:" + car.ColorName);
                    Console.WriteLine("Model Year:" + car.ModelYear);
                    Console.WriteLine("Daily Price:" + car.DailyPrice);
                    Console.WriteLine("Car Description:" + car.Description);
                    Console.WriteLine("\n");
                }
                Console.WriteLine(result.Message);
            }
        }
        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandTest();
            Console.Write("Marka adını yapınız:");
            string brandName = Console.ReadLine();

            var result = brandManager.Add(new Brand {BrandName=brandName }) ;

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandTest();
            Console.Write("Güncelleme yapmak istediğiniz Markanın ID'sini giriniz:");
            int updateId = int.Parse(Console.ReadLine());
            Brand updateBrand = brandManager.GetById(updateId).Data;

            Console.Write("Yeni Markanın adını yazınız:");
            updateBrand.BrandName = Console.ReadLine();
            var result = brandManager.Update(updateBrand);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandTest();
            Console.Write("Silmek istediğiniz Markanın ID'sini giriniz:");
            int deleteId = int.Parse(Console.ReadLine());
            Brand deleteBrand = brandManager.GetById(deleteId).Data;
            var result = brandManager.Delete(deleteBrand);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorTest();
            Console.Write("Renk adını yapınız:");
            string colorName = Console.ReadLine();

            var result = colorManager.Add(new Color { ColorName = colorName });

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorTest();
            Console.Write("Güncelleme yapmak istediğiniz Markanın ID'sini giriniz:");
            int updateId = int.Parse(Console.ReadLine());
            Color updateColor = colorManager.GetById(updateId).Data;

            Console.Write("Yeni Markanın adını yazınız:");
            updateColor.ColorName = Console.ReadLine();
            var result = colorManager.Update(updateColor);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorTest();
            Console.Write("Silmek istediğiniz Markanın ID'sini giriniz:");
            int deleteId = int.Parse(Console.ReadLine());
            Color deleteColor = colorManager.GetById(deleteId).Data;
            var result = colorManager.Delete(deleteColor);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
