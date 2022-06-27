using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Page
{
    public class DeleteModel : Infrastructure.BasePageModel
    {
        private Domain.Cms.Page? _page;
        private readonly Persistence.DatabaseContext _context;

        public DeleteModel(Persistence.DatabaseContext context)
        {
            _context = context;
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Page.DeletePageViewModel ViewModel { get; set; }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _page = await _context.Pages.FirstOrDefaultAsync(page => page.Id == id && page.Deleted == false);

            if (_page == null)
            {
                return NotFound();
            }

            ViewModel = new ViewModels.Pages.Page.DeletePageViewModel()
            {
                Title = _page.Title,
                Description = _page.Description,
            };

            return Page();
        }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (HttpContext.User.Identity?.Name == null)
            {
                return RedirectToPage("/account/login");
            }

            if (_page == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var userId = new System.Guid(HttpContext.User.Identity.Name);

            _page.Delete(userId);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
