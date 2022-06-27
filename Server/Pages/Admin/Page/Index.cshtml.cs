using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Pages.Admin.Page
{
    public class IndexModel : Infrastructure.BasePageModel
    {
        private readonly Persistence.DatabaseContext _context;
        public IndexModel(Persistence.DatabaseContext context) : base()
        {
            _context = context;
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Page.IndexPageViewModel ViewModel { get; set; }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            ViewModel.Items = await _context.Pages.Where(x => x.Deleted == false)
                .Select(page => new ViewModels.Pages.Page.PageItemViewModel()
                {
                    Author = page.Author,
                    IsActive = page.IsActive,
                    Title = page.Title
                })
                .ToListAsync();
            return Page();
        }
    }
}
