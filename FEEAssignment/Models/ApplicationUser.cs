using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FEEAssignment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name {get; set;}        
        public string Country {get; set;}
        public string Gender {get; set;}
        public string Interests {get; set;}        
    }    
}
