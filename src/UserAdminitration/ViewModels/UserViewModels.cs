using System;
using System.Collections.Generic;
using System.Linq;


namespace UserAdminitration.ViewModels
{
	public class RequestUserUpdate
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
	}
	
	
	public class RequestUserAdd
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
	}
}