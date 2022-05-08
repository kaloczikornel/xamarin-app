using IceAndFire.ViewModels;
using IceAndFire.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IceAndFire
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(CharacterDetailPage), typeof(CharacterDetailPage));
            Routing.RegisterRoute(nameof(HouseDetailPage), typeof(HouseDetailPage));

        }

    }
}
