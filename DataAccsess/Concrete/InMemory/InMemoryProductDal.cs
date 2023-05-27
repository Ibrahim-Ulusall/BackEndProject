using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitInStock=15,UnitPrice=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitInStock=3,UnitPrice=900},
                new Product{ProductId=3,CategoryId=3,ProductName="Telefon",UnitInStock=2,UnitPrice=1500},
                new Product{ProductId=4,CategoryId=4,ProductName="Klavye",UnitInStock=65,UnitPrice=150},
                new Product{ProductId=5,CategoryId=5,ProductName="Mouse",UnitInStock=1,UnitPrice=85}
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
        //Urun listele
        public List<Product> GetAll()
        {
            return products;
        }
        //Urun guncelle
        public void Update(Product product)
        {
            Product productToUpdate = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
