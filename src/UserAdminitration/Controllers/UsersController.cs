﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using UserAdminitration.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAdminitration.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    // GET: api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "pope", "mimi" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "lala";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {

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
