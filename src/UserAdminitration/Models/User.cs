using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAdminitration.Models
{
  public class User : UserAdminitration.BusinessLayer.Entity.IEntity
  {
    
        
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateCreated { get; }

    public DateTime LastUpdated { get; private set; }

  
    public User() {
      
      FirstName = "";
      LastName = "";
      DateCreated = DateTime.Now;
      LastUpdated = DateTime.Now;
    }
    
    
    public void UpdateOnSave() {
      LastUpdated = DateTime.Now;
    }
  
  }
}
