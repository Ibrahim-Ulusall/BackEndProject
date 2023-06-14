using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> products;

        public InMemoryProductDal()
        {
            products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitsInStock=3,UnitPrice=900},
                new Product{ProductId=3,CategoryId=3,ProductName="Telefon",UnitsInStock=2,UnitPrice=1500},
                new Product{ProductId=4,CategoryId=4,ProductName="Klavye",UnitsInStock=65,UnitPrice=150},
                new Product{ProductId=5,CategoryId=5,ProductName="Mouse",UnitsInStock=1,UnitPrice=85}
            };
        }
        //Urun ekle
        public void Add(Product product)
        {
            products.Add(product);
        }

        //Urun sil
        public void Delete(Product product)
        {
            Product productToDelete = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //Urun guncelle
        public void Update(Product product)
        {
            Product productToUpdate = products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
                
        }
    }
}
