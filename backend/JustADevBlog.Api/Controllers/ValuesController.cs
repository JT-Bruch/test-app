﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JustADevBlog.Api.Controllers
{
  /// <summary>
  /// Controller
  /// </summary>
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    /// <summary>
    /// GET api/values 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new[] {"value1", "value2"};
    }

    /// <summary>
    /// GET api/values/5 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    /// <summary>
    /// POST api/values
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    /// <summary>
    /// PUT api/values/5
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    /// <summary>
    /// DELETE api/values/5
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
