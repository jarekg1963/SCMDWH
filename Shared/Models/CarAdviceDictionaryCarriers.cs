using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
	public class CarAdviceDictionaryCarriers
	{
		public long Id { get; set; }

        [Required]
		public string Carrier { get; set; } = null!;

		public bool ActiveFlag { get; set; }

		public string? AddByUser { get; set; }

		public DateTime? AddTime { get; set; }

	}
}
