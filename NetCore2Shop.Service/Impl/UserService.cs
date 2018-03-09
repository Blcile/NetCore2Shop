using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetCore2Shop.Models;

namespace NetCore2Shop.Service.Impl
{
    public class UserService : IUserService
    {
        public UserManager<AppUser> UserManager { get; }
        private IHttpContextAccessor Context;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor context)
        {
            UserManager = userManager;
            Context = context;
        }
        public Task<AppUser> User => UserManager.GetUserAsync(Context.HttpContext.User);
    }
}
