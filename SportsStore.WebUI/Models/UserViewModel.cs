using SportsStore.Domain.Entities;
using System;

namespace SportsStore.WebUI.Models
{
	public class UserViewModel
	{
		public User User { get; set; }
		public string ReturnUrl { get; set; }
		public bool IsLogOn { get; set; }
		public int GuestImageID
		{
			get
			{
				return RandomImage();
			}
		}

		//Random Guest Photo
		private int from = 1;
		private int to = 7;
		private Random rand = new Random();
		private int RandomImage()
		{
			return rand.Next(from, to);
		}

	}
}