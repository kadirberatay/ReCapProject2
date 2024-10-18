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
			RentalManager rentalManager = new RentalManager(new EfRentalDal());

			//CarUpdate(carManager);
			//CarDelete(carManager);
			CarList(carManager);
			//BrandAdd(brandManager);
			//CarAdd(carManager);

			//CarManager carManagerr = new CarManager(new InMemoryCarDal());
			//Car carr = carManagerr.GetById(1);
			//Console.WriteLine(carr.CarId);

			//carManager.Add(new Car { BrandId = 7, CarId = 4, ColorId = 1, DailyPrice = 200, Description = "Suzuki", ModelYear = 2010 });


			var result = carManager.GetCarDetails();

			if (result.Success == true)
			{
				foreach (var cars in result.Data)
				{
					Console.WriteLine(cars.CarName + "/" + cars.BrandName);
				}
			}

			else
			{
				Console.WriteLine(result.Message);
			}

			var rentalResult = rentalManager.Add(new Rental
			{ RentalId = 2, CarId = 1, CustomerId = 1, RentDate = new DateTime(2024, 01, 01) });
			Console.WriteLine(rentalResult.Message);



			foreach (var rental in rentalManager.GetAll().Data)
			{
				Console.WriteLine(rental.RentalId+"/"+rental.CarId);
			}

		}

		private static void CarAdd(CarManager carManager)
		{
			carManager.Add(new Car { CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 250, Description = "Mercedes C200", ModelYear = 2022 });
			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(car.Description);
			}
		}

		private static void CarDelete(CarManager carManager)
		{
			var result = carManager.Delete(new Car { CarId = 4 });
			Console.WriteLine(result.Message);
		}

		private static void CarUpdate(CarManager carManager)
		{
			carManager.Update(new Car { BrandId = 1, CarId = 4, ColorId = 1, DailyPrice = 5000, Description = "Pagani", ModelYear = 2024 });
		}

		private static void CarList(CarManager carManager)
		{
			foreach (var car in carManager.GetCarDetails().Data)
			{
				Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
			}
		}

		private static void BrandAdd(BrandManager brandManager)
		{
			brandManager.Add(new Brand { BrandId = 7, BrandName = "Volkswagen" });

			foreach (var brand in brandManager.GetAll().Data)
			{
				Console.WriteLine($"Brands: {brand.BrandId}, {brand.BrandName}");
			}
		}
	}
}
