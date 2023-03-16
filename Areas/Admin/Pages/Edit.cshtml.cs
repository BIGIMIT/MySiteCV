using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bortsevych.Pages.Admin;
[Authorize(Roles = "Administrator")]
public class EditModel : PageModel
{
    private readonly Bortsevych.Data.ApplicationDbContext _context;

    public EditModel(Bortsevych.Data.ApplicationDbContext context)
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

        var project =  await _context.Projects.FirstOrDefaultAsync(m => m.ID == id);
        if (project == null)
        {
            return NotFound();
        }
        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Project.UpdateAt = DateTime.Now;
        _context.Attach(Project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectExists(Project.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ProjectExists(string id)
    {
      return (_context.Projects?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}
