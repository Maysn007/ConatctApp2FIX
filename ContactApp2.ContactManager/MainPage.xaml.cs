using ContactApp2.Core.ViewModels;

namespace ContactApp2.ContactManager
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;

        }

    }

}
