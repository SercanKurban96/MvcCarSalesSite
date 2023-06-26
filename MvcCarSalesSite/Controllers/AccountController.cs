using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MvcCarSalesSite.Identity;
using MvcCarSalesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCarSalesSite.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register p)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.Email = p.Email;
                user.UserName = p.Username;

                var result = _userManager.Create(user, p.Password);

                if (result.Succeeded)
                {
                    if (_roleManager.RoleExists("user"))
                    {
                        _userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası");    
                }
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login p, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Find(p.Username, p.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = p.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(p);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //Get
        public ActionResult MyProfile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = _userManager.FindById(id);
            var data = new EditProfile()
            {
                EditProfileID = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Username = user.UserName
            };
            return View(data);
        }

        [HttpPost]
        public ActionResult MyProfile(EditProfile p)
        {
            var user = _userManager.FindById(p.EditProfileID);
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.UserName = p.Username;
            user.Email = p.Email;
            _userManager.Update(user);
            return View("Update");
        }


        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePass(ChangePassword p)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.ChangePassword(User.Identity.GetUserId(), p.OldPassword, p.NewPassword);
                return View("Update");
            }
            return View(p);
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}