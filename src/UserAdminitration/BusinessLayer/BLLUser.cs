using System;
using System.Collections.Generic;
using System.Linq;
using UserAdminitration.BusinessLayer.Entity;
using UserAdminitration.Models;


namespace UserAdminitration.BusinessLayer {

	public static class BLLUser 
	{
		
		// Since I don't have time to add some sql stuff I think I add
		// For now I can cheat and use in memory-list
		
		private static Dictionary<string, User> SListUser;
		
		internal static void Init() 
		{
			// TODO : manage options
			// TODO : add dependency injection
			// Sorry I can't use depdency injection, but you need to create dependency injection.
			
			
			SListUser = new Dictionary<string, User>();
			
		}
		
		public static void AddUser(User user)  
		{
			
		}
		
		public static void RemoveUser(User user)
		{
			
		}
		
		public static void RemoveUser(string id) 
		{
			
		}
		
		public static void UpdateUser(User user) 
		{
			
		}
		
		
		public static void Test() 
		{
			
		}
		
		
		public static IEnumerable<User> GetAll() 
		{
			return null;
		}
		
	}
	
	
}