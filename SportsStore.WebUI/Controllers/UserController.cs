using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;

		public UserController(IUserRepository repo)
		{
			repository = repo;
		}

		public ViewResult UserPanel(string returnUrl)
		{
			return View(new UserViewModel
			{
				User = GetUser(),
				ReturnUrl = returnUrl
			}
			);
		}


		private User GetUser()
		{
			User user = (User)Session["User"];
			if (user == null)
			{
				user = new User();
				Session["User"] = user;
			}
			return user;
		}

		public ViewResult LogOn()
		{
			return View();
		}

		public ViewResult LogOff()
		{
			return View();
		}

		public ViewResult Register()
		{
			return View();
		}


		public ViewResult ToPrivateOffice()
		{
			return View();
		}

        public ActionResult Index()
        {
            return View();
        }

    }
}
