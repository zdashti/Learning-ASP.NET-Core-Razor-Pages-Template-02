namespace Server.Pages.Admin.Page
{
    public class CreateModel : Infrastructure.BasePageModel
    {
        private readonly Persistence.DatabaseContext _context;
        public CreateModel(Persistence.DatabaseContext context) : base()
        {
            _context = context;
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Page.CreatePageViewModel ViewModel { get; set; }

        public void OnGet()
        {
        }

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (HttpContext.User.Identity?.Name == null)
            {
                return RedirectToPage("/account/login");
            }
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var userId = new System.Guid(HttpContext.User.Identity.Name);
            var page = new Domain.Cms.Page(userId)
            {
                Body = ViewModel.Body,
                Title = ViewModel.Title,
                Author = ViewModel.Author,
                Layout = ViewModel.Layout,
                Keywords = ViewModel.Keywords,
                IsActive = ViewModel.IsActive,
                Category = ViewModel.Category,
                ImageUrl = ViewModel.ImageUrl,
                Ordering = ViewModel.Ordering,
                ParentId = ViewModel.ParentId,
                IsDeletable = ViewModel.IsDeletable,
                IsUpdatable = ViewModel.IsUpdatable,
                Description = ViewModel.Description,
                IsCommentingEnabled = ViewModel.IsCommentingEnabled,
                PublishStartDateTime = ViewModel.PublishStartDateTime,
                PublishFinishDateTime = ViewModel.PublishFinishDateTime,
                DoesSearchEnginesIndexIt = ViewModel.DoesSearchEnginesIndexIt,
            };

            _context.Pages.Add(page);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
