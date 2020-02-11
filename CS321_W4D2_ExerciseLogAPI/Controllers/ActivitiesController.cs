using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var activitymodels = _activityService.GetAll().ToApiModels();
            return Ok(activitymodels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var currentActivity = _activityService.Get(id);
            return Ok(currentActivity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Activity acitivty)
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
