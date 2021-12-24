using RandomUserApp.Presentation.UX.UI.Pages;
using Xamarin.Forms;

namespace RandomUserApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FemaleUsersPage), typeof(FemaleUsersPage));
            Routing.RegisterRoute(nameof(UserDetailPage), typeof(UserDetailPage));
            Routing.RegisterRoute(nameof(MaleUsersPage), typeof(MaleUsersPage));

            CurrentItem = randomItem;
            //CurrentItem.CurrentItem = CurrentItem.Items[1];
        }
    }
}
