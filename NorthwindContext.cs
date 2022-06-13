using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RecapProject.Entities;//entities klasörünü import ediyoruz.

namespace RecapProject
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }//product classının products a karşılık geldiğini tanımlıyoruz.veri tabanında tabloda yer alan kolonları product a eşitledik.
        public DbSet<Category> Categories { get; set; }
    }
}
