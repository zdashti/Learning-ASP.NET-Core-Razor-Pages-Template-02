﻿using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public CreateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			RolesViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel> RolesViewModel
		{ get; private set; }
		// **********
		#endregion /Property(ies)

		#region BindProperty(ies)
		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.CreateUserViewModel ViewModel { get; set; }
		// **********
		#endregion /BindProperty(ies)

		#region OnGet
		public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
		{
			ReturnUrl = SetReturnUrl(returnUrl: returnUrl);

			try
			{
				await SetAccessibleRole();
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
		#endregion /OnGet

		#region OnPost
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			// **************************************************
			string? fixedUsername = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Username);

			string? fixedEmailAddress = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.EmailAddress);
			// **************************************************

			try
			{
				bool isUsernameFound =
					await DatabaseContext.Users
					.Where(current => current.Username == fixedUsername)
					.AnyAsync();

				bool isEmailAddressFound =
					await DatabaseContext.Users
					.Where(current => current.EmailAddress == fixedEmailAddress)
					.Where(current => current.IsEmailAddressVerified.HasValue && current.IsEmailAddressVerified.Value)
					.Where(current => current.IsDeleted == false)
					.AnyAsync();

				// **************************************************
				if (isUsernameFound)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Username);

					AddPageError(message: errorMessage);
				}

				if (isEmailAddressFound)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.EmailAddress);

					AddPageError(message: errorMessage);
				}
				// **************************************************

				if (isUsernameFound || isEmailAddressFound)
				{
					return Page();
				}

				// **************************************************
				if (string.IsNullOrWhiteSpace(value: ViewModel.EmailAddress) == false)
				{
					ViewModel.IsEmailAddressVerified = true;
				}

				if (string.IsNullOrWhiteSpace(value: ViewModel.CellPhoneNumber) == false)
				{
					ViewModel.IsCellPhoneNumberVerified = true;
				}
				// **************************************************

				Domain.Models.User user = new(username: fixedUsername)
				{
					RoleId = ViewModel.RoleId,
					Gender = ViewModel.Gender,
					Ordering = ViewModel.Ordering,

					VerifyDateTime = Domain.SeedWork.Utility.Now,

					IsActive = ViewModel.IsActive,
					IsVerified = ViewModel.IsVerified,
					IsEmailAddressVerified = ViewModel.IsEmailAddressVerified,
					IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified,

					EmailAddress = fixedEmailAddress,
					CellPhoneNumber = ViewModel.CellPhoneNumber,
					LastName = Infrastructure.Utility.FixText(text: ViewModel.LastName),
					FirstName = Infrastructure.Utility.FixText(text: ViewModel.FirstName),
					Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
				};

				var entityEntry =
					await DatabaseContext.AddAsync(entity: user);

				int affectedRow =
					await DatabaseContext.SaveChangesAsync();

				// **************************************************
				if (affectedRow > 0)
				{
					string successMessage = string.Format
						(Resources.Messages.Successes.SuccessfullyCreated,
						Resources.DataDictionary.User);

					AddToastSuccess(message: successMessage);
				}
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await SetAccessibleRole();

				await DisposeDatabaseContextAsync();
			}

			ReturnUrl = SetReturnUrl(returnUrl: ReturnUrl);

			return Redirect(url: ReturnUrl);
		}
		#endregion OnPost

		#region SetAccessibleRole
		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await DatabaseContext.Roles
				.Where(current => current.IsDeleted == false)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel
				{
					Id = current.Id,
					Name = current.Name,
				})
				.ToListAsync()
				;
		}
		#endregion /SetAccessibleRole
	}
}
