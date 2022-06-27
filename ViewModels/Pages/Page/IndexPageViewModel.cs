using System.Collections.Generic;

namespace ViewModels.Pages.Page
{
    public class IndexPageViewModel : object
    {
        public IndexPageViewModel() : base()
        {
            Items = new List<PageItemViewModel>();
        }

        public List<PageItemViewModel> Items { get; set; }
    }
}
