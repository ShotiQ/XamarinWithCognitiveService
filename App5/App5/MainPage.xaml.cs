using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello", "Hi, " + enUsername.Text, "Sige");
            Navigation.PushAsync(new TabbedPage1());
        }

    }
}
