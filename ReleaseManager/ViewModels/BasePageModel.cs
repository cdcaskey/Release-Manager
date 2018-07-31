using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReleaseManager.ViewModels
{
    public abstract class BasePageModel : PageModel
    {
        public abstract string Title { get; }
    }
}
