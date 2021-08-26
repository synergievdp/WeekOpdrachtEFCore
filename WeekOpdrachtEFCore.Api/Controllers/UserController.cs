using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Services;

namespace WeekOpdrachtEFCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var user = users.GetById(id);
            if (user is null)
                return NotFound();
            return Ok(new { user });
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            try
            {
                users.Add(user);
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
