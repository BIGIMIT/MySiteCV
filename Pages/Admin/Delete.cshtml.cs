using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Data;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Bortsevych.Pages.Admin;

public class DeleteModel : PageModel
{
    private readonly Bortsevych.Data.ApplicationDbContext _context;

    public DeleteModel(Bortsevych.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
  public Project Project { get; set; } = default!;

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

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (id == null || _context.Projects == null)
        {
            return NotFound();
        }
        var project = await _context.Projects.FindAsync(id);

        if (project != null)
        {
            Project = project;
            _context.Projects.Remove(Project);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
