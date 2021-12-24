using RandomUserApp.Data.Repositories.Rest;
using RandomUserApp.Domain.Models;
using System.Text.Json;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.ViewModels
{
    [QueryProperty(nameof(UserJson), nameof(UserJson))]
    public class UserDetailViewModel : BaseViewModel
    {
        private User _user;
        private bool _tabBarIsVisible = true;
        private string _userJson;

        public bool TabBarIsVisible
        {
            get => _tabBarIsVisible;
            set
            {
                SetProperty(ref _tabBarIsVisible, value);
            }
        }

        public User User
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
            }
        }

        public string UserJson
        {
            get => _userJson;
            set
            {
                SetProperty(ref _userJson, value);
                User = JsonSerializer.Deserialize<User>(value);
                TabBarIsVisible = false;
            }
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;

            if (_user == null)
            {
                var respone = await MobileService.getInstance().GetUsers(null, 1);
                User = respone.Users[0];
            }

            IsBusy = false;
        }

        public override void OnDisappearing()
        {
            base.OnAppearing();
            User = null;
        }
    }
}
