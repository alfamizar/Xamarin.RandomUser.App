using RandomUserApp.Data.Repositories.Rest;
using RandomUserApp.Domain.Models;
using RandomUserApp.Presentation.UX.UI.Pages;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
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
        public Command SwipeCommand { get; }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SwipeCommand = new Command<string>(OnSwipe);

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

        private void OnSwipe(object swipeDirection)
        {
            if (!(swipeDirection is string direction)) return;
            switch (direction)
            {
                case "Left":
                    Debug.WriteLine(Shell.Current.CurrentPage.Title);
                    if (Shell.Current.CurrentPage.Title == "Female")
                    {
                        if (!(Shell.Current is AppShell shell)) return;
                        shell.Tododo();
                    }
                    break;
                case "Right":
                    Debug.WriteLine(Shell.Current.CurrentPage.Title);
                    if (Shell.Current.CurrentPage.Title == "Male")
                    {
                        if (!(Shell.Current is AppShell shell)) return;
                        shell.Tododo();
                    }
                    break;
                default:
                    return;

            }
            Debug.WriteLine(swipeDirection);
            Debug.WriteLine(swipeDirection.GetType());
        }

        async void OnUserSelected(User user)
        {
            if (user == null)
            {
                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserJson)}={JsonSerializer.Serialize<User>(user)}");
        }
    }
}