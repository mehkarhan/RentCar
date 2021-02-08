using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=2000,Description="Audi A6"},
                new Car{CarId=2,BrandId=1,ColorId=2,ModelYear=2021,DailyPrice=1500,Description="Audi A5"},
                new Car{CarId=3,BrandId=2,ColorId=3,ModelYear=2019,DailyPrice=1900,Description="BMW X5"},
                new Car{CarId=4,BrandId=2,ColorId=4,ModelYear=2018,DailyPrice=1800,Description="BMW 5 Series"},
                new Car{CarId=5,BrandId=3,ColorId=5,ModelYear=2017,DailyPrice=1700,Description="Mercedes A Series"},
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c=>c.BrandId==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
