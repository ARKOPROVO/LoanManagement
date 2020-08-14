using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Data;
using LoanManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagementController : ControllerBase
    {
        LoanDBContext _loanDBContext;
        public LoanManagementController(LoanDBContext loanDBContext)
        {
            _loanDBContext = loanDBContext;
        }
        // GET: api/<LoanManagementController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return new string[] { "value1", "value2" };
            return _loanDBContext.Users;
        }

        // GET: api/LoanManagement/login
        [HttpGet]
        [Route("login")]
        public IActionResult ConfirmLogin(string userid, string password)
        {
            //var user = _loanDBContext.Users.Find(userid);
            var user = _loanDBContext.Users.FirstOrDefault(p => p.UserId== userid);
            if(user == null)
            {
                return NotFound("User doesn't exist");
            }
            else if(user.Password != password)
            {
                return BadRequest("password doesn't match");
            }
            else
            {
                return Ok(user.Role);
            }
        }

        // GET api/<LoanManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoanManagementController>
        [HttpPost]
        [Route("addLoan")]
        public IActionResult AddLoan([FromBody] LoanDetail loanDetail)
        {
            _loanDBContext.LoanDetails.Add(loanDetail);
            _loanDBContext.SaveChanges();
            return Ok("Successful");
        }

        // PUT api/<LoanManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoanManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
