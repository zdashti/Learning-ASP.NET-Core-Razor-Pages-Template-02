using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using ViewModels.Pages.Admin.Pages;

namespace Server.Pages.Admin.Pages;

[Microsoft.AspNetCore.Authorization.Authorize
    (Roles = Infrastructure.Constants.Role.Admin)]
public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
{
    public CreateModel
        (Data.DatabaseContext databaseContext,
        Microsoft.Extensions.Logging.ILogger<CreateModel> logger) :
        base(databaseContext: databaseContext)
    {
        Logger = logger;
        ViewModel = new();
    }

    // **********
    private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
    // **********

    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public CreateViewModel ViewModel { get; set; }
    // **********

    public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
    {
        return Page();
    }

    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
    {
        if (HttpContext.User.Identity?.Name == null)
        {
            return RedirectToPage("/account/login");
        }

        if (ModelState.IsValid == false)
        {
            return Page();
        }

        try
        {
            var fixedTitle =
                Dtat.Utility.FixText
                    (text: ViewModel.Title);

            var foundedAny =
                await
                    DatabaseContext.Pages
                        .Where(current => current.Title.ToLower() == fixedTitle.ToLower())
                        .AnyAsync();

            if (foundedAny)
            {
                // **************************************************
                var errorMessage = string.Format
                (Resources.Messages.Errors.AlreadyExists,
                    Resources.DataDictionary.Title);

                AddPageError(message: errorMessage);
                // **************************************************

                return Page();
            }

            var userId = new System.Guid(HttpContext.User.Identity.Name);

            var fixedAuthor =
                Dtat.Utility.FixText
                    (text: ViewModel.Author);

            var fixedDescription =
               Dtat.Utility.FixText
               (text: ViewModel.Description);

            var newEntity = new Domain.Page(ViewModel.Title, ViewModel.PageCategoryId, userId)
            {
                IsSystemic = false,
                Title = fixedTitle,
                Author = fixedAuthor,
                Body = ViewModel.Body,
                LayoutId = ViewModel.LayoutId,
                IsActive = ViewModel.IsActive,
                Category = ViewModel.Category,
                ImageUrl = ViewModel.ImageUrl,
                Ordering = ViewModel.Ordering,
                Password = ViewModel.Password,
                Description = fixedDescription,
                Copyright = ViewModel.Copyright,
                IsFeatured = ViewModel.IsFeatured,
                Introduction = ViewModel.Introduction,
                HasAttachment = ViewModel.HasAttachment,
                IsUnupdatable = ViewModel.IsUnupdatable,
                IsUndeletable = ViewModel.IsUndeletable,
                Classification = ViewModel.Classification,
                DisplayCreatorUser = ViewModel.DisplayCreatorUser,
                IsCommentingEnabled = ViewModel.IsCommentingEnabled,
                PublishStartDateTime = ViewModel.PublishStartDateTime,
                PublishFinishDateTime = ViewModel.PublishFinishDateTime,
                DoesSearchEnginesIndexIt = ViewModel.DoesSearchEnginesIndexIt,
                DoesSearchEnginesFollowIt = ViewModel.DoesSearchEnginesFollowIt,
            };

            var entityEntry =
                await
                    DatabaseContext.AddAsync(entity: newEntity);

            var affectedRows =
                await
                    DatabaseContext.SaveChangesAsync();
            // **************************************************

            // **************************************************
            var successMessage = string.Format
            (Resources.Messages.Successes.Created,
                Resources.DataDictionary.Page);

            AddToastSuccess(message: successMessage);
            // **************************************************

            return RedirectToPage(pageName: "Index");
        }
        catch (System.Exception ex)
        {
            Logger.LogError
                (message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

            AddToastError
                (message: Resources.Messages.Errors.UnexpectedError);

            return RedirectToPage(pageName: "Index");
        }
        finally
        {
            await DisposeDatabaseContextAsync();
        }
    }
}
