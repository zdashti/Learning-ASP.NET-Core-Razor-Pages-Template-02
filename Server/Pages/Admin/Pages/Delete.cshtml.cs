using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.Pages;

[Microsoft.AspNetCore.Authorization.Authorize
    (Roles = Infrastructure.Constants.Role.Admin)]
public class DeleteModel : Infrastructure.BasePageModelWithDatabaseContext
{
    public DeleteModel
        (Data.DatabaseContext databaseContext,
        Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) : base(databaseContext: databaseContext)
    {
        Logger = logger;

        ViewModel = new();
    }

    // **********
    private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }
    // **********

    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public ViewModels.Pages.Admin.Pages.DetailsOrDeleteViewModel ViewModel { get; private set; }
    // **********

    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
    {
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
                    .Select(current => new ViewModels.Pages.Admin.Pages.DetailsOrDeleteViewModel()
                    {
                        Id = current.Id,
                        Title = current.Title,
                        IsActive = current.IsActive,
                        Ordering = current.Ordering,
                        IsFeatured = current.IsFeatured,
                        Description = current.Description,
                        InsertDateTime = current.InsertDateTime,
                        UpdateDateTime = current.UpdateDateTime,
                    })
                    .FirstOrDefaultAsync();

                if (ViewModel == null)
                {
                    AddToastError
                        (message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

                    return RedirectToPage(pageName: "Index");
                }

                return Page();
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

    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? id)
    {
        try
        {
            if (id.HasValue == false)
            {
                AddToastError
                    (message: Resources.Messages.Errors.IdIsNull);

                return RedirectToPage(pageName: "Index");
            }

            // **************************************************
            var foundedItem =
                await
                DatabaseContext.Pages
                .Where(current => current.Id == id.Value)
                .FirstOrDefaultAsync();

            if (foundedItem == null)
            {
                AddToastError
                    (message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

                return RedirectToPage(pageName: "Index");
            }

            if (foundedItem.IsUndeletable)
            {
                AddToastError
                (message: string.Format(
                    Resources.Messages.Errors.UnableTo,
                    Resources.ButtonCaptions.Delete,
                    Resources.DataDictionary.Page));

                return RedirectToPage(pageName: "Index");
            }

            var userId = new System.Guid(HttpContext.User.Identity.Name);

            foundedItem.Delete(userId);

            await DatabaseContext.SaveChangesAsync();
            // **************************************************

            // **************************************************
            var successMessage = string.Format
                (Resources.Messages.Successes.Deleted,
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
