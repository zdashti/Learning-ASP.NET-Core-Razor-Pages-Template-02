﻿namespace ViewModels.Pages.Admin.RoleManager
{
	public class DeleteRoleRequestViewModel : Base.RoleExtendedViewModel
	{
		public DeleteRoleRequestViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsSystemic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsSystemic { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.InsertDateTime))]
		public System.DateTime InsertDateTime { get; set; }
		// **********
	}
}
