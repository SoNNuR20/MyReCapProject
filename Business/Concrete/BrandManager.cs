using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public IResult Add(Brand brand)
		{
			if (brand.BrandName.Length > 2)
			{
				_brandDal.Add(brand);
				return new SuccessResult("yeni marka eklendi");
			}
			else
			{
				return new ErrorResult("marka adının uzunluğu en az iki karakter olmalıdır.");
			}
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult("Marka silindi");
		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), "Markalar listelendi");

		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand> (_brandDal.Get(c => c.BrandId == id), "Markalar listelendi");
		}

		public IResult Update(Brand brand)
		{
			if (brand.BrandName.Length >= 2)
			{
				_brandDal.Update(brand);
				return new SuccessResult("Marka Güncellendi.");
			}
			else
			{
				return new SuccessResult("marka adının uzunluğu en az iki karakter olmalıdır.");
			}
		}
	}
}
