using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using NetCore2Shop.Common;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Data.Repositories;
using NetCore2Shop.Models;
using NetCore2Shop.Service.Interface;
using NetCore2Shop.web.Models;

namespace NetCore2Shop.web.Controllers
{
    public class LoginController : Controller
    {

        protected IAppUserRepo AppUserRepo;

        public LoginController(IAppUserRepo appUserRepo)
        {
            this.AppUserRepo = appUserRepo;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel user)
        {
            if (!CheckValidateCode(user.Code))
            {
                return View(user);
            }
            var u = await AppUserRepo.GetAsync(c => c.LoginName == user.Name && c.Password == Encryption.EncryptText(user.Password));
            if (null == u)
            {
                ModelState.AddModelError("Error","账号密码不匹配");
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Regist()
        {
            return View(new RegistViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regist(RegistViewModel user)
        {
            if (!CheckValidateCode(user.Code))
            {
                return View(user);
            }
            if (!TryValidateModel(user))
            {
                return View(user);
            }
            if (user.Password1 != user.Password)
            {
                ModelState.AddModelError("Error","两次密码不一致");
                return View(user);
            }
            var appuser = new AppUser {
                Id = Guid.NewGuid(),
                LoginName = user.UserName,
                Password = Encryption.EncryptText(user.Password),
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                DisplayName = user.UserName+new Random().Next()
            };
            await AppUserRepo.AddAsync(appuser);

            return RedirectToAction("Index");
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
            HttpContext.Session.SetString("code",code);
            return ValidateCode.GetImgBase64(code);
        }

        private async Task CheckCookiesInfo()
        {
            if (null!=Request.Cookies["shopUid"]&& null!=Request.Cookies["shopPwd"])
            {
                string id = Request.Cookies["shopUid"];
                string pwd = Request.Cookies["shopPwd"];
                var user = await AppUserRepo.GetAsync(new Guid(id));
                if (null == user || pwd!=user.Password)
                {
                }
                else
                {
                    Response.Cookies.Delete("shopUid");
                    Response.Cookies.Delete("shopPwd");
                }
            }
        }
    }
}