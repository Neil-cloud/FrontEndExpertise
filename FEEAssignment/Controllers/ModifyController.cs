using FEEAssignment.Data;
using FEEAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FEEAssignment.Controllers
{
    [Route("api/[controller]")]
    public class ModifyController: ApiBase
    {
        private readonly List<Feature> Features;
        public ModifyController(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                this.SetUserData();
                if (this.UserRole.Name.ToLowerInvariant() == "admin")
                {
                    return Ok(true);
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
