namespace ViewModels.Pages.Admin.Pages;

public class DetailsOrDeleteViewModel : UpdateViewModel
{
    public DetailsOrDeleteViewModel() : base()
    {
        InsertDateTime =
            Domain.SeedWork.Utility.Now;

        UpdateDateTime =
            Domain.SeedWork.Utility.Now;
    }

    // **********
    // **********
    // **********
    public System.DateTime InsertDateTime { get; set; }
    // **********

    // **********
    [System.ComponentModel.DataAnnotations.Display
    (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.InsertDateTime))]
    public string DisplayInsertDateTime
    {
        get
        {
            var result =
                InsertDateTime.ToString
                    (format: Domain.SeedWork.Constants.Format.DateTime);

            return result;
        }
    }
    // **********
    // **********
    // **********

    // **********
    // **********
    // **********
    public System.DateTime UpdateDateTime { get; set; }
    // **********
    // **********

    // **********
    [System.ComponentModel.DataAnnotations.Display
    (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateDateTime))]
    public string DisplayUpdateDateTime
    {
        get
        {
            var result =
                UpdateDateTime.ToString
                    (format: Domain.SeedWork.Constants.Format.DateTime);

            return result;
        }
    }
    // **********
    // **********
    // **********
}

