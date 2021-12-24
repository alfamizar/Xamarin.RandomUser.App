using RandomUserApp.Presentation.UX.ViewModels;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.UI.Pages
{
    public partial class UserDetailPage : ContentPage
    {
        private readonly UserDetailViewModel _viewModel;

        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserDetailViewModel();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}