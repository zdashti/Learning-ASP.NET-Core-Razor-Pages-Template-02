using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.Pages;

[Microsoft.AspNetCore.Authorization
    .Authorize(Roles = Constants.Role.Admin)]
public class UpdateModel : Infrastructure.BasePageModelWithDatabaseContext
{
    public UpdateModel
        (Data.DatabaseContext databaseContext,
        Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) : base(databaseContext: databaseContext)
    {
        Logger = logger;

        ViewModel = new();
    }

    // **********
    private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
    // **********

    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public ViewModels.Pages.Admin.Pages.UpdateViewModel ViewModel { get; set; }
    // **********


    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
    {
        try
        {
            if (id.HasValue == false)
            {
                AddToastError
                    (message: Resources.Messages.Errors.IdIsNull);

                return RedirectToPage(pageName: "Index");
            }

            ViewModel =
                await
                DatabaseContext.Pages
                .Where(current => current.Id == id.Value)
                .Select(current => new ViewModels.Pages.Admin.Pages.UpdateViewModel()
                {
                    Id = current.Id,
                    Title = current.Title,
                    Author = current.Author,
                    Body = current.Body,
                    LayoutId = current.LayoutId,
                    IsActive = current.IsActive,
                    Category = current.Category,
                    ImageUrl = current.ImageUrl,
                    Ordering = current.Ordering,
                    Password = current.Password,
                    Copyright = current.Copyright,
                    IsFeatured = current.IsFeatured,
                    Description = current.Description,
                    Introduction = current.Introduction,
                    HasAttachment = current.HasAttachment,
                    IsUnupdatable = current.IsUnupdatable,
                    IsUndeletable = current.IsUndeletable,
                    Classification = current.Classification,
                    DisplayCreatorUser = current.DisplayCreatorUser,
                    IsCommentingEnabled = current.IsCommentingEnabled,
                    PublishStartDateTime = current.PublishStartDateTime,
                    PublishFinishDateTime = current.PublishFinishDateTime,
                    DoesSearchEnginesIndexIt = current.DoesSearchEnginesIndexIt,
                    DoesSearchEnginesFollowIt = current.DoesSearchEnginesFollowIt,
                })
                .FirstOrDefaultAsync();

            if (ViewModel == null)
            {
                AddToastError
                    (message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

                return RedirectToPage(pageName: "Index");
            }

            if (ViewModel.IsUnupdatable)
            {
                AddToastError
                    (message: string.Format(
                        Resources.Messages.Errors.UnableTo,
                        Resources.ButtonCaptions.Update,
                        Resources.DataDictionary.Page));

                return RedirectToPage(pageName: "Index");
            }

            return Page();

        }
        catch (System.Exception ex)
        {
            Logger.LogError
                (message: Domain.SeedWork.Constants.Logger.ErrorMessage,
                args: ex.Message);

            AddToastError
                (message: Resources.Messages.Errors.UnexpectedError);

            return RedirectToPage(pageName: "Index");
        }
        finally
        {
            await DisposeDatabaseContextAsync();
        }
    }

    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid id)
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }

        try
        {
            // **************************************************
            var foundedItem =
                await
                DatabaseContext.Pages
                .Where(current => current.Id == ViewModel.Id)
                .FirstOrDefaultAsync();

            if (foundedItem == null)
            {
                AddToastError
                    (message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

                return RedirectToPage(pageName: "Index");
            }

            if (foundedItem.IsUnupdatable)
            {
                AddToastError
                    (message: string.Format(
                        Resources.Messages.Errors.UnableTo,
                        Resources.ButtonCaptions.Update,
                        Resources.DataDictionary.Page));

                return RedirectToPage(pageName: "Index");
            }
            // **************************************************

            // **************************************************
            var fixedTitle =
               Dtat.Utility.FixText
                   (text: ViewModel.Title);

            var foundedAny =
                await
                    DatabaseContext.Pages
                        .Where(current =>
                            current.Id != ViewModel.Id &&
                            current.IsDeleted == false)
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

            // **************************************************
            var fixedAuthor =
                Dtat.Utility.FixText
                    (text: ViewModel.Author);

            var fixedDescription =
                Dtat.Utility.FixText
                (text: ViewModel.Description);

            foundedItem.SetUpdateDateTime();

            foundedItem.Title = fixedTitle;
            foundedItem.Author = fixedAuthor;
            foundedItem.Body = ViewModel.Body;
            foundedItem.LayoutId = ViewModel.LayoutId;
            foundedItem.IsActive = ViewModel.IsActive;
            foundedItem.Category = ViewModel.Category;
            foundedItem.ImageUrl = ViewModel.ImageUrl;
            foundedItem.Ordering = ViewModel.Ordering;
            foundedItem.Password = ViewModel.Password;
            foundedItem.Description = fixedDescription;
            foundedItem.Copyright = ViewModel.Copyright;
            foundedItem.IsFeatured = ViewModel.IsFeatured;
            foundedItem.Introduction = ViewModel.Introduction;
            foundedItem.HasAttachment = ViewModel.HasAttachment;
            foundedItem.Classification = ViewModel.Classification;
            foundedItem.DisplayCreatorUser = ViewModel.DisplayCreatorUser;
            foundedItem.IsCommentingEnabled = ViewModel.IsCommentingEnabled;
            foundedItem.PublishStartDateTime = ViewModel.PublishStartDateTime;
            foundedItem.PublishFinishDateTime = ViewModel.PublishFinishDateTime;
            foundedItem.DoesSearchEnginesIndexIt = ViewModel.DoesSearchEnginesIndexIt;
            foundedItem.DoesSearchEnginesFollowIt = ViewModel.DoesSearchEnginesFollowIt;
            // **************************************************

            var affectedRows =
                await
                DatabaseContext.SaveChangesAsync();

            // **************************************************
            var successMessage = string.Format
                (Resources.Messages.Successes.Updated,
                Resources.DataDictionary.Page);

            AddToastSuccess(message: successMessage);
            // **************************************************

            return RedirectToPage(pageName: "Index");
        }
        catch (System.Exception ex)
        {
            Logger.LogError
                 (message: Domain.SeedWork.Constants.Logger.ErrorMessage,
                 args: ex.Message);

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
