using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(User user);
	}
}
