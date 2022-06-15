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
        private User _selectedItem;
        public User SelectedUser
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnUserSelected(value);
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                SetProperty(ref _gender, value.ToLower());
            }
        }

        public ObservableCollection<User> Users { get; set; }
        public Command LoadItemsCommand { get; }
        public Command<User> ItemTappedCommand { get; }
        public Command SwipeCommand { get; }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadUserssCommand());
            ItemTappedCommand = new Command<User>(OnUserSelected);
        }

        private async Task ExecuteLoadUserssCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var respone = await MobileService.GetInstance().GetUsers(Gender, 100);
                if (respone == null)
                {
                    return;
                }
             
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