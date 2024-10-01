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

			carManager.Add(new Car{BrandId =1,CarId = 3,ColorId = 1,DailyPrice = 200,Description = "H",ModelYear = 2000});
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Description);
			}


			//CarManager carManagerr = new CarManager(new InMemoryCarDal());
			//Car carr = carManagerr.GetById(1);
			//Console.WriteLine(carr.CarId);

			//carManager.Add(new Car{CarId = 3,BrandId = 2,ColorId = 2,DailyPrice = 250,Description = "Mercedes C200", ModelYear = 2022});
			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine(car.Description);
			//}

			//Car carr = carManager.GetById(4);

			//if (carr != null)
			//{
			//	Console.WriteLine($"ID: {carr.CarId}, BrandID: {carr.BrandId}, RenkID: {carr.ColorId}, Model: {carr.ModelYear}, Açıklama: {carr.Description}");
			//}
			//else
			//{
			//	Console.WriteLine($"Araç bulunamadı.{4}");
			//}

			//carManager.Update(new Car
			//	{ CarId = 2, BrandId = 9, ColorId = 10, DailyPrice = 5000, Description = "Bugatti", ModelYear = 2024 });
			//Console.WriteLine("\nBütün araçlar listeleniyor...");
			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine(car.Description);
			//}

			//--------------------------------------------------------------------------
			//Car car = carManager.GetById(1); //ID'ye göre çekip yazdırma
			//Console.WriteLine($"Car ID: {car.CarId}, Description:{car.Description}");
			//--------------------------------------------------------------------------
		}


	}
}
