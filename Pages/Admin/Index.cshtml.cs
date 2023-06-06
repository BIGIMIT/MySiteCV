using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bortsevych.Pages.Admin;
[Authorize(Roles = "Administrator")]
public class IndexModel : PageModel
{
    private readonly Bortsevych.Data.ApplicationDbContext _context;

    public IndexModel(Bortsevych.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Project> Project { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Projects != null)
        {
            Project = await _context.Projects.ToListAsync();
        }
    }
}
