using SportsStore.Domain.Entities;
using System;

namespace SportsStore.WebUI.Models
{
	public class UserViewModel
	{
		public User User { get; set; }
		public string ReturnUrl { get; set; }
		public bool IsLogOn { get; set; }
		public string LogonResult { get; set; }
		public int GuestImageID	{ get { return RandomImage(); }	}

		public UserViewModel(User user)
		{
			User = new User(user);
		}

		//Random Guest Photo
		private int from = 1;
		private int to = 7;
		private Random rand = new Random();
		private int RandomImage()
		{
			return rand.Next(from, to);
		}

		/*
		public User User { get; set; }
		public string ReturnUrl { get; set; }
		public bool IsLogOn { get; set; }
		private int guestImageID = 1;
		public int GuestImageID
		{
			get
			{
				if (guestImageID == (last + 1))
					guestImageID = 1;
				guestImageID++;
				return guestImageID;
			}
		}

		//last image
		private int last = 7;
		*/
	}
}