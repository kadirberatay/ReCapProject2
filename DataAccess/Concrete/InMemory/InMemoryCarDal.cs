using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemoryCarDal
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "Honda Civic", ModelYear = 2023 },
				new Car { CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 300, Description = "BMW 3.20", ModelYear = 2024 },
			};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
			_cars.Remove(carToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car GetById(int id)
		{
			return _cars.FirstOrDefault(p => p.CarId == id);
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.BrandId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
			carToUpdate.ModelYear = car.ModelYear;
			
		}
	}
}
