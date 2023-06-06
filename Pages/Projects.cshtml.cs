using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Data;
using Bortsevych.Models;

namespace Bortsevych.Pages;

public class ProjectsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public ProjectsModel(ApplicationDbContext context)
    {
        _context = context;
    }
    public IList<Project> Projects { get; set; } = default!;
    public DateTime LastUpdate { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Projects != null)
        {
            Projects = await _context.Projects.ToListAsync();
            foreach (var project in Projects)
            { LastUpdate = LastUpdate.Date < project.UpdateAt.Date ? project.UpdateAt : LastUpdate; }
        }
    }
}

