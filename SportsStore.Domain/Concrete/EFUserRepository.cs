using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
	public class EFUserRepository : IUserRepository
	{
		private EFDbContext context = new EFDbContext();
		public IQueryable<User> Users
		{
			get { return context.Users; }
		}
	}
}