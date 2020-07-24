using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
	public class B_Storage
	{
		public static List<StorageEntity> StorageList()
		{
			using (var db = new InventaryContext())
			{
				return db.Storages.ToList();
			}
		}

		public static List<StorageEntity> StorageProductsByWarehouse(string idWarehouse)
		{
			using (var db = new InventaryContext())
			{
				return db.Storages
					.Include(s => s.Product)
					.Include(s => s.Warehouse)
					.Where(s => s.WarehouseId == idWarehouse)
					.ToList();
			}
		}

		public static void CreateStorage(StorageEntity oStorage)
		{
			using (var db = new InventaryContext())
			{
				db.Storages.Add(oStorage);
				db.SaveChanges();
			}
		}

		public static bool IsProductInWarehouse(string idStorage)
		{
			using (var db = new InventaryContext())
			{
				var product = db.Storages.ToList()
					.Where(s => s.StorageId == idStorage);

				return product.Any();
			}
		}

		public static void UpdateStorage(StorageEntity oStorage)
		{
			using (var db = new InventaryContext())
			{
				db.Storages.Update(oStorage);
				db.SaveChanges();
			}
		}
	}
}
