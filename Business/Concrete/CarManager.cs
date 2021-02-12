﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void Add(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Add(car);
				Console.WriteLine("Araba kaydedildi");
			}
			else
			{
				Console.WriteLine(" günlük fiyatı 0'dan büyük giriniz.");
			}
		}

		public void Delete(Car car)
		{
			_carDal.Delete(car);
			Console.WriteLine("Araba silindi");
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public List<Car> GetByDailyPrice(decimal min, decimal max)
		{
			return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
		}

		public Car GetById(int id)
		{
			return _carDal.Get(c => c.CarId == id);
		}

		public List<Car> GetCarsByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		public void Update(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Update(car);
			}
			else
			{
				Console.WriteLine("günlük fiyatı 0'dan büyük giriniz. ");
			}
		}
	}
}