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
		
		// Note: 'S' Suffix =  Self. It's is for Static Private
		
		// A mapping container is better in this case than a simple list or array.
		private static Dictionary<string, User> SListUser;
		
		/// <summary>
		/// Init Component, must be call once
		/// </summary>
		public static void Init() 
		{
			// TODO : manage options
			// TODO : add initialization with dependency injection pattern
			// Sorry I can't use depdency injection, but you need to create dependency injection.
			
			SListUser = new Dictionary<string, User>();
		}
		
		/// <summary>
		/// Add new User to list
		/// </summary>
		/// <param name="user">User Object</param>
		public static User AddUser(User user)
		{
			// If I could go further,  will I will create abstration between the BLL and the datasource. That's why IEntity has UpdateOnSave();
			// If possible I don't want to use Entity Frmaework for performance issue.
			
			user.UpdateOnSave(); // This method is always called no matter what to ensure all change are done.
			SListUser.Add( user.ID, user );
			return user;
		}
		
		/// <summary>
		/// Return the null if not found or the first User. A ID is always Uniq.
		/// </summary>
		/// <param name="id">Identifier of the user</param>
		/// <returns></returns>
		public static User GetById(string id)
		{
			if (SListUser.ContainsKey(id))
			 return SListUser[id];
			 
			 return null;
		}
		
		public static bool UserEmailExists(string email) => SListUser.FirstOrDefault( x => x.Value.EmailAddress == email ).Value != null;
		
		/// <summary>
		/// Return true if user was found
		/// </summary>
		/// <param name="id)">Identifier of User</param>
		/// <returns>True of False</returns>
		public static bool UserIdExists(string id) => SListUser.ContainsKey(id);
		
		public static void RemoveUser(User user)
		{
			RemoveUser(user.ID);
		}
		
		public static void RemoveUser(string id) 
		{
			if ( SListUser.ContainsKey(id) )
				SListUser.Remove(id);
		}
		
		public static void UpdateUser(User user) 
		{
			if ( SListUser.ContainsKey(user.ID) )
				SListUser[user.ID] = user;	
		}
		
		/// <summary>
		/// Clear all datas
		/// NEVER, NEVER USE IT. I use it for unit testing
		/// </summary>
		public static void Clear()
		{
			SListUser.Clear();
		}
		
		public static void Test() 
		{
			AddUser( new User { FirstName = "Michelle" , LastName = "Power City" } );
			AddUser( new User { FirstName = "Niglooo" , LastName = "Gadaaga" } );
		}
		
		/// <summary>
		/// Return all Users
		/// </summary>
		/// <returns>List of Users</returns>
		public static IEnumerable<User> GetAll() => SListUser.Select( userLine => userLine.Value ).ToList();
		
	}
	
	
}