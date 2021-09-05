using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Form> Forms  { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Ingredient> InEligibleIngredients { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


    }
}
