using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
	public interface IUserRepository
	{
		IQueryable<User> Users { get; }
	}
}
