using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class CarManager:ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void Add(Car car)
		{
			if (car.Description.Length>2 && car.DailyPrice>0)
			{
				_carDal.Add(car);
				Console.WriteLine($"{car.Description} eklendi.");
			}
			else
			{
				Console.WriteLine("Araç eklenemedi.");
			}
			
		}

		public void Delete(Car car)
		{
			_carDal.Delete(car);
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public Car GetById(int id)
		{
			return _carDal.Get(p => p.CarId == id);
		}

		public List<Car> GetCarsByBrandId(int brandId)
		{
			return _carDal.GetAll(p => p.BrandId == brandId);
		}

		public List<Car> GetCarsByColorId(int colorId)
		{
			return _carDal.GetAll(p => p.ColorId == colorId);
		}

		public void Update(Car car)
		{
			_carDal.Update(car);
			Console.WriteLine($"{car.Description} güncellendi.");
		}
	}
}
