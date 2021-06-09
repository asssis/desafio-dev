using desafio_ruby_on_rails.Models;
using Microsoft.EntityFrameworkCore;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace desafio_ruby_on_rails.Migrations
{
    public class ConectionSQLite : DbContext
    {
        public ConectionSQLite()
        {
            this.Database.EnsureCreated();
        } 

        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Cnab> Cnab { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuild)
        {
            optionsBuild.UseSqlite("Filename=../db_dados.sqlite"); 

        }
    }
}
