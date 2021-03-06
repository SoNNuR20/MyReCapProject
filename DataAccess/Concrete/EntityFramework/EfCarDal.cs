﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, MyRentACarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (MyRentACarContext context=new MyRentACarContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 join co in context.Colors
							 on c.ColorId equals co.Id
							 select new CarDetailDto
							 {
								 Id = c.Id,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice,
								 Description = c.Description,
								 ModelYear = c.ModelYear
							 };
				return result.ToList();
			}
		}
	}
}
