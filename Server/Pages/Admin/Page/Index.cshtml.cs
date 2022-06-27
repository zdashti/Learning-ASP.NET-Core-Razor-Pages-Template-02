using System.Linq;

namespace Server.Pages.Admin.Page
{
    public class IndexModel : Infrastructure.BasePageModel
    {
        private readonly Persistence.DatabaseContext _context;
        public IndexModel(Persistence.DatabaseContext context) : base()
        {
            _context = context;
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public Infrastructure.PaginatedList<ViewModels.Pages.Page.PageItemViewModel> ViewModel { get; set; }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            ViewModel = await Infrastructure.PaginatedList<ViewModels.Pages.Page.PageItemViewModel>.CreateAsync(
                _context.Pages.Where(x => x.Deleted == false)
                .Select(page => new ViewModels.Pages.Page.PageItemViewModel()
                {
                    Author = page.Author,
                    IsActive = page.IsActive,
                    Title = page.Title
                }), 0, 10);
            return Page();
        }
    }
}
