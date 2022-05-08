using IceAndFire.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IceAndFire.Views
{
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage()
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel();
        }
    }
}