﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult("Yeni renk eklendi");
		}

		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult("Renk silindi");
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),"Markalar listelendi");

		}

		public IDataResult<Color> GetById(int id)
		{
			return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id),"Markalar listelendi");
		}

		[ValidationAspect(typeof(ColorValidator))]
		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult("Renkler güncellendi");
		}
	}
}
