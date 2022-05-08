using IceAndFire.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IceAndFire.Views
{
    public partial class HouseDetailPage : ContentPage
    {
        public HouseDetailPage()
        {
            InitializeComponent();
            BindingContext = new HouseDetailViewModel();
        }
    }
}