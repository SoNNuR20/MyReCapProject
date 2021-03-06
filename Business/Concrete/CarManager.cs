﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

		[SecuredOperation("car.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		//[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			Add(car);
			if (car.DailyPrice<200)
			{
				throw new Exception("200'den küçük olamaz.");
			}
			Add(car);
			return null;
		}

		[SecuredOperation("car.delete,admin")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		//[CacheAspect]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),Messages.CarListed);
		}

		[CacheAspect]
		//[PerformanceAspect(5)]
		public IDataResult<Car> GetById(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.CarListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == id),Messages.CarListed);
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == id),Messages.CarListed);
		}
		[SecuredOperation("car.update,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}
