using System;
using System.Collections.Generic;
using System.Linq;


namespace UserAdminitration.BusinessLayer.Entity
{
  public class Entity : IEntity
  {

    public string ID { get; private set; }

    public DateTime DateCreated { get; protected set; }
    public DateTime LastUpdated { get; protected set; }


    public Entity() 
    {
      DateCreated = DateTime.Now;
      LastUpdated = DateTime.Now;
    }

    /// <summary>
    /// It's a method that is need to call every time, we record the entity.
    /// </summary>
    public virtual void UpdateOnSave()
		{
      if (string.IsNullOrEmpty(ID))
		  	ID = Guid.NewGuid().ToString();
        
      LastUpdated = DateTime.Now;
		}
		
  }
}