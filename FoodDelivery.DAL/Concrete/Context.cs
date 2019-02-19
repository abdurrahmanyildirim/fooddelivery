﻿using FoodDelivery.DAL.Concrete.Mapping;
using FoodDelivery.Entities;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Context
{
    public class Context : DbContext
    {
        //public Context() : base("server=.;database=FoodDeliveryDb;uid=sa;pwd=123")
        //{

        //}
        public Context() : base(@"server=ADEM\EXPRESS;database=FoodDeliveryDb;uid=sa;pwd=123")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BranchMenu> BranchMenus { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new BranchMapping());
            modelBuilder.Configurations.Add(new RegionMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new BranchMenuMapping());
            modelBuilder.Configurations.Add(new ReviewMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
