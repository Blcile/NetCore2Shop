using System;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;
using NetCore2Shop.Service.Interface;

namespace NetCore2Shop.Service.Impl
{
    public class AppUserServiceImpl:IAppUserService
    {
        protected IAppUserRepo appUserRepo;

        public AppUserServiceImpl(IAppUserRepo appUserRepo)
        {
            this.appUserRepo = appUserRepo;
        }

        public AppUser CookiesAppUser(Guid id, string password) => throw new NotImplementedException();
        public AppUser LoginAppUser(string name, string password) => throw new NotImplementedException();
        public void RegistAppUser(AppUser user) => throw new NotImplementedException();
    }
}