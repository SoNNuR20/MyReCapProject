using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfBrandDal : IBrandDal
	{
		public void Add(Brand entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var addedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;  //veritabanında ekledik
				context.SaveChanges();

			}
		}

		public void Delete(Brand entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var deletedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;  //veritabanında sildik
				context.SaveChanges();

			}
		}

		public Brand Get(Expression<Func<Brand, bool>> filter)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return context.Set<Brand>().SingleOrDefault(filter);
			}
		}

		public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return filter == null
					? context.Set<Brand>().ToList()
					: context.Set<Brand>().Where(filter).ToList();
			}
		}

		public void Update(Brand entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var updatedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;  //veritabanında güncelledik
				context.SaveChanges();

			}
		}
	}
}
