using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using UserAdminitration.Models;
using UserAdminitration.Components.Web;
using UserAdminitration.Web.Manager;
using UserAdminitration.BusinessLayer;
using UserAdminitration.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAdminitration.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    // Remark : I should use 
    
    
    // GET: api/values
    [HttpGet]
    public HttpResponseList<User> Get()
    {     
      // There no way you can fail this request, so it will be always be OK.
     var data = BLLUser.GetAll();
     
     // Remark : I am not sure it's good idea to build like that. 
      return ((HttpResponseList<User>) (ServerManager.CreateResponseList<User>()
        .Success()))
        .SetListData(data);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public HttpResponse<User> Get(string id)
    {
      var prepareResp = ServerManager.CreateResponseOne<User>();
      
      if (!BLLUser.UserIdExists( id ))
        prepareResp.FailFoundRessource();
       else 
       {
         prepareResp.Success();
         ((HttpResponse<User>)prepareResp).SetData( BLLUser.GetById(id) );
       }
        
      return (HttpResponse<User>) prepareResp;
    }

    // POST api/values
    [HttpPost]
    public HttpResponse<User> Post(RequestUserAdd newUser)
    {
      // TODO : Verify is Model is valid
      
      var prepareResp = ServerManager.CreateResponseOne<User>();
      
      if (BLLUser.UserEmailExists(newUser.EmailAddress))
      {
        prepareResp.FailDuplicateData();
      }
      else
      {
        // Create a new User
        var user = BLLUser.AddUser( new User { FirstName = newUser.FirstName, LastName = newUser.LastName, EmailAddress = newUser.EmailAddress } );
        prepareResp.Success();
        ((HttpResponse<User>) prepareResp).SetData( user );
        Console.WriteLine("Add new user ID : {0}", user.ID);
      }
      
      return (HttpResponse<User>) prepareResp;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public HttpResponse<User> Put(string id, RequestUserAdd value)
    {
      // It's where we gonna change our user
      
      
      var prepareResp = ServerManager.CreateResponseOne<User>();
      
      // TODO : Finish it
      if (!BLLUser.UserIdExists(id))
      {
        prepareResp.FailFoundRessource();
      }
      else
      {
        prepareResp.Success();
        
        var oldUser = BLLUser.GetById(id); // We don't want to change it's ID So we retrive the same.
        oldUser.FirstName = value.FirstName;
        oldUser.LastName = value.LastName;
        oldUser.EmailAddress = value.EmailAddress; // TODO : Verify mail already exists
        
        var newUser = BLLUser.UpdateUser( oldUser );
        
        ((HttpResponse<User>)prepareResp).SetData(newUser);
        
        Console.WriteLine("Change User : {0}", id);
        Console.WriteLine("New Value affected : {0}, {1}, {2}", value.FirstName, value.LastName, value.EmailAddress);
      }
      
      return (HttpResponse<User>) prepareResp;
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public HttpResponse Delete(string id)
    {
      var prepareResp = ServerManager.CreateResponseAction();
      
      if (BLLUser.RemoveUser(id))
        prepareResp.Success();
      else
        prepareResp.FailFoundRessource();
      
      return (HttpResponse) prepareResp;
    }
    
    
  }
}
