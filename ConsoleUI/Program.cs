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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Brand Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.CarId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }

            Console.WriteLine("\n\nColor Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.CarId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }

            Console.WriteLine("\n\nId'si 3 olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescription");
            Car carById = carManager.GetById(4);
            Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.CarId).BrandName}\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");

            Console.WriteLine("\n");

            carManager.Add(new Car { CarId = 2, ColorId = 3, DailyPrice = 600, ModelYear = "2018", Description = "Otomatik Dizel" });
            brandManager.Add(new Brand { BrandName = "b" });

        }
	}
}
