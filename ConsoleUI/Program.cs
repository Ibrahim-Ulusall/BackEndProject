using Business.Concrete;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
ProductManager productManager = new ProductManager(new InMemoryProductDal());


foreach(Product product in productManager.GetAll())
{
    Console.WriteLine(product.ProductName);
}
//Console.WriteLine(String.Format("{0:3}|{1:3}|{2:20}|{3:000000000}|{4:00000}", product.ProductId, product.CategoryId, product.ProductName, product.UnitPrice, product.UnitInStock));
