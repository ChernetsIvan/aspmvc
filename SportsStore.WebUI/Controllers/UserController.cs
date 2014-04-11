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

		public const string LogonSuccess = "LogOn success!";
		public const string PasswordIncorrect = "Typed password is incorrect!";
		public const string LoginAndPassIncorrect = "Typed login and password are incorrect!";

		public UserController(IUserRepository repo)
		{
			repository = repo;
		}

		public ViewResult UserPanel(string returnUrl)
		{
			return View(GetUserVM());
		}

		public ViewResult CheckAndResult(LogOnVM inputVM, string returnUrl)
		{
			UserViewModel sessionUserVM = GetUserVM();
			sessionUserVM.ReturnUrl = returnUrl;
			sessionUserVM.IsLogOn = false;
			User user = repository.Users
				.FirstOrDefault(u => u.Login == inputVM.Login);
			if (user != null)
			{
				if (user.Password == inputVM.Password)
				{
					sessionUserVM.IsLogOn = true;
					sessionUserVM.User = new Domain.Entities.User(user);
					sessionUserVM.LogonResult = LogonSuccess;
					SetUserVM(sessionUserVM);
				}
				else
				{
					sessionUserVM.LogonResult = PasswordIncorrect;
				}
			}
			else
			{
				sessionUserVM.LogonResult = LoginAndPassIncorrect;
			}
			return View(sessionUserVM);
		}

		private UserViewModel GetUserVM()
		{
			UserViewModel userVM = null;
			try{ userVM = (UserViewModel)Session["UserVM"]; } catch { };
			if (userVM == null)
			{
				User user = new Domain.Entities.User();
				user.Login = "Guest";
				userVM = new UserViewModel(user);
				Session["UserVM"] = userVM;
			}
			return userVM;
		}
		private void SetUserVM(UserViewModel userVM)
		{
			Session["UserVM"] = userVM;
		}

		public ViewResult LogOn()
		{
			return View();
		}

		public ActionResult LogOff()
		{
			UserViewModel uVM = GetUserVM();
			uVM.IsLogOn = false;
			SetUserVM(uVM);
			return RedirectToAction("List", "Product");			
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
