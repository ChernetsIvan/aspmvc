using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.WebUI.Models.Account
{
	public class ChangePasswordModel
	{
		[Display(Name = "Current password")]
		public string OldPassword { get; set; }

		[Display(Name = "New password")]
		public string NewPassword { get; set; }

		[Display(Name = "Confirm new password")]
		public string ConfirmPassword { get; set; }
	}
}