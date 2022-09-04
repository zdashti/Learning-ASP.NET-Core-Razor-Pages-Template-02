namespace ViewModels.Pages.Admin.Pages;

public class DetailsOrDeleteViewModel : UpdateViewModel
{
    public DetailsOrDeleteViewModel() : base()
    {
    }

    // **********
    [System.ComponentModel.DataAnnotations.Display
    (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.InsertDateTime))]
    public System.DateTime InsertDateTime { get; set; }
    // **********

    // **********
    [System.ComponentModel.DataAnnotations.Display
    (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateDateTime))]
    public System.DateTime UpdateDateTime { get; set; }
    // **********
}

