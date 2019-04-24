using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();

                // let's see if we can add demo data for the inMemory processes.
                if (className == "Product")
                {
                    //List<Product> products = new List<Product>();
                    //products = (List<Product>)cache["products"];
                    //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 1", Description = "Test 1 description", Category = "Toys", Price = 15.00M, Image = "image1" });
                    //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 2", Description = "Test 2 description", Category = "Books", Price = 25.00M, Image = "image2" });
                    //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 3", Description = "Test 3 description", Category = "Toys", Price = 100.00M, Image = "image3" });
                    //SaveCache();
                }

                if (className == "ProductCategory")
                {
                    //List<ProductCategory> productCategories = new List<ProductCategory>();
                    //productCategories = (List<ProductCategory>)cache["productCategories"];
                    //// lets add two new product categories so I don't have to add manually everytime 
                    //productCategories.Add(new ProductCategory() { Id = Guid.NewGuid().ToString(), Category = "Toys" });
                    //productCategories.Add(new ProductCategory() { Id = Guid.NewGuid().ToString(), Category = "Books" });
                    //SaveCache();
                }


            }
        }

        public void SaveCache()
        {
            cache[className] = className;
        }
        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T itemToUpdate = items.Find(i => i.Id == t.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate = t;
            }
            else
            {
                throw new Exception($"{className} not found.");
            }
        }


        public T Find(string id)
        {
            T item = items.Find(i => i.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception($"{className} with Id of {id} not found.");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T itemToDelete = items.Find(p => p.Id == id);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
            else
            {
                throw new Exception($"Cannot find {className} with ID of {id} to delete!");
            }
        }





    } // end class InMemoryRepository<T>
} // end namespace MyShop.DataAccess.InMemory
