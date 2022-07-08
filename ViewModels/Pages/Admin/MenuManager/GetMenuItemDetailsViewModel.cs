﻿namespace ViewModels.Pages.Admin.MenuManager
{
	public class GetMenuItemDetailsViewModel : object
	{
		public GetMenuItemDetailsViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Menu),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Parent { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Title),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Title { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Link),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Link { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]
		public int Ordering { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsPublic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsPublic { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeletable),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeletable { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsDeleted),
		ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.InsertDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime InsertDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.SubMenus),
			ResourceType = typeof(Resources.DataDictionary))]
		public int NumberOfSubMenus { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Icon),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Icon { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IconPosition),
			ResourceType = typeof(Resources.DataDictionary))]
		public Domain.Models.Enumerations.IconPosition? IconPosition { get; init; }
		// **********
	}
}
