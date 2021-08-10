using System;
using System.IO;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public string DbPath { get; set; }
        public DataContext()
        {
            // This will save to the local folder under appdata
            // var folder = Environment.SpecialFolder.LocalApplicationData;
            // var path = Environment.GetFolderPath(folder);
            // DbPath = $"{path}\\assure.db";
        }

        // When configuring use the current directory 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Using sqlite for dev purposes
            options.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}\\assure.db");
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Form> IneligibleForms { get; set; }

        public DbSet<MedicalIngredient> MedicalIngredients { get; set; }
        public DbSet<MedicalIngredient> IneligibleIngredients { get; set; }
        
        public DbSet<Base> Bases { get; set; }
        public DbSet<Base> IneligibleBases { get; set; }
        
        public DbSet<PDIN> PDINs { get; set; }

    }
}