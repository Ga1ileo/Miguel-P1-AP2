using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Miguel_P1_AP2.Models;

namespace Miguel_P1_AP2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\parcial.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Crear Departamentos directos en la base de datos
            modelBuilder.Entity<Departamentos>().HasData(new Departamentos { DepartamentoId = 1, Descripcion = "Tecnologia" });
            modelBuilder.Entity<Departamentos>().HasData(new Departamentos { DepartamentoId = 2, Descripcion = "Ferreteria" });

            //Crear Articulos directos en la base de datos
            modelBuilder.Entity<Articulos>().HasData(new Articulos {ArticuloId = 1, DepartamentoId = 1, Referencia = "Tecn", Descripcion = "Iphone 2g", Precio = 4000, Existencia = 2, Departamento = "Tecnologia"} );
            modelBuilder.Entity<Articulos>().HasData(new Articulos {ArticuloId = 2, DepartamentoId = 1, Referencia = "Tecn", Descripcion = "Iphone 3g", Precio = 5000, Existencia = 3, Departamento = "Tecnologia"} );

            modelBuilder.Entity<Articulos>().HasData(new Articulos {ArticuloId = 3, DepartamentoId = 2, Referencia = "Tool", Descripcion = "Tornillo Grande", Precio = 15, Existencia = 100, Departamento = "Ferreteria"} );

            
        }

        
    }
}