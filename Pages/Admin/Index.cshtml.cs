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

namespace Bortsevych.Pages.Admin;

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
