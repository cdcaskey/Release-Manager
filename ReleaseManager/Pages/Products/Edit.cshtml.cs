using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReleaseManager.Data;
using ReleaseManager.Models;
using ReleaseManager.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseManager.Pages.Products
{
    public class EditModel : BasePageModel
    {
        private readonly ApplicationDbContext _context;
        public override string Title => "Edit Product";

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
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

        private bool ProductExists(Guid id) => _context.Product.Any(e => e.Id == id);
    }
}
