using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace Bortsevych.Models
{
    public class AppUser: IdentityUser
    {
        [PersonalData]
        public ICollection<Project>? Projects { get; } = new List<Project>();
    }
}
