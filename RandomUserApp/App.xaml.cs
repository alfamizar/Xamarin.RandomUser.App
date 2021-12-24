using RandomUserApp.Data.DataBases
;
using RandomUserApp.Data.Repositories.Rest;
using RandomUserApp.Presentation.UX.UI.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomUserApp
{
    public partial class App : Application
    {
        private static App _instance;

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //DependencyService.Register<IMobileService>();
            MainPage = new AppShell();
            _instance = this;
        }

        public static App GetInstance()
        {
            return _instance;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
