using Core.Entities.Concrete.Users;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService
	{
		List<OperationClaim> GetClaims(User user);
		IResult Add(User user);
		IResult Delete(User user);
		IResult Update(User user);
		IDataResult<List<User>> GetAll();
		IDataResult<User> Get(int userId);
		User GetByMail(string email);
	}
}
