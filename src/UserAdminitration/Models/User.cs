using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdminitration.BusinessLayer.Entity;

namespace UserAdminitration.Models
{
  public class User : Entity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    
  
    public User() : base() {
      
      FirstName = "";
      LastName = "";
    }
    
  
  }
}
