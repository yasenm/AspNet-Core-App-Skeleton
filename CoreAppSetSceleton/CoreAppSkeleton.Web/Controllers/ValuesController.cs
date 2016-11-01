﻿using CoreAppSkeleton.Data.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAppSkeleton.Web.Controllers
{
    [Route("api/custom/values")]
    public class ValuesController : Controller
    {
        private ICoreAppModelService _coreModelRepo;
        private ILogger<ValuesController> _logger;

        public ValuesController(ICoreAppModelService coreModelRepo, ILogger<ValuesController> logger)
        {
            _coreModelRepo = coreModelRepo;
            _logger = logger;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coreModelRepo.GetAll<object>());
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value" + id;
        //}

        // GET api/values/5
        [HttpGet("{title}")]
        public IActionResult Get(int title)
        {
            try
            {
                var result = _coreModelRepo.GetAll<object>().FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all items: {ex}");

                return BadRequest("Error occurred!");
            }
        }

        // POST api/values
        [HttpPost]
        //public async Task<IActionResult> Post([FromBody]CoreAppViewModel appModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _coreModelRepo.Add(appModel);
        //        if (await _coreModelRepo.SaveChangesAsync())
        //        {
        //            return  Created($"api/custom/values/{appModel.Title}", appModel);
        //        }
        //    }
        //    return BadRequest("Failed to save item");
        //}

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
