using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COREVNNET.Areas.Root.Models.DataModels;
using System.Data.Entity;

namespace COREVNNET.Areas.Root.Models.BusinessModels
{
    public class CorevnNetContext: DbContext
    {
        public CorevnNetContext():base("CorevnNetContextConnectionString")
        {

        }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<GrantPermission> GrantPermission { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Counter> Counter { get; set; }
    }
}