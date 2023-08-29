using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Users;
using DataAccsess.Abstract;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;
        
		public UserManager(IUserDal userDal)
        {
			_userDal = userDal;
        }
		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		[SecuredOperation("admin,user.add")]
		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public void Add(User user)
		{
			_userDal.Add(user);
		}

		[CacheAspect]
		public User GetByMail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		[SecuredOperation("admin,user.delete")]
		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public void Delete(User user)
		{
			_userDal.Delete(user);
		}
		
		[SecuredOperation("admin,user.update")]
		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public void Update(User user)
		{
			_userDal.Update(user);
		}
	}
}
