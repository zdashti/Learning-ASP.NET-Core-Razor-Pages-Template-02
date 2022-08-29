namespace ViewModels.Pages.Admin.Pages;

public class IndexItemViewModel : object
{
    public IndexItemViewModel() : base()
    {
        Title = string.Empty;
    }

    // **********
    public System.Guid Id { get; set; }
    // **********

    // **********
    public bool IsActive { get; set; }
    // **********

    // **********
    public string Title { get; set; }
    // **********

    // **********
    public int Ordering { get; set; }
    // **********

    // **********
    public bool IsFeatured { get; set; }
    // **********

    // **********
    public System.DateTime InsertDateTime { get; set; }
    // **********

    // **********
    public System.DateTime UpdateDateTime { get; set; }
    // **********
}

