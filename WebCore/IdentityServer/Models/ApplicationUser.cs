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
        [Required]
        public string SecurityNumber { get; set; }
        public string Expiration { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        public int CardType { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
