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
            //UserAddTest();
            //UserTest();
            //UserDeleteTest();
            //UserUpdateTest();
            int i = 1;
            while (i != 7)
            {
                Console.WriteLine("Welcome to Rent Car System");
                Console.WriteLine(" 1-Car\n 2-Brand\n 3-Color\n 4-User\n 5-Customer\n 6-RentCar\n  7-Exit\n ");
                Console.Write("Seçiminiz: ");
                i = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    Console.WriteLine("Car Manage Page");
                    Console.WriteLine(" 1-Car Add\n 2-Car Update\n 3-Car Delete\n 4-Car List\n");
                    Console.Write("Seçiminiz: ");
                    int Choose = int.Parse(Console.ReadLine());
                    switch (Choose)
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
                else if (i == 2)
                {
                    Console.WriteLine("Brand Manage Page");
                    Console.WriteLine(" 1- Brand Add\n 2-Brand Update\n 3-Brand Delete\n 4-Brand List\n");
                    int Choose = int.Parse(Console.ReadLine());
                    switch (Choose)
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
                else if (i == 3)
                {
                    Console.WriteLine("Color Manage Page");
                    Console.WriteLine(" 1- Color Add\n 2-Color Update\n 3-Color Delete\n 4-Color List\n");
                    int Choose = int.Parse(Console.ReadLine());
                    switch (Choose)
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
                else if (i==4)
                {
                    Console.WriteLine("User Manage Page");
                    Console.WriteLine(" 1- User Add\n 2-User Update\n 3-User Delete\n 4-User List\n");
                    int Choose = int.Parse(Console.ReadLine());
                    switch (Choose)
                    {
                        case 1:
                            UserAddTest();
                            break;
                        case 2:
                            UserUpdateTest();
                            break;
                        case 3:
                            UserDeleteTest();
                            break;
                        case 4:
                            UserTest();
                            break;
                        default:
                            break;
                    }

                }
                else if (i == 5)
                {
                    Console.WriteLine("Customer Manage Page");
                    Console.WriteLine(" 1- User Add\n 2-User Update\n 3-User Delete\n 4-User List\n");
                    int Choose = int.Parse(Console.ReadLine());
                    switch (Choose)
                    {
                        case 1:
                            CustomerAddTest();
                            break;
                        case 2:
                            CustomerUpdateTest();
                            break;
                        case 3:
                            CustomerDeleteTest();
                            break;
                        case 4:
                            CustomerTest();
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
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
        //**************************USER**************************
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var users = userManager.GetAll().Data;
            foreach (var user in users)
            {
                Console.WriteLine("User ID :"+ user.UserId);
                Console.WriteLine("User Name :"+ user.FirstName);
                Console.WriteLine("User Lastname:"+ user.LastName);
                Console.Write("\n");

            }

        }
        private static void UserAddTest()
        {
            UserManager userManager=new UserManager(new EfUserDal());
            Console.Write("Ad giriniz:");
            string userFirstName = Console.ReadLine();
            Console.Write("Soyad giriniz:");
            string userLastname = Console.ReadLine();
            Console.Write("E-mail giriniz:");
            string userEmail = Console.ReadLine();
            Console.Write("Password giriniz:");
            string userPass = Console.ReadLine();
           
            
            var result = userManager.Add(
                new User {FirstName =userFirstName,LastName=userLastname,Email=userEmail,Password=userPass});
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            
        }
        
        private static void UserUpdateTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            UserTest();
            Console.Write("Güncellemek için Kullanıcı ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = userManager.GetById(chooseId).Data;

            Console.Write("FirstName:");
            result.FirstName = Console.ReadLine();
            Console.Write("LastName:");
            result.LastName = Console.ReadLine();
            Console.Write("E-Mail:");
            result.Email = Console.ReadLine();
            Console.Write("Password:");
            result.Password = Console.ReadLine();
            userManager.Update(result);
        }
        private static void UserDeleteTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            UserTest();
            Console.Write("Silmek için Kullanıcı ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = userManager.GetById(chooseId).Data;
            userManager.Delete(result);
        }

        //*********************Customer ***************************
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customers = customerManager.GetAll().Data;
            foreach (var customer in customers)
            {
                Console.WriteLine("User ID :" + customer.CustomerId);
                Console.WriteLine("User Name :" + customer.UserId);
                Console.WriteLine("User Lastname:" + customer.CompanyName);
                Console.Write("\n");

            }

        }
        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserTest();
            
            Console.Write("User Id giriniz:");
            int customerUI =int.Parse( Console.ReadLine());
            Console.Write("Company Name giriniz:");
            string customerCN = Console.ReadLine();
            var result = customerManager.Add(
                new Customer { UserId=customerUI,CompanyName=customerCN });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CustomerUpdateTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            CustomerTest();
            Console.Write("Güncellemek için Customer ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = customerManager.GetById(chooseId).Data;

            Console.Write("User Id giriniz:");
            result.CustomerId = int.Parse(Console.ReadLine());
            Console.Write("Company Name giriniz:");
            result.CompanyName = Console.ReadLine();
            customerManager.Update(result);
        }
        private static void CustomerDeleteTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            CustomerTest();
            Console.Write("Silmek için Customer ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = customerManager.GetById(chooseId).Data;
            customerManager.Delete(result);
        }


        //******************RENTAL CRUD*********************

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var customers = rentalManager.GetAll().Data;
            foreach (var customer in customers)
            {
                Console.WriteLine("User ID :" + customer.Id);
                Console.WriteLine("User Name :" + customer.CarId);
                Console.WriteLine("User Lastname:" + customer.CustomerId);
                Console.WriteLine("User Lastname:" + customer.RentDate);
                Console.WriteLine("User Lastname:" + customer.ReturnDate);
                Console.Write("\n");

            }

        }
        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarTest();
            
            Console.Write("Car Id giriniz:");
            int rentalCarId = int.Parse(Console.ReadLine());
            CustomerTest();
            Console.Write("Customer Id giriniz:");
            int rentalCustomerId = int.Parse(Console.ReadLine());
            Console.Write("Başlangıç tarihi giriniz(GG/AA/YYYY):");
            DateTime rentalRentDate = DateTime.Parse(Console.ReadLine());
            var result = rentalManager.Add(
                new Rental { CarId=rentalCarId,CustomerId=rentalCustomerId,RentDate=rentalRentDate });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void RentalUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            Console.Write("Güncellemek için Rental ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = rentalManager.GetById(chooseId).Data;

            //Console.Write("User Id giriniz:");
            //result.RentalId = int.Parse(Console.ReadLine());
            //Console.Write("Company Name giriniz:");
            //result.= Console.ReadLine();
            //rentalManager.Update(result);
        }
        private static void RentalDeleteTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalTest();
            Console.Write("Silmek için Rental ID'si giriniz:");
            int chooseId = int.Parse(Console.ReadLine());
            var result = rentalManager.GetById(chooseId).Data;
            rentalManager.Delete(result);
        }
    }
}
