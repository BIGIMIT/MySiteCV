using Bortsevych.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bortsevych.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {

    }
}