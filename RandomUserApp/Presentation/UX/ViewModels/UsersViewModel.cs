using RandomUserApp.Data.Repositories.Rest;
using RandomUserApp.Domain.Models;
using RandomUserApp.Presentation.UX.UI.Pages;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {       
        private readonly MobileApi _mobileApi;

        private User _selectedItem;
        private string _gender;
        public ObservableCollection<User> Users { get; set; }
        public Command LoadItemsCommand { get; }
        public Command<User> ItemTapped { get; }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<User>(OnUserSelected);

            _mobileApi = new MobileApi();
            //mobileApi.GetUsers(null, 0);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var respone = await _mobileApi.GetUsers(Gender, 100);
                if (respone == null)
                {
                    return;
                }
                Debug.WriteLine(respone.Users.Count);
                Debug.WriteLine("Response Count____________________________________________________________________________________________________________________");
                Debug.WriteLine("Response Count____________________________________________________________________________________________________________________");
                foreach (var user in respone.Users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;
            SelectedUser = null;
        }

        public User SelectedUser
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnUserSelected(value);
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                SetProperty(ref _gender, value.ToLower());               
            }
        }

        async void OnUserSelected(User user)
        {
            if (user == null)
            {
                return;
            }

            await App.Current.MainPage.Navigation.PushAsync(new UserDetailPage());

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.ItemId)}={item.Id}");
            //await Navigation.PushAsync(new UserDetailPage());
        }
    }
}