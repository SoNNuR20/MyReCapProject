using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfColorDal : IColorDal
	{
		public void Add(Color entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var addedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;  //veritabanında ekledik
				context.SaveChanges();

			}
		}

		public void Delete(Color entity)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				var deletedEntity = context.Entry(entity); //veri kaynağıyla ilişkilendirdik
				deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;  //veritabanında sildik
				context.SaveChanges();

			}
		}

		public Color Get(Expression<Func<Color, bool>> filter)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return context.Set<Color>().SingleOrDefault(filter);
			}
		}

		public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
		{
			using (MyRentACarContext context = new MyRentACarContext())
			{
				return filter == null
					? context.Set<Color>().ToList()
					: context.Set<Color>().Where(filter).ToList();
			}
		}

		public void Update(Color entity)
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
