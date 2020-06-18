using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
	public class WarehouseEntity
	{
		[Key]
		[StringLength(100)]
		public string WarehouseId { get; set; }

		[Required]
		[StringLength(100)]
		public string WarehouseName { get; set; }

		[Required]
		[StringLength(100)]
		public string WarehouseAddress { get; set; }

		// Relación con almacenamiento (StorageEntity)
		public ICollection<StorageEntity> Storages { get; set; }

	}
}
