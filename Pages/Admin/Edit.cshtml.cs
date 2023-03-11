using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Data;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

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
