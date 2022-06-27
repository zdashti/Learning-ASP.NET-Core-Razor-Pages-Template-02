using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Page
{
    public class DetailsModel : Infrastructure.BasePageModel
    {
        private readonly Persistence.DatabaseContext _context;
        public DetailsModel(Persistence.DatabaseContext context) : base()
        {
            _context = context;
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Page.DetailsPageViewModel ViewModel { get; set; }

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

            ViewModel = new ViewModels.Pages.Page.DetailsPageViewModel()
            {
                Body = page.Body,
                Title = page.Title,
                Author = page.Author,
                ImageUrl = page.ImageUrl,
                Category = page.Category,
                IsActive = page.IsActive,
                Keywords = page.Keywords,
                ParentId = page.ParentId,
                Ordering = page.Ordering,
                Description = page.Description,
                IsUpdatable = page.IsUpdatable,
                IsDeletable = page.IsDeletable,
                IsCommentingEnabled = page.IsCommentingEnabled,
                PublishStartDateTime = page.PublishStartDateTime,
                PublishFinishDateTime = page.PublishFinishDateTime,
                Layout = page.Layout,
                DoesSearchEnginesIndexIt = page.DoesSearchEnginesIndexIt,
            };

            return Page();
        }
    }
}
