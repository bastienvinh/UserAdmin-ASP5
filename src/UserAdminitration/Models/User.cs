using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAdminitration.Models
{
  public class User
  {
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateCreated { get; }

    public string LastUpdated { get; }
  }
}
