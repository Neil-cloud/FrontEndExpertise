using FEEAssignment.Data;
using FEEAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FEEAssignment.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : ApiBase
    {
        private readonly List<Course> Courses;
        public CoursesController(ApplicationDbContext dbContext) : base(dbContext)
        {
            using (StreamReader r = new StreamReader($"{Environment.CurrentDirectory}/Catalog_DataSet_V1.json"))
            {
                string json = r.ReadToEnd();
                Courses = JsonConvert.DeserializeObject<List<Course>>(json);
            }            
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                this.SetUserData();
                if (this.UserClaims.Any(x => x.ClaimType == "CanViewCourses") || this.UserRole.Name.ToLowerInvariant() == "admin")
                {
                    return Ok(Courses.Take(3));
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
