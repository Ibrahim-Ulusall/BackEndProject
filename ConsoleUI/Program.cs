using Business.Concrete;
using DataAccsess.Concrete.Entity_Framework;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;

//ProductTest();
//CategoryTest();
static void ProductTest()
{
	ProductManager productManager = new ProductManager(new EfProductDal());


	foreach (Product product in productManager.GetAll())
	{
		Console.WriteLine(product.ProductName);
	}
}

static void CategoryTest()
{
	CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
	foreach (var category in categoryManager.GetAll())
	{
		Console.WriteLine(category.CategoryName);
	}
}
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

Console.WriteLine(categoryManager.GetById(1).CategoryName);