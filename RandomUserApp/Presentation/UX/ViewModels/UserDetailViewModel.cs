using RandomUserApp.Domain.Models;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.ViewModels
{
    [QueryProperty(nameof(UserJson), nameof(UserJson))]
    public class UserDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private User _user;
        private string _userJson;
        public string Id { get; set; }

        public Command SwipeCommand { get; }

        public UserDetailViewModel()
        {
            SwipeCommand = new Command<string>(OnSwipe);
        }

        private void OnSwipe(object swipeDirection)
        {
            Debug.WriteLine(swipeDirection);
            Debug.WriteLine(swipeDirection.GetType());
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public User User
        {
            get => _user;
            set
            {
                //var user = JsonSerializer.Deserialize<User>(value);
                SetProperty(ref _user, value);
                LoadUser(value);
            }
        }

        public string UserJson
        {
            get => _userJson;
            set
            {
                SetProperty(ref _userJson, value);
                User = JsonSerializer.Deserialize<User>(value);               
            }
        }

        /*public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }*/

        public async void LoadUser(User user)
        {
            /*try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }*/
        }
    }
}
