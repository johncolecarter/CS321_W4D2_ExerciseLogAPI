using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using CS321_W4D2_ExerciseLogAPI.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userservice)
        {
            _userService = userservice;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var usermodels = _userService.GetAll().ToApiModels();
            return Ok(usermodels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Core.Models.User user = _userService.Get(id);
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserModel newUser)
        {
            try
            {
                _userService.Add(newUser.ToDomainModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.GetBaseException().Message);

            }
            return CreatedAtAction("Get", new { Id = newUser.Id }, newUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserModel updatedUser)
        {
            Core.Models.User user = _userService.Update(updatedUser.ToDomainModel());
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Remove(user);
            return NoContent();
        }
    }
}
