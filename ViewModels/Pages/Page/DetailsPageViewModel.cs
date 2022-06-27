namespace ViewModels.Pages.Page
{
    public class DetailsPageViewModel : object
    {
        public DetailsPageViewModel() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Title))]
        public string? Title { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Body))]
        public string? Body { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public string? Description { get; set; }
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
            Name = nameof(Resources.DataDictionary.Layout))]
        public string? Layout { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Keywords))]
        public string? Keywords { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsCommentingEnabled))]
        public bool IsCommentingEnabled { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DoesSearchEnginesIndexIt))]
        public bool DoesSearchEnginesIndexIt { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ImageUrl))]
        public string? ImageUrl { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.PublishStartDateTime))]
        public System.DateTime? PublishStartDateTime { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.PublishFinishDateTime))]
        public System.DateTime? PublishFinishDateTime { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsUpdatable))]
        public bool IsUpdatable { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsDeletable))]
        public bool IsDeletable { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Parent))]
        public System.Guid? ParentId { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Category))]
        public string? Category { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Ordering))]
        public int Ordering { get; set; }
    }
}
