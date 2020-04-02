namespace FEEAssignment.Controllers
{
    #region Usings
    using FEEAssignment.Data;
    using FEEAssignment.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
    public class ApiBase : ControllerBase
    {
        private ApplicationDbContext dbContext;
        public ApplicationUser UserData { get; set; }
        public IdentityRole UserRole { get; set; }
        public List<IdentityUserClaim<string>> UserClaims { get; set; }
        public ApiBase(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;            
        }

        public void SetUserData()
        {
            string userId = this.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            UserData = dbContext.Users.FirstOrDefault(x => x.Id == userId);            
            UserRole = dbContext.Roles.FirstOrDefault(y => y.Id == dbContext.UserRoles.FirstOrDefault(x => x.UserId == userId).RoleId);
            UserClaims = dbContext.UserClaims.Where(x => x.UserId == userId).ToList();
        }
    }
}
