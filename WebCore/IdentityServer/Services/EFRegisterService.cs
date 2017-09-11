using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class EFRegisterService : IRegisterService<ApplicationUser>
    {
        UserManager<ApplicationUser> _userManager;

        public EFRegisterService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Register(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
