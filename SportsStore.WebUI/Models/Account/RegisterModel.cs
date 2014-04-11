using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.WebUI.Models.Account
{
	public class RegisterModel
	{
		[Display(Name = "User name")]
		public string UserName { get; set; }

		[Display(Name = "Email address")]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		public string ConfirmPassword { get; set; }
	}
}