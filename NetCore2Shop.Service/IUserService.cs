using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetCore2Shop.Models;

namespace NetCore2Shop.Service
{
    public interface IUserService
    {
        Task<AppUser> User { get; }
    }
}
