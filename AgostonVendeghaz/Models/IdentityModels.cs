using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AgostonVendeghaz.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Irányítószám")]
        [RegularExpression(@"^[1-9]\d{3}[.]?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Város")]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ .\-]{2,}$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Utca")]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ \-.]{2,}$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Házszám")]
        [RegularExpression(@"^\d{1,4}[.\-/ ]?[0-9a-zA-Z\u00C0-\u00FFűőŰŐ \-.:/]*?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string HouseNumber { get; set; }

        [Required]
        [Display(Name = "Telefonszám")]
        [RegularExpression(@"^\+?\d{2}[\-. ]?\d{1,2}[\-. ]?\d{3}[\-. ]?\d{3,4}$",
        ErrorMessage = "Helytelen formátum kérem próbálja újra!")]
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ReservedRooms> ReserveRooms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<UnitPrices> UnitPrice { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}