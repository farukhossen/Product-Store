﻿using ProductApp.Context;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            
            return View(db.Products.ToList());
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null) 
                return HttpNotFound();
            return View(product);
        }

        [HttpGet]
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
            
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit( Product product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                View(product); 
            }
            catch
            {
                return View();
            }
            return View();
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)        
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product prod)
        {
            Product product = new Product();
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                product = db.Products.Find(id);
                if (product == null)
                    return HttpNotFound();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View(product);
        }
    }
}
