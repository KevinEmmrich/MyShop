using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products; 

      public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
                // lets add three new products so I don't have to add manually everytime 
                products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 1", Description = "Test 1 description", Category = "Toys", Price = 15.00M, Image = "image1" });
                products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 2", Description = "Test 2 description", Category = "Books", Price = 25.00M, Image = "image2" });
                products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 3", Description = "Test 3 description", Category = "Toys", Price = 100.00M, Image = "image3" });
                SaveCache();
            }
        }

        public void SaveCache()
        {
            cache["products"] = products;
        }
        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => product.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product to be updated Not Found!");
            }
        }

        public Product Find(string id)
        {
            Product productToFind = products.Find(p => p.Id == id);
            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception($"Cannot find product with ID of {id}!");
            }

        }


        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string id)
        {
            Product productToDelete = products.Find(p => p.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception($"Cannot find product with ID of {id} to delete!");
            }
        }


    } // end class ProductRepository
} // end namespace MyShop.DataAccess.InMemory
