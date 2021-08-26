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
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messages;

        public MessageController(IMessageService messages)
        {
            this.messages = messages;
        }

        [HttpPost]
        public IActionResult Save(Message message)
        {
            try
            {
                messages.Add(message);
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try { 
                var message = messages.GetById(id);

                if (message is null)
                    return NotFound();

                return Ok(new { message });
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByUserId(int userid)
        {
            try
            {
                var message = messages.GetByUserId(userid);

                if (message is null)
                    return NotFound();

                return Ok(new { message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
