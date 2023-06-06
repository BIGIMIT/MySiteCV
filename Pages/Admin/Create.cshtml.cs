using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bortsevych.Models;
using Microsoft.AspNetCore.Authorization;

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
        Project.UpdateAt = DateTime.Now;
        Project.CreateAt = DateTime.Now;
        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
