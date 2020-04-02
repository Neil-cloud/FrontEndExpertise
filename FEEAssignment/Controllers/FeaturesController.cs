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
    public class FeaturesController: ApiBase
    {
        private readonly List<Feature> Features;
        public FeaturesController(ApplicationDbContext dbContext) : base(dbContext)
        {
            using (StreamReader r = new StreamReader($"{Environment.CurrentDirectory}/FeatureDataset.json"))
            {
                string json = r.ReadToEnd();
                Features = JsonConvert.DeserializeObject<List<Feature>>(json);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                this.SetUserData();
                if (this.UserClaims.Any(x => x.ClaimType == "CanViewFeatures") || this.UserRole.Name.ToLowerInvariant() == "admin")
                {
                    return Ok(Features.Take(4));
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
