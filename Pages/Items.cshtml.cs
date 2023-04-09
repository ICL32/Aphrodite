using Aphrodite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aphrodite.Pages;

public class Item : PageModel
{
    public ItemsModel LipStick { get; set; }
    public void OnGet()
    {
        
    }
}