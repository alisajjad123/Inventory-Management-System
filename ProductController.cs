using Inventory_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_management.Controllers
{
    public class ProductController : Controller
    {
        Inventory_management_SystemEntities db = new Inventory_management_SystemEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Displayproduct()
        {
            List <Product> List = db.Products.OrderByDescending(x => x.id).ToList();
            return View(List);
        }
        [HttpGet]
        public ActionResult Addproduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addproduct(Product prod)
        {
            db.Products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("Displayproduct");
        }
        [HttpGet]
        public ActionResult Editproduct(int id)
        {
            Product Prod = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(Prod);
        }
        [HttpPost]
        public ActionResult Editproduct(int id, Product pro)
        {
            Product Prod = db.Products.Where(x => x.id == id).SingleOrDefault();
            Prod.Product_name = pro.Product_name;
            Prod.Product_quantity = pro.Product_quantity;
            db.SaveChanges();
            return RedirectToAction("Displayproduct");
        }
    }
}