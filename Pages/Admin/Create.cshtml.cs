using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bortsevych.Data;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Bortsevych.Pages.Admin;
[Authorize(Roles = "Administrator")]
public class CreateModel : PageModel
{
    private readonly Bortsevych.Data.ApplicationDbContext _context;

    public CreateModel(Bortsevych.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Project Project { get; set; } = default!;
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Projects == null || Project == null)
        {
            return Page();
        }

        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
