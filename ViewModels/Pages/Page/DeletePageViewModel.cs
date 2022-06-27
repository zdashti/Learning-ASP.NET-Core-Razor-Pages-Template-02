namespace ViewModels.Pages.Page
{
    public class DeletePageViewModel : object
    {
        public DeletePageViewModel() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Id))]
        public System.Guid? Id { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Title))]
        public string? Title { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public string? Description { get; set; }
        // **********
    }
}
