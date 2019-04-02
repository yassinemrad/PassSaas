using DataMap.Configurations;
using DataMap.Conventions;

using DomainMap.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap
{
   public class MyContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static MyContext Create()
        {
            return new MyContext();
        }
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }
        public MyContext() : base("name=MapDb")
        {
            TPHUser tphu = new TPHUser();
           
            Date2timeConvention dt = new Date2timeConvention();
           
        }

        public DbSet<Message> message { get; set; }
        public DbSet<Module> module { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<Projet> projet { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<reclamation> reclamation { get; set; }





        // public DbSet<ApplicationUser> user { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TPHUser());
           


            //modelBuilder.Configurations.Add(new ResourceConfiguration());
            modelBuilder.Conventions.Add(new Date2timeConvention());
        }
    }
}

