namespace ViewModels.Pages.Page
{
    public class UpdatePageViewModel : object
    {
        public UpdatePageViewModel() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength: Domain.Cms.Page.TitleMaximumLength, MinimumLength = Domain.Cms.Page.TitleMinimumLength)]
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
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength: Domain.Cms.Page.DescriptionMaximumLength)]
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public string? Description { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength: Domain.Cms.Page.AuthorMaximumLength)]
        [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Author))]
        public string? Author { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength: Domain.Cms.Page.KeywordsMaximumLength)]
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
            Name = nameof(Resources.DataDictionary.ImageUrl))]
        [System.ComponentModel.DataAnnotations.RegularExpression
        (pattern: Domain.SeedWork.Constant.RegularExpression.Url,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Url))]
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
