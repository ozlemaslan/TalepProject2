using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TabimProject.DataAccess.Interfaces;

namespace ProjectApp.UI.Controllers
{
    public class HomeController : Controller
    {
        ITalepRepository _talepRepository;
        IUserRepository _userRepository;
        public HomeController(ITalepRepository talepRepository, IUserRepository userRepository)
        {
            _talepRepository = talepRepository;
            _userRepository = userRepository;
        }
     
      
        public ActionResult Index()
        {
            
            return View(_talepRepository.GetAll());
        }

        //public ActionResult Login()
        //{
        //    if (Request.Cookies["login"] != null)
        //    {
        //        HttpCookie login = Request.Cookies["login"];
        //        Login user = new Login();
        //        user.UserName = login["mail"];
        //        user.Password = login["sifre"];

        //        return View(user);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(Login login)
        //{
        //    Session["email"] = login.UserName;
        //    if (login.RememberMe)
        //    {
        //        HttpCookie loginCookie = new HttpCookie("login");
        //        loginCookie.Values.Add("mail", login.UserName);
        //        loginCookie.Values.Add("sifre", login.Password);
        //        loginCookie.Expires = DateTime.Now.AddDays(15);

        //        Response.Cookies.Add(loginCookie);
        //    }

        //    User users = db.Users.FirstOrDefault(a => a.Email == login.UserName);
        //    Session["Kullanici"] = users;
        //    if (users == null)
        //    {
        //        return View(login);
        //    }


        //    if (VerifyPasswordHash(login.Password, users.passwordHash, users.passwordSalt))
        //    {

        //        if (users.IsAdmin == true)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Hata = "Giriş Bilgilerinizi Kontrol Ediniz.";
        //        return View(login);
        //    }
        //}


        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}