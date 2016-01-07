using EnterpriseApp.Domain.Shared.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Identity.Entity
{
    public class ApplicationUser : IdentityUser, ITableLog
    {

        #region ITableLog Properties

        [Required]
        public string CreatorId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string LastEditorId { get; set; }

        [Required]
        public DateTime LastEditDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}
