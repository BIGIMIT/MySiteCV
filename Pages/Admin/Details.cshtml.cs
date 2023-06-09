﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bortsevych.Pages.Admin;
[Authorize(Roles = "Administrator")]
public class DetailsModel : PageModel
{
    private readonly Bortsevych.Data.ApplicationDbContext _context;

    public DetailsModel(Bortsevych.Data.ApplicationDbContext context)
    {
        _context = context;
    }

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
}
