using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Page
{
    public class UpdateModel : Infrastructure.BasePageModel
    {
        private Domain.Cms.Page? _page;
        private readonly Persistence.DatabaseContext _context;

        public UpdateModel(Persistence.DatabaseContext context) : base()
        {
            _context = context;
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Page.UpdatePageViewModel ViewModel { get; set; }

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

            ViewModel = new ViewModels.Pages.Page.UpdatePageViewModel()
            {
                Body = _page.Body,
                Title = _page.Title,
                Author = _page.Author,
                ImageUrl = _page.ImageUrl,
                Category = _page.Category,
                IsActive = _page.IsActive,
                Keywords = _page.Keywords,
                Ordering = _page.Ordering,
                Description = _page.Description,
                PublishFinishDateTime = _page.PublishFinishDateTime,
                PublishStartDateTime = _page.PublishStartDateTime,
                IsCommentingEnabled = _page.IsCommentingEnabled,
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

            _page.Body = ViewModel.Body;
            _page.Title = ViewModel.Title;
            _page.Author = ViewModel.Author;
            _page.Keywords = ViewModel.Keywords;
            _page.IsActive = ViewModel.IsActive;
            _page.Category = ViewModel.Category;
            _page.ImageUrl = ViewModel.ImageUrl;
            _page.Ordering = ViewModel.Ordering;
            _page.Description = ViewModel.Description;
            _page.IsCommentingEnabled = ViewModel.IsCommentingEnabled;
            _page.PublishStartDateTime = ViewModel.PublishStartDateTime;
            _page.PublishFinishDateTime = ViewModel.PublishFinishDateTime;

            _page.Update(userId);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
