using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebsiteASPEntities objWebsiteASPEntities = new WebsiteASPEntities();
        public ActionResult Index()
        {
            List<Product_2119110250> lstPro = new List<Product_2119110250>();
             lstPro = objWebsiteASPEntities.Product_2119110250.ToList();
            var lstCategory = objWebsiteASPEntities.Category_2119110250.ToList();
            var lstBrand = objWebsiteASPEntities.Brand_2119110250.ToList();

            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = lstPro;
            objHomeModel.ListCategory = lstCategory;
            objHomeModel.ListBrand = lstBrand;
            return View(objHomeModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Context.User_2119110250 _user)
        {
            if (ModelState.IsValid)
            {
                var check = objWebsiteASPEntities.User_2119110250.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Pass = ConvertMD5.GetMD5(_user.Pass);
                    _user.IsAdmin = false;
                    objWebsiteASPEntities.Configuration.ValidateOnSaveEnabled = false;
                    objWebsiteASPEntities.User_2119110250.Add(_user);
                    objWebsiteASPEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }

            //Kiem tra va luu vao database
            return View("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string pass)
        {
            if (ModelState.IsValid)
            {
                var f_password = ConvertMD5.GetMD5(pass);
                var data = objWebsiteASPEntities.User_2119110250.Where(s => s.Email.Equals(email) && s.Pass.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().UserId;
                    Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
            }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
