using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore2Shop.Common;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;
using NetCore2Shop.web.Models;
using Newtonsoft.Json;

namespace NetCore2Shop.web.Controllers {
    public class LoginController : Controller
    {

        protected UserManager<AppUser> userManager;
        protected SignInManager<AppUser> signInManager;
        public LoginController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel user, string returnUrl = null)
        {
            if (!CheckValidateCode(user.Code)) {
                return View(user);
            }
            var result =
                await signInManager.PasswordSignInAsync(user.Name, user.Password, user.RemberMe,
                    lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Error","用户名或密码错误");
                return View(user);
            }
            return RedirectToLocal(returnUrl);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public IActionResult Regist()
        {
            return View(new RegistViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regist(RegistViewModel user)
        {
            if (!CheckValidateCode(user.Code)) {
                return View(user);
            }
            if (!TryValidateModel(user)) {
                return View(user);
            }
            if (user.Password1 != user.Password) {
                ModelState.AddModelError("Error", "两次密码不一致");
                return View(user);
            }
            var appuser = new AppUser {
                UserName = user.UserName,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                DisplayName = user.UserName + new Random().Next()
            };
            var result = await userManager.CreateAsync(appuser, user.Password);
            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogonOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckValidateCode(string code)
        {
            var sessioncode = HttpContext.Session.GetString("code");
            if (!string.IsNullOrEmpty(sessioncode)) {
                if (sessioncode != code) {
                    ModelState.AddModelError("Error", "验证码错误！");
                    return false;
                }
            }
            return true;
        }

        public string ValidateCoedBase64()
        {
            var code = ValidateCode.CreateValidateCode(4);
            HttpContext.Session.SetString("code", code);
            return ValidateCode.GetImgBase64(code);
        }

        private async Task CheckCookiesInfo()
        {
            if (null != Request.Cookies["shopUid"] && null != Request.Cookies["shopPwd"]) {
                string id = Request.Cookies["shopUid"];
                string pwd = Request.Cookies["shopPwd"];
//                var user = await AppUserRepo.GetAsync(new Guid(id));
//                if (null == user || pwd != user.Password) {
//                    HttpContext.Session.SetString("shopUser", JsonConvert.SerializeObject(user));
//                }
//                else {
//                    Response.Cookies.Delete("shopUid");
//                    Response.Cookies.Delete("shopPwd");
//                }
            }
        }
    }
}