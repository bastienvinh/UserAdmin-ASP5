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
    public void Post([FromBody]RequestUserUpdate value)
    {
      Console.WriteLine("------> Value test : { {0}, {1}, {2} }", value.FirstName, value.LastName, value.EmailAddress);
      //BLLUser.AddUser( new User { FirstName = value.FirstName, LastName = value.LastName } );
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
