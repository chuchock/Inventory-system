using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Entities;

namespace Business
{
	public class B_Warehouse
	{
		public static List<WarehouseEntity> WarehouseList()
		{
			using (var db = new InventaryContext())
			{
				return db.Warehouses.ToList();
			}
		}
	}
}
