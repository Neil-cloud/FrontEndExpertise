using FEEAssignment.Data;
using FEEAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FEEAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class HomeController : ApiBase
    {
        public HomeController(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                this.SetUserData();
                return Ok(new HomeResponseModel() { UserId = this.UserData.Name, UserRole = this.UserRole.Name});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e); ;
            }
        }
    }
}
