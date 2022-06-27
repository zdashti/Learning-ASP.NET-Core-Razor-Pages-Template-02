using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Page
{
    public class UpdateModel : Infrastructure.BasePageModel
    {
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

            var page = await _context.Pages.FirstOrDefaultAsync(page => page.Id == id && page.Deleted == false);

            if (page == null)
            {
                return NotFound();
            }

            ViewModel = new ViewModels.Pages.Page.UpdatePageViewModel()
            {
                Body = page.Body,
                Title = page.Title,
                Author = page.Author,
                ImageUrl = page.ImageUrl,
                Category = page.Category,
                IsActive = page.IsActive,
                Keywords = page.Keywords,
                Ordering = page.Ordering,
                Description = page.Description,
                PublishFinishDateTime = page.PublishFinishDateTime,
                PublishStartDateTime = page.PublishStartDateTime,
                IsCommentingEnabled = page.IsCommentingEnabled,
            };

            return Page();
        }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (HttpContext.User.Identity?.Name == null)
            {
                return RedirectToPage("/account/login");
            }

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var userId = new System.Guid(HttpContext.User.Identity.Name);

            var page = await _context.Pages.FirstOrDefaultAsync(page => page.Id == id && page.Deleted == false);

            if (page == null)
            {
                return NotFound();
            }

            page.Body = ViewModel.Body;
            page.Title = ViewModel.Title;
            page.Author = ViewModel.Author;
            page.Keywords = ViewModel.Keywords;
            page.IsActive = ViewModel.IsActive;
            page.Category = ViewModel.Category;
            page.ImageUrl = ViewModel.ImageUrl;
            page.Ordering = ViewModel.Ordering;
            page.Description = ViewModel.Description;
            page.IsCommentingEnabled = ViewModel.IsCommentingEnabled;
            page.PublishStartDateTime = ViewModel.PublishStartDateTime;
            page.PublishFinishDateTime = ViewModel.PublishFinishDateTime;

            page.Update(userId);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
