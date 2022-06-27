namespace ViewModels.Pages.Page
{
    public class PageItemViewModel : object
    {
        public PageItemViewModel() :base()
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
            Name = nameof(Resources.DataDictionary.Author))]
        public string? Author { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        // **********
    }
}
