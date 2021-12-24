using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomUserApp.Presentation.UX.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersCollectionView : ContentView
    {
        public UsersCollectionView()
        {
            InitializeComponent();
        }
    }
}