using Business.Abstract;
using Business.Contants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using DataAccsess.Concrete.Entity_Framework;
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
		ICategoryService _categoryManager;
		public ProductManager(IProductDal productDal, ICategoryService categoryManager)
		{
			_productDal = productDal;
			_categoryManager = categoryManager;
		}
		[ValidationAspect(typeof(ProductValidator))]
		public IResult Add(Product product)
		{

			IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
				CheckIfProductNameExists(product.ProductName),
				CheckIfCategoryCount());
			if (result != null)
				return result;
			_productDal.Add(product);
			return new SuccessResult(Messages.AddedMessage);
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

		private IResult CheckIfProductNameExists(string name)
		{
			bool result = _productDal.GetAll(p => p.ProductName == name).Any();

			if (result)
			{
				return new ErrorResult("Aynı isimde Ürün sistemde mevcut!");
			}

			return new SuccessResult();
		}

		private IResult CheckIfCategoryCount()
		{
			int result = _categoryManager.GetAll().Data.Count;
			if (result > 15)
				return new ErrorResult("Mevcut Kategori Sayısı 15\'i Geçemez!");
			return new SuccessResult();
		}
	}
}
