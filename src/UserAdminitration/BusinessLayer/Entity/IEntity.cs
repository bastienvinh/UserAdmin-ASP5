using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAdminitration.BusinessLayer.Entity
{
  public interface IEntity
  {

    string ID { get; }

    /// <summary>
    /// It's a method that is need to call every time, we record the entity.
    /// </summary>
    void UpdateOnSave(); 
  }
}
