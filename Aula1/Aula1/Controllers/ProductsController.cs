using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula1.Context;
using Aula1.Models;

namespace Aula1.Controllers
{
    public class ProductsController : Controller
    {
        private EFContext context = new EFContext();
        //	GET:	Produtos
        public ActionResult Index()
        {
            var products = context.Products.Include(c => c.Category).
                            Include(f => s.Supplier).OrderBy(n => n.Name);
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //	GET:	Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(b => b.Name), "CategoryId", "Name");
            ViewBag.FabricanteId = new SelectList(context.Suppliers.OrderBy(b => b.Name), "SupplierId", "Name");
            return View();
        }

        //	POST:	Produtos/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
