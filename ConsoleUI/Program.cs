using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			//CarUpdate(carManager);
			//CarDelete(carManager);
			//CarList(carManager);
			//BrandAdd(brandManager);
			//CarAdd(carManager);

			//CarManager carManagerr = new CarManager(new InMemoryCarDal());
			//Car carr = carManagerr.GetById(1);
			//Console.WriteLine(carr.CarId);



			Car carr = carManager.GetById(4);

			if (carr != null)
			{
				Console.WriteLine($"ID: {carr.CarId}, BrandID: {carr.BrandId}, RenkID: {carr.ColorId}, Model: {carr.ModelYear}, Açıklama: {carr.Description}");
			}
			else
			{
				Console.WriteLine($"Araç bulunamadı.{4}");
			}

			//carManager.Update(new Car
			//	{ CarId = 2, BrandId = 9, ColorId = 10, DailyPrice = 5000, Description = "Bugatti", ModelYear = 2024 });
			//Console.WriteLine("\nBütün araçlar listeleniyor...");
			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine(car.Description);
			//}

			//--------------------------------------------------------------------------
			Car car = carManager.GetById(4); //ID'ye göre çekip yazdırma
			Console.WriteLine($"Car ID: {car.CarId}, Description:{car.Description}");
			//--------------------------------------------------------------------------
		}

		private static void CarAdd(CarManager carManager)
		{
			carManager.Add(new Car { CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 250, Description = "Mercedes C200", ModelYear = 2022 });
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Description);
			}
		}

		private static void CarDelete(CarManager carManager)
		{
			carManager.Delete(new Car { CarId = 1 });
		}

		private static void CarUpdate(CarManager carManager)
		{
			carManager.Update(new Car { BrandId = 1, CarId = 4, ColorId = 1, DailyPrice = 5000, Description = "Pagani", ModelYear = 2024 });
		}

		private static void CarList(CarManager carManager)
		{
			foreach (var car in carManager.GetCarDetails())
			{
				Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
			}
		}

		private static void BrandAdd(BrandManager brandManager)
		{
			brandManager.Add(new Brand { BrandId = 7, BrandName = "Volkswagen" });

			foreach (var brand in brandManager.GetAll())
			{
				Console.WriteLine($"Brands: {brand.BrandId}, {brand.BrandName}");
			}
		}
	}
}
