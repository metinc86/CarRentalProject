using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1, BrandId=1, ColorId = 1, DailyPrice=300, ModelYear=2020, Description="Ford Focus" },
                new Car {Id=2, BrandId=2, ColorId = 3, DailyPrice=400, ModelYear=2021, Description="Mercedes A180" },
                new Car {Id=3, BrandId=2, ColorId = 1, DailyPrice=450, ModelYear=2020, Description="Mercedes C180" },
                new Car {Id=4, BrandId=3, ColorId = 2, DailyPrice=400, ModelYear=2021, Description="BMW 3.2" },
                new Car {Id=5, BrandId=2, ColorId = 1, DailyPrice=500, ModelYear=2022, Description="Mercedes E200" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);  

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            car.DailyPrice = car.DailyPrice;
            car.Description = car.Description;
            car.ModelYear = car.ModelYear; 
        }
        public List<Car> GetAllByCategoryId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
