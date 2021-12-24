using RandomUserApp.Presentation.UX.UI.Pages;
using System;
using System.Collections.Generic;
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

            CurrentItem.CurrentItem = CurrentItem.Items[1];
        }

        public void Tododo()
        {
            CurrentItem.CurrentItem = CurrentItem.Items[1];
        }
    }
}
