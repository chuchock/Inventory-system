using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class InventaryContext : DbContext
	{
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<InputOutputEntity> InOuts { get; set; }
		public DbSet<StorageEntity> Storages { get; set; }
		public DbSet<WarehouseEntity> Warehouses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				// conectar con Sql Server
				//options.UseSqlServer("Server=LM; Database=InventoryDb; User Id=sa; Password=");
				options.UseSqlServer("Server= localhost; Database= InventoryDb; Trusted_Connection = True");
			}
		}

		// Precargar información a la base de datos
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/* base se refiere a algo que ya existe dentro de esta clase */
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CategoryEntity>().HasData(
				new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar" },
				new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
				new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
				new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
				new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
				new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
				);

			modelBuilder.Entity<WarehouseEntity>().HasData(
				new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Central", WarehouseAddress = "Calle 8 con 23" },
				new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle norte con occidente" }
				);

			modelBuilder.Entity<ProductEntity>().HasData(
				new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" },
				new ProductEntity { ProductId = "RPT-5465879", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD" }
				);
		}
	}
}
