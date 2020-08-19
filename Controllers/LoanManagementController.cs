using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Data;
using LoanManagement.Models;
using LoanManagement.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagementController : ControllerBase
    {
        LoanDBContext _loanDBContext;
        LoanManagementRepository _loanManagementRepository;
        public LoanManagementController(LoanDBContext loanDBContext)
        {
            _loanDBContext = loanDBContext;
            _loanManagementRepository = new LoanManagementRepository(_loanDBContext);
        }
        // GET: api/<LoanManagementController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return new string[] { "value1", "value2" };
            return _loanDBContext.Users;
        }

        #region Moved to another Controller
        // GET: api/LoanManagement/login
        //[HttpGet]
        //[Route("login")]
        //public IActionResult ConfirmLogin(string userid, string password)
        //{
        //    //var user = _loanDBContext.Users.Find(userid);
        //    var user = _loanDBContext.Users.FirstOrDefault(p => p.UserId== userid);
        //    if(user == null)
        //    {
        //        return NotFound("User doesn't exist");
        //    }
        //    else if(user.Password != password)
        //    {
        //        return BadRequest("password doesn't match");
        //    }
        //    else
        //    {
        //        return Ok(user.Role);
        //    }
        //}

        #endregion

        // GET api/LoanManagement/searchLoan
        [HttpGet]
        [Route("searchLoan")]
        public IActionResult GetSearchResult(string borrowerName,int loanId,int loanAmount )
        {
            //if (loanId != 0)
            //{
            //    var loan = _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId);
            //    if (loan != null)
            //    {
            //        return Ok(loan);
            //    }
            //}

            //var loans = _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId || p.BorrowerName == borrowerName || p.LoanAmount == loanAmount);
            //return Ok(_loanDBContext.LoanDetails.Where(p => p.LoanId == loanId || p.BorrowerName == borrowerName || p.LoanAmount == loanAmount));
            //if(!String.IsNullOrEmpty(borrowerName))
            //{
            //    loans = _loanDBContext.LoanDetails.Where(p => p.BorrowerName == borrowerName).ToList();
            //}
            //else if(loanId != 0)
            //{
            //    loans = _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId).ToList();
            //}
            //else if(!String.IsNullOrEmpty(borrowerName) && loanId != 0)
            //{
            //    loans = _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId || p.BorrowerName == borrowerName).ToList();
            //}
            //else
            //{
            //    loans = _loanDBContext.LoanDetails.Where(p => p.LoanAmount == loanAmount).ToList();
            //}

            //return Ok(loans);
            var loan = _loanManagementRepository.GetSearchResult(borrowerName, loanId, loanAmount);
            return Ok(loan);
        }

        // POST /api/LoanManagement/addLoan
        [HttpPost]
        [Route("addLoan")]
        public IActionResult AddLoan([FromBody] LoanDetail loanDetail)
        {
            //_loanDBContext.LoanDetails.Add(loanDetail);
            //_loanDBContext.SaveChanges();
            var result = _loanManagementRepository.AddLoan(loanDetail);
            if(result)
            {
                return Ok("Successful");
            }
            else
            {
                return Ok("Unsuccessful");
            }

        }

        // PUT /api/LoanManagement/editLoan/{loanId}
        [HttpPut]
        [Route("editLoan/{loanId}")]
        public IActionResult EditLoan(int loanId, [FromBody] LoanDetail loanDetail)
        {
            //var loan = _loanDBContext.LoanDetails.Find(loanId);
            var result = _loanManagementRepository.EditLoan(loanId,loanDetail);
            //loan.BorrowerName = loanDetail.BorrowerName;
            //loan.LoanTerm = loanDetail.LoanTerm;
            //loan.LoanAmount = loanDetail.LoanAmount;
            //loan.LoanType = loanDetail.LoanType;
            //loan.AddressLine1 = loanDetail.AddressLine1;
            //loan.AddressLine2 = loanDetail.AddressLine2;
            //loan.City = loanDetail.City;
            //loan.ZipCode = loanDetail.ZipCode;
            //loan.LegalInformation = loanDetail.LegalInformation;

            //_loanDBContext.SaveChanges();

            if (result)
            {
                return Ok("Successful");
            }
            else
            {
                return Ok("Unsuccessful");
            }
        }

        // DELETE api/<LoanManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
