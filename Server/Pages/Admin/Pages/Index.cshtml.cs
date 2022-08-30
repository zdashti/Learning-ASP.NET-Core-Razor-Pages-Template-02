using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.Pages;

[Microsoft.AspNetCore.Authorization.Authorize
    (Roles = Infrastructure.Constants.Role.Admin)]
public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
{
    public IndexModel
        (Data.DatabaseContext databaseContext,
        Microsoft.Extensions.Logging.ILogger<IndexModel> logger) : base(databaseContext: databaseContext)
    {
        Logger = logger;

        ViewModel =
            new System.Collections.Generic.List
                <ViewModels.Pages.Admin.Pages.IndexItemViewModel>();
    }

    // **********
    private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
    // **********

    // **********
    public System.Collections.Generic.IList
        <ViewModels.Pages.Admin.Pages.IndexItemViewModel> ViewModel
    { get; private set; }
    // **********

    // TO DO: Let Users Select Page Size
    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult>
        OnGetAsync(int pageSize = 10, int pageNumber = 1)
    {
        try
        {
            ViewModel =
                await
                    DatabaseContext.Pages
                        .OrderBy(current => current.Ordering)
                        .ThenBy(current => current.Title)
                        .Where(current => current.IsDeleted == false)
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize)
                        .Select(current => new ViewModels.Pages.Admin.Pages.IndexItemViewModel
                        {
                            Id = current.Id,
                            Title = current.Title,
                            IsActive = current.IsActive,
                            Ordering = current.Ordering,
                            IsFeatured = current.IsFeatured,
                            InsertDateTime = current.InsertDateTime,
                            UpdateDateTime = current.UpdateDateTime,
                        })
                        .ToListAsync();
        }
        catch (System.Exception ex)
        {
            Logger.LogError
                (message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

            AddPageError
                (message: Resources.Messages.Errors.UnexpectedError);
        }
        finally
        {
            await DisposeDatabaseContextAsync();
        }

        return Page();
    }
}
