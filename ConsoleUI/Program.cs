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

            bool islem = true;

            while (islem)
            {
                Console.WriteLine("----------Rent A Car----------" +
                        "\n 1.Araba Ekleme\n" +
                        "\n 2.Araba Güncelleme\n" +
                        "\n 3.Araba Silme\n" +
                        "\n 4.Arabaların Listelenmesi\n" +
                        "\n 5.Detaylı Listelenme\n" +
                        "\n 6.Arabaların Id'sine Göre Listelenmesi\n" +
                        "\n 7.Marka Id'sine Göre Listenlenmesi\n" +
                        "\n 8.Renk Id'sine Göre Listelenmesi\n" +
                        "\n 9.Islem\n\n" +
                        "Yukarıdakilerden hangisi işlemi gerçekleştirmek istiyorusunuz?"
                );

                int sayi = Convert.ToInt32(Console.ReadLine());
                switch (sayi)
                {
                    case 1:

                        Console.WriteLine("Color Listesi");
                        GetAllColor(colorManager);

                        Console.WriteLine("Brand Listesi");
                        GetAllBrand(brandManager);

                        Console.WriteLine("Brand Id:");
                        int brandIdAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id:");
                        int colorIdAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Model Year:");
                        string modelYearAdd = Console.ReadLine();

                        Console.WriteLine("Daily Price:");
                        decimal dailyPriceAdd = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Description:");
                        string descriptionAdd = Console.ReadLine();

                        Car carAdd = new Car
                        {
                            BrandId = brandIdAdd,
                            ColorId = colorIdAdd,
                            ModelYear = modelYearAdd,
                            DailyPrice = dailyPriceAdd,
                            Description = descriptionAdd
                        };
                        carManager.Add(carAdd);
                        break;

                    case 2:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Car Id:");
                        int carIdUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id:");
                        int colorIdUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Brand Id:");
                        int brandIdUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Model Year:");
                        string modelYearUpdate = Console.ReadLine();

                        Console.WriteLine("Daily Price:");
                        decimal dailyPriceUpdate = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Description:");
                        string descriptionUpdate = Console.ReadLine();
                        Car carUpdate = new Car
                        {
                            CarId = carIdUpdate,
                            ColorId = colorIdUpdate,
                            BrandId = brandIdUpdate,
                            ModelYear = modelYearUpdate,
                            DailyPrice = dailyPriceUpdate,
                            Description = descriptionUpdate
                        };
                        carManager.Update(carUpdate);
                        break;

                    case 3:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Hangi Id'ye sahip arabayı silmek istersin");
                        int carIdDelete = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(carManager.GetById(carIdDelete));
                        break;

                    case 4:
                        Console.WriteLine("Arabaların Listelenmesi: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\t Description");
                        GetAllCarDetails(carManager);
                        break;

                    case 5:
                        Console.WriteLine("Arabaların Listelenmesi: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\t Description");
                        GetAllCarDetails(carManager);
                        break;
                    case 6:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Görmek istediğiniz Id numarasını giriniz? ");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n Id'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year \tDaily Price\tDescription");
                        Car carById = carManager.GetById(carId);
                        Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");
                        break;
                    case 7:
                        GetAllBrand(brandManager);
                        Console.WriteLine("Hangi markaya sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nBrand Id'si {brandIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        foreach (var car in carManager.GetCarsByBrandId(brandIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;
                    case 8:
                        GetAllColor(colorManager);
                        Console.WriteLine("Hangi renge sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
                        int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nColor Id'si {colorIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
                        foreach (var car in carManager.GetCarsByColorId(colorIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                        }
                        break;

                    case 9:
                        islem = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;

                }
            }

        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t{car.BrandName}\t{car.ModelYear}\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId}\t{color.ColorName}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }

        }
	}
}
