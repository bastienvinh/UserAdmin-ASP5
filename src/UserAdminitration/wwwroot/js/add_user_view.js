$(function () {
	
	function getUserOnServer(callback)
	{
		$.get('/api/users')
			.done(function (data) {
				// console.log(data);
				if (data.HasError) {
					// TODO : notify the user
					console.error("Retrieve all users informations failed : " + data.MessageError);
					return;
				}
				
				if (callback != undefined && callback != null)
					callback(data.Data);
				
			})
			.fail(function () {
				// TODO : show error message
			});
	}
	
	function removeUserOnServer(user, callback) {
	
		$.ajax({
			url : 'api/users/' + user.ID,
			method: 'DELETE'
		})
		.done(function (data) {
			
			if (data.HasError) {
				return;
			}
			
			if (callback != undefined && callback != null)
				callback();
			
		})
		.fail(function () {
			console.error("Fail delete user");
		});
	}
	
	function updateUserOnServer(user, callback) {
		$.ajax({
			url : 'api/users/' + user.ID,
			method: 'PUT',
			data: user
		})
		.done(function (data) {
			
			if (data.HasError) {
				console.error("User don't exists or can't change information");
				return;
			}
			
			if (callback != undefined && callback != null)
				callback(data.Data);
			
		})
		.fail(function () {
			console.error("Fail delete user");
		});
	}
	
	function addUserOnServer(user, callback) {
	
		$.ajax({
			url : 'api/users',
			method: 'POST',
			data : user
		})
		.done(function (data) {
			
			if (data.HasError) {
				console.error("You can't add user.");
				
				// Manage email existed
				
				return;
			}
			
			if (callback != undefined && callback != null)
				callback(data.Data);
			
		})
		.fail(function () {
			console.error("Fail delete user");
		});
	}
	
	
	// we create our viewModel definition
	var UserModel = function() {
		var self = this;
		
		self.users = ko.observableArray([]);
		self.selectedUser = {
			FirstName: "",
			LastName: "",
			EmailAddress: ""
		}
		
		self.updatingdUser = {
			ID: ko.observable(""),
			FirstName: ko.observable("toto"),
			LastName: ko.observable("mili"),
			EmailAddress: ko.observable("pop")
		};
		
		
		self.addUser = function (data) {
			self.users.push(data);
		}
		
		self.clear = function () {
			self.users.removeAll();
		}
		
		self.refreshList = function () {
			
			getUserOnServer(function (data) {
				for (var i = 0, j = data.length; i < j; ++i )
					self.addUser(data[i]);
			})
			
			// Go look for data
		}
		
		self.addNewUser = function () {
			
			// verify that everything is ok
			addUserOnServer(self.selectedUser, function(newUser) {
				self.addUser( newUser );
			});
			
		}
		
		self.removeUser = function (data) {
			removeUserOnServer(data, function () {
				self.users.remove(data);	
			});
		}
		
		self.updateUser = function () {
			
			updateUserOnServer({
				FirstName : self.updatingdUser.FirstName(),
				LastName: self.updatingdUser.LastName(),
				ID: self.updatingdUser.ID(),
				EmailAddress: self.updatingdUser.EmailAddress()
			}, function (modfiedUser) {
				self.clear();
				self.refreshList();
				
				$("form#bloc_form_user_update").hide();
				$("form#bloc_form_user_add").show();
			});
			
			// We refresh the table / Yes I cheated
		}
		
		self.showData = function(data) {
			$("form#bloc_form_user_update").show();
			$("form#bloc_form_user_add").hide();
			
			// updatingdUser = data;
			self.updatingdUser.ID(data.ID);
			self.updatingdUser.FirstName(data.FirstName);
			self.updatingdUser.LastName(data.LastName);
			self.updatingdUser.EmailAddress( data.EmailAddress );
			
			window.scrollTo(0, 0);
		}
		
	}

// We init our viewModel definition
	var viewModel = new UserModel();
	ko.applyBindings(viewModel);
	
	viewModel.refreshList();
});
