using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	//public class InMemoryCarDal : ICarDal
	public class InMemoryBranDal
	{
		
		//	List<Car> _car;
		//		public InMemoryCarDal()
		//	   {
		//			_car = new List<Car> 
		//			{
		//				new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2021", DailyPrice=1200, Description="Peugeot 208" },
		//				new Car{CarId=2, BrandId=1, ColorId=2, ModelYear="2020", DailyPrice=1000, Description="Fiat Egea" },
		//				new Car{CarId=3, BrandId=2, ColorId=3, ModelYear="2019", DailyPrice=800, Description="Renault Clio" },
		//				new Car{CarId=4, BrandId=2, ColorId=1, ModelYear="2018", DailyPrice=600, Description="Hyundai Loniq" },
		//				new Car{CarId=5, BrandId=3, ColorId=2, ModelYear="2017", DailyPrice=400, Description="Mitsubishi L200" },
		//				new Car{CarId=6, BrandId=3, ColorId=3, ModelYear="2016", DailyPrice=200, Description="Seat Toledo" }
		//	    	};
		//		}
		//	public void Add(Car car)
		//	{
		//		_car.Add(car);
		//	}

		//	public void Delete(Car car)
		//	{
		//		Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
		//		_car.Remove(car);
		//	}

		//	public List<Car> GetAll()
		//	{
		//		return _car;
		//	}

		//	public List<Car> GetById(int carId)
		//	{
		//		return _car.Where(c => c.CarId == carId).ToList();
		//	}

		//	public void Update(Car car)
		//	{
		//		Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
		//				carToUpdate.BrandId = car.BrandId;
		//				carToUpdate.ColorId = car.ColorId;
		//				carToUpdate.ModelYear = car.ModelYear;
		//				carToUpdate.DailyPrice = car.DailyPrice;
		//				carToUpdate.Description = car.Description;
		//	}
	}
}
