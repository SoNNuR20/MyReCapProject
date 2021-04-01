
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.CarImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetByCarId(int carid)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarId == carid));

        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(ci => ci.CarId == carImage.CarId).ImagePath, file);
            carImage.CarImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        private IResult CheckIfCarImageCount(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }
    }
}