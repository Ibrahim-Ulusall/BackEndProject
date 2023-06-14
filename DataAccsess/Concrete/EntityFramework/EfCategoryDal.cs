using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.Entity_Framework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {
        
    }
}
