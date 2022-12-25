using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace TravelTripProje.Models.Sınıflar
{
    //ilgili tablolara ulaşabilmek için miras alması lazım
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs  { get; set; }
        public DbSet<Hakkimda> Hakkimdas  { get; set; }
        public DbSet<iletisim> iletisims  { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
    }
}