using KargoTakip.DataAccsess.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KargoTakip.DataAccsess.Data.Context
{
    public class KargoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=NIRVANA\\SQLEXPRESS;Database=KargoDb;uid=Work2;pwd=123456;");
        }
        public DbSet<Kargo> Kargolar { get; set; }

    }
}