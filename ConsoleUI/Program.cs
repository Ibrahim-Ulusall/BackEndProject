using Business.Concrete;
using DataAccsess.Concrete.Entity_Framework;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;

static void ProductTest()
{
	ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));


	foreach (var product in productManager.GetProductDetails().Data)
	{
		Console.WriteLine(String.Format("{0:0000}  {1:30}  {2:30}  {3:0000000000}", product.ProductId, product.CategoryName, product.ProductName, product.UnitsInStock));
	}
}

static void CategoryTest()
{
	CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
	foreach (var category in categoryManager.GetAll().Data)
	{
		Console.WriteLine(category.CategoryName);
	}
}

CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


Console.WriteLine(categoryManager.GetById(1).Data.CategoryName);