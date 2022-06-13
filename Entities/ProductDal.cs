using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RecapProject.Entities
{
    public class ProductDal
    {
        public void Add(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }


        }
        public void Update(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;//modifiye et
                context.SaveChanges();
            }


        }
        public void Delete(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;//modifiye et
                context.SaveChanges();
            }


        }
    }
}
