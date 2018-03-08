using System;
using NetCore2Shop.Models;

namespace NetCore2Shop.Service.Interface
{
    public interface IAppUserService
    {
        AppUser LoginAppUser(string name, string password);
        AppUser CookiesAppUser(Guid id, string password);
        void RegistAppUser(AppUser user);
    }
}