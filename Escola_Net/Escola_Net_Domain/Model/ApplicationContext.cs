using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola_Net_Domain.Model
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<TipoPessoa> TipoPessoa { get; set; }

        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().HasKey(t => t.Id);
            modelBuilder.Entity<Pessoa>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<TipoPessoa>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoPessoa>().Property(t => t.Id).IsRequired();
        }
    }
}
