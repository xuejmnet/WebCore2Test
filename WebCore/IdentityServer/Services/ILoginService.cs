using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ILoginService<T>
    {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> ValidateCredentials(T user, string password);
        /// <summary>
        /// 根据用户名找用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<T> FindByEmail(string email);
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task SignIn(T user);
    }
}
