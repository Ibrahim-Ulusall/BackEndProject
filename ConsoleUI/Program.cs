using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
ProductManager productManager = new ProductManager(new EfProductDal());


foreach(Product product in productManager.GetAllByCategory(1))
{
    Console.WriteLine(product.ProductName);
}
