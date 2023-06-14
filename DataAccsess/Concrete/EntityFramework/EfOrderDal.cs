﻿using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework
{
	public class EfOrderDal : EfEntityRepositoryBase<Orders, NorthwindContext>, IOrderDal
	{
	}
}
