using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
	public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
		where TEntity: class,IEntity,new()
		where TContext : DbContext,new()
	{
		#region Add
		public void Add(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addEntity = context.Entry(entity);
				addEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}
		#endregion

		#region Delete
		public void Delete(TEntity entity)
		{
			using(TContext context = new TContext())
			{
				var deleteEntity = context.Entry(entity);
				deleteEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}
		#endregion

		#region Get
		public TEntity? Get(Expression<Func<TEntity, bool>> filter)
		{
			using (TContext context = new TContext())
			{
				return context.Set<TEntity>().SingleOrDefault(filter);	
			}
		}
		#endregion

		#region GetAll
		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
		{
			using (TContext context = new TContext())
			{
				return filter == null ? context.Set<TEntity>().ToList() : 
					context.Set<TEntity>().Where(filter).ToList();
			}
		}

		#endregion

		#region Update
		public void Update(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var updateEntity = context.Entry(entity);
				updateEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		#endregion

	}
}
