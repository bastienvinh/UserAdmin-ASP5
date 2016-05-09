using System;
using System.Collections.Generic;
using System.Linq;


namespace UserAdminitration.BusinessLayer.Entity
{
  public class Entity : IEntity
  {

    public string ID { get; private set; }

    /// <summary>
    /// It's a method that is need to call every time, we record the entity.
    /// </summary>
    public virtual void UpdateOnSave()
		{
			ID = Guid.NewGuid().ToString();
		}
		
  }
}