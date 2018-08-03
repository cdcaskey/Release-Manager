using Microsoft.EntityFrameworkCore;
using ReleaseManager.Data;
using ReleaseManager.Models;
using ReleaseManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReleaseManager.Pages.Products
{
    public class IndexModel : BasePageModel
    {

        private readonly ApplicationDbContext _context;
        public override string Title => "Products";

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync() => Products = await _context.Product.ToListAsync();
    }
}
