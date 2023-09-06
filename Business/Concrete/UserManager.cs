using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Users;
using Core.Utilities.Results;
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

		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult("User Added");
		}

		[CacheAspect]
		public User GetByMail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		[SecuredOperation("admin,user.delete")]
		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult("User Deleted");
		}
		
		[SecuredOperation("admin,user.update")]
		[ValidationAspect(typeof(UserValidator))]
		[CacheRemoveAspect("IUserService.Get")]
		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult("User Updated");

		}

		public IDataResult<List<User>> GetAll()
		{
			var result = _userDal.GetAll();
			return new SuccessDataResult<List<User>>(data: result);
		}

		public IDataResult<User> Get(int userId)
		{
			var result = _userDal.Get(u => u.Id == userId);
			return new SuccessDataResult<User>(data: result);
		}
	}
}
