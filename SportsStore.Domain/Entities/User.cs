using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
	public class User
	{
		public int UserID { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FIO { get; set; }
		public string Gender { get; set; }
		public string Photo { get; set; }
		public string Birthday { get; set; }
		public string Residence { get; set; }
		public string AboutHimself { get; set; }
		public string UserRights { get; set; }
	}
}
