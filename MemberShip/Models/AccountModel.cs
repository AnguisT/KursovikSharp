using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MemberShip.Models
{
    public class KursovikTPContext : DbContext
    {
        public KursovikTPContext()
            : base("KursovikTP")
        {
        }

        public DbSet<People> Peoples { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Role> Roles { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}