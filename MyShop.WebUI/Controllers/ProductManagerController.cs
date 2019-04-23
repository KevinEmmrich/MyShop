using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
            // lets add three new products so I don't have to add manually everytime -- not working as expected
            //List<Product> products = new List<Product>();
            //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 1", Description = "Test 1 description", Category = "Toys", Price = 15.00M, Image = "image1" });
            //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 2", Description = "Test 2 description", Category = "Books", Price = 25.00M, Image = "image2" });
            //products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "Test 3", Description = "Test 3 description", Category = "Toys", Price = 100.00M, Image = "image3" });

        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string id)
            {
            Product productToEdit = context.Find(id);
               if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Commit();
                return RedirectToAction("Index");
            }

        }


        public ActionResult Delete(string id)
        {
            //Customer customer = customers.FirstOrDefault(c => c.Id == id);  // little shorter
            Product productToDelete = context.Find(id);  // little shorter

            if (productToDelete == null)
            {
                return HttpNotFound($"No matching ID if {id} found to delete.");
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Product productToDelete = context.Find(id);

            if (productToDelete == null)
            {
                return HttpNotFound($"No matching ID if {id} found to delete.");
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }  // end class ProductManagerController : Controller
} // end namespace MyShop.WebUI.Controllers