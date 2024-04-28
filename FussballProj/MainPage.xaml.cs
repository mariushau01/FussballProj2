using FussballProj.Core.ViewModels;


namespace FussballProj
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext  = viewModel;
        }

    }

}
