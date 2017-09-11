using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IRegisterService<T>
    {
        /// <summary>
        /// 自己本地注册一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Register(T user,string password);
    }
}
