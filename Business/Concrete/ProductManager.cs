using Business.Abstract;
using Business.Contants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;
		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IResult Add(Product product)
		{
			if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
			{
				_productDal.Add(product);
				return new SuccessResult(Messages.AddedMessage);
			}
			return new ErrorResult();
		}

		public IDataResult<List<Product>> GetAll()
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
		}

		public IDataResult<List<Product>> GetAllByCategory(int id)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}

		private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
		{
			int a = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
			if (a > 10)
				return new ErrorResult("Bir Kategoride en fazla on ürün olabilir.");
			return new SuccessResult();
		}
	}
}
