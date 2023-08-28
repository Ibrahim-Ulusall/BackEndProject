using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Contants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

		[SecuredOperation("admin,product.add")]
		[ValidationAspect(typeof(ProductValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Add(Product product)
		{

			IResult? result = BusinessRules.Run
				(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
				CheckIfProductNameExists(product.ProductName ?? "<Null>"),
				CheckIfCategoryCount());
			
			if (result != null)
				return result;
			_productDal.Add(product);
			return new SuccessResult(Messages.AddedMessage);
		}

		[CacheAspect(duration:60)]
		public IDataResult<List<Product>> GetAll()
		{
			var data = _productDal.GetAll();
			return new SuccessDataResult<List<Product>>(data, Messages.ProductListed);
		}
		
		[CacheAspect(duration:10)]
		public IDataResult<List<Product>> GetAllByCategory(int id)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
		}
		
		[CacheAspect]
		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}

		private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
		{
			int a = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
			if (a > 20)
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

		[SecuredOperation("product.delete,admin")]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Delete(Product product)
		{
			 _productDal.Delete(product);
			return new SuccessResult(Messages.ProductDeleted);
		}
		
		[SecuredOperation("product.update,admin")]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Update(Product product)
		{
			_productDal.Update(product);
			return new SuccessResult(Messages.ProductUpdated);
		}
	}
}
