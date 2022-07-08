using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuManager
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext,
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
		public ViewModels.Pages.Admin.MenuManager.UpdateMenuItemViewModel ViewModel { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.MenuManager.GetAccessibleParentMenuViewModel>? ParentsViewModel
		{ get; private set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Menus
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.MenuManager.UpdateMenuItemViewModel
					{
						Id = current.Id,
						Icon = current.Icon,
						Link = current.Link,
						Title = current.Title,
						Ordering = current.Ordering,
						IsPublic = current.IsPublic,
						IsActive = current.IsActive,
						ParentId = current.ParentId,
						Parent = current.Parent.Title,
						IsDeletable = current.IsDeletable,
						IconPosition = current.IconPosition,
					}).FirstOrDefaultAsync();
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await SetAccessibleParent(id: id);

				await DisposeDatabaseContextAsync();
			}

			return Page();
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
				var foundedItem =
					await DatabaseContext.Menus
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.NotFound,
						Resources.DataDictionary.Menu);

					AddToastError(message: errorMessage);
				}
				else
				{
					string? fixedTitle =
						Infrastructure.Utility.FixText(text: foundedItem.Title);

					bool hasAny =
						await DatabaseContext.Menus
						.Where(current => current.Title.ToLower() == ViewModel.Title.ToLower())
						.Where(current => current.Id != id)
						.AnyAsync();

					if (hasAny)
					{
						// **************************************************
						string errorMessage = string.Format
							(Resources.Messages.Errors.AlreadyExists,
							Resources.DataDictionary.Title);

						AddPageError(message: errorMessage);

						return Page();
						// **************************************************
					}


					if (ViewModel.ParentId.HasValue)
					{
						bool isParent =
							await DatabaseContext.Menus
							.Where(current => current.ParentId == foundedItem.Id)
							.AnyAsync();

						if (isParent)
						{
							string errorMesage =
								Resources.Messages.Errors.UnableToUpdateParent;

							AddPageError(message: errorMesage);

							return Page();
						}
					}

					// **************************************************
					foundedItem.Icon = ViewModel.Icon;
					foundedItem.Title = ViewModel.Title;
					foundedItem.ParentId = ViewModel.ParentId;
					foundedItem.IsPublic = ViewModel.IsPublic;
					foundedItem.IsActive = ViewModel.IsActive;
					foundedItem.Ordering = ViewModel.Ordering;
					foundedItem.IsDeletable = ViewModel.IsDeletable;
					foundedItem.IconPosition = ViewModel.IconPosition;

					foundedItem.SetUpdateDateTime();
					// **************************************************

					var entityEntry =
						DatabaseContext.Update(entity: foundedItem);

					int affectedRows =
						await DatabaseContext.SaveChangesAsync();

					// **************************************************
					if (affectedRows > 0)
					{
						string successMessage = string.Format
							(Resources.Messages.Successes.SuccessfullyUpdated,
							Resources.DataDictionary.Menu);

						AddToastSuccess(message: successMessage);
					}
					// **************************************************
				}

				return RedirectToPage("./Index");
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await SetAccessibleParent(id: id);

				await DisposeDatabaseContextAsync();
			}
		}

		private async System.Threading.Tasks.Task SetAccessibleParent(System.Guid id)
		{
			ParentsViewModel =
				await DatabaseContext.Menus
				.Where(current => current.IsDeleted == false)
				.Where(current => current.ParentId == null)
				.Where(current => current.Id != id)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.MenuManager.GetAccessibleParentMenuViewModel
				{
					Id = current.Id,
					Title = current.Title,
				})
				.ToListAsync()
				;
		}
	}
}
