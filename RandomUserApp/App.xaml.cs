using Xamarin.Forms;

namespace RandomUserApp
{
    public partial class App : Application
    {
        private static App _instance;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            _instance = this;
            //DependencyService.Register<MockDataStore>();
            //DependencyService.Register<IMobileService>();
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
