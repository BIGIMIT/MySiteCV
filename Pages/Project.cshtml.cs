using Bortsevych.Data;
using Bortsevych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bortsevych.Pages
{
    public class ProjectModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? Link { get; set; }
        private ApplicationDbContext _context { get; set; }
        public List<Project>? Projects { get; set; }
        public Project? Project { get; set; }
        public ProjectModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            else
            {
                Project = project;
            }
            return Page();
        }
        
    }
}
