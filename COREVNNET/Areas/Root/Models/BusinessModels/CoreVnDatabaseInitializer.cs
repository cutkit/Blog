using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using COREVNNET.Areas.Root.Models.DataModels;

namespace COREVNNET.Areas.Root.Models.BusinessModels
{
    public class CoreVnDatabaseInitializer : DropCreateDatabaseIfModelChanges<CorevnNetContext>
    {
        protected override void Seed(CorevnNetContext context)
        {
            var admin = new Administrator()
            {
                Username = "tungld",
                FullName = "Lê Duy Tùng",
                Avatar = "/Areas/Root/Content/Avatar_Admin/7.jpg",
                Email = "tungldinfo@gmail.com",
                PassWord = "e434c1fad14669f83d535d60286851fe",
                IsAdmin = 1,
                Allowed = 1
            };
            context.Administrator.Add(admin);
            var user = new Administrator()
            {
                Username = "corevn",
                FullName = "corevn.net",
                Avatar = "/Areas/Root/Content/Img_Admin/5.jpg",
                Email = "info@corevn.net",
                PassWord = "58807e68607938c94e8dd565adee2171",
                IsAdmin = 0,
                Allowed = 1
            };
            context.Administrator.Add(user);
            var count = new Counter()
            {
                CountVisitor = 277,
                CountOnline = 0
                
            };
            context.Counter.Add(count);
            context.SaveChanges();
        }
    }
}