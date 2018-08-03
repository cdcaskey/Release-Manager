using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReleaseManager.Data;
using ReleaseManager.Models;
using ReleaseManager.ViewModels;
using System;
using System.Threading.Tasks;

namespace ReleaseManager.Pages.Products
{
    public class DetailsModel : BasePageModel
    {
        private readonly ApplicationDbContext _context;
        public override string Title => "Product Details";

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
