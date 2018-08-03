using Microsoft.AspNetCore.Mvc;
using ReleaseManager.Models;
using ReleaseManager.ViewModels;
using System.Threading.Tasks;

namespace ReleaseManager.Pages.Products
{
    public class CreateModel : BasePageModel
    {
        private readonly ReleaseManager.Data.ApplicationDbContext _context;
        public override string Title => "Create Product";

        public CreateModel(ReleaseManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}