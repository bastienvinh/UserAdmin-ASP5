using Xunit;
using Xunit.Extensions;
using Xunit.Abstractions;
using System;
using UserAdminitration.BusinessLayer;
using UserAdminitration.Models;

namespace UserAdminitration.Unit.Test.BusinessLayer
{
	public class BLLUserUnit
	{
		
		private readonly ITestOutputHelper output;
		
		public BLLUserUnit(ITestOutputHelper output)
		{
			this.output = output;
			// Init
			BLLUser.Init();
		}
		
		[Fact]
		public void TestNothing() => Assert.True(true);
		
		
		[Fact]
		public void UserAddUserTest()
		{
			BLLUser.Clear();
			var user = BLLUser.AddUser( new User { FirstName = "Power" } );
			
			var data = BLLUser.GetAll();
			
			Assert.NotNull( data );
			// TODO : Continue this tests.
			BLLUser.Clear();
		}
		
		[Fact]
		public void EntityIdCreated()
		{
			var user = new User { FirstName = "ID Generator Firstname" };
			user.UpdateOnSave();
			
			output.WriteLine( "ID created : {0}", user.ID );
			Assert.NotEqual(user.ID, "");
		}
		
		[Theory]
		public void UserIdInjected()
		{
			BLLUser.Clear();
			var user = BLLUser.AddUser( new User { FirstName = "ID Generator Firstname" } );
			Assert.NotNull(user.ID);
			Assert.NotEqual(user.ID, string.Empty);
		}
		
		[Fact]
		public void UserIdExist()
		{
			BLLUser.Clear();
			var user = BLLUser.AddUser( new User { FirstName = "Power" } );
			Assert.True( BLLUser.UserIdExists(user.ID) );
			BLLUser.Clear();
		}
		
		[Fact]
		public void UserDoesntExists()
		{
			BLLUser.Clear();
			Assert.False( BLLUser.UserIdExists("Trevor") );
		}
		
		// [Fact]
		// public void UserEmailExists()
		// {
		// 	BLLUser.Clear();
		// 	var user = BLLUser.AddUser( new User { EmailAddress = "Destination@lala.fr" } );
			
		// 	Assert.True( BLLUser.UserEmailExists("Destination@lala.fr") );
		// 	BLLUser.Clear();
		// }
		
		
		[Fact]
		public void UserEmailShouldNotExists()
		{
			BLLUser.Clear();
			Assert.False( BLLUser.UserEmailExists("Destination@lala.fr") );
		}
		
		// TODO : Add more unit test
		
	}
}