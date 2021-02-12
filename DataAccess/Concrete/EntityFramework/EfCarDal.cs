using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : ICarDal
	{
		public void Add(Car entity)
		{
			using (MyRentACarContext context=new MyRentACarContext())
			{
				var addedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;  //veritabanında ekledik
				context.SaveChanges();

			}
		}

		public void Delete(Car entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var deletedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;  //veritabanında sildik
				context.SaveChanges();

			}
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return context.Set<Car>().SingleOrDefault(filter);
			}
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return filter == null
					? context.Set<Car>().ToList()
					: context.Set<Car>().Where(filter).ToList();
			}
		}

		public void Update(Car entity)
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
