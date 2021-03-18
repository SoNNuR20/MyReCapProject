using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;

		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Add(IFormFile formFile, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId));
			if (result!=null)
			{
				return result;
			}
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.CarImagesAdded);
		}

		public IResult Delete(CarImage carImage)
		{
			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.CarImageDeleted);
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
		}

		public IDataResult<CarImage> GetById(int id)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarId == id));
		}

		public IResult Update(IFormFile file, CarImage carImage)
		{
			var image = _carImageDal.Get(c => c.Id == carImage.Id);
			if (image == null)
			{
				return new ErrorResult("Image not found.");
			}

			var updatedFile = FileHelper.Update(file, image.ImagePath);
			if (!updatedFile.Success)
			{
				return new ErrorResult(updatedFile.Message);
			}
			carImage.ImagePath = updatedFile.Data;
			_carImageDal.Update(carImage);
			return new SuccessResult("Car image updated");
		}

		private IResult CheckIfCarImageCount(int id)
		{
			var result = _carImageDal.GetAll(ci => ci.CarId == id).Count;
			if (result>5)
			{
				return new ErrorResult(Messages.CarImageCountError);
			}
			return new SuccessResult();
		}


	}
}
