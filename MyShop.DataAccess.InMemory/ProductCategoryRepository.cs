using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
                // lets add three new products so I don't have to add manually everytime 
                productCategories.Add(new ProductCategory() { Id = Guid.NewGuid().ToString(), Category = "Toys" });
                productCategories.Add(new ProductCategory() { Id = Guid.NewGuid().ToString(), Category = "Books"});
                SaveCache();
            }
        }

        public void SaveCache()
        {
            cache["productCategories"] = productCategories;
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception($"Product Category to be updated Not Found!");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory productCategoryToFind = productCategories.Find(p => p.Id == id);
            if (productCategoryToFind != null)
            {
                return productCategoryToFind;
            }
            else
            {
                throw new Exception($"Cannot find product category with ID of {id}!");
            }

        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id) 
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception($"Cannot find product category with ID of {id} to delete!");
            }
        }



    } //  end class ProductCategoryRepository
} // end namespace MyShop.DataAccess.InMemory
