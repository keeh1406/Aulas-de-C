﻿using Aula1.Context;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(_context.Suppliers.OrderBy(s => s.Name));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplier = _context.Suppliers.Find(id.Value);

            if (supplier == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier); 
            
        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplier = _context.Suppliers.Find(id.Value);

            if (supplier == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(supplier);
        }
        #endregion


        #region Delete
        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplier = _context.Suppliers.Find(id.Value);

            if (supplier == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var s = _context.Suppliers.Find(supplier.SupplierId);
                _context.Suppliers.Remove(s);
                _context.SaveChanges();
                TempData["Message"] = "Fabricante " +supplier.Name.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            return View(supplier);

        } 
        #endregion

    }
}