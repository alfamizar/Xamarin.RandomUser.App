using RandomUserApp.Presentation.UX.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.UI.Pages
{
    public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel _viewModel;

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