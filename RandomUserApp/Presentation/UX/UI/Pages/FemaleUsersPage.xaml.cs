﻿using RandomUserApp.Presentation.UX.ViewModels;
using System.Diagnostics;
using Xamarin.Forms;

namespace RandomUserApp.Presentation.UX.UI.Pages
{
    public partial class FemaleUsersPage : ContentPage
    {
        private readonly UsersViewModel _viewModel;

        public FemaleUsersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new UsersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Gender = Title;
            _viewModel.OnAppearing();
            Debug.WriteLine(Title);
        }
    }
}