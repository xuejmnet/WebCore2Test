using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    //创建登录用户实体
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string Expiration { get; set; }
        public string CardHolderName { get; set; }
        public int CardType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
