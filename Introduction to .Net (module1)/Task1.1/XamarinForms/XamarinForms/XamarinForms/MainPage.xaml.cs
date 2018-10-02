using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private void OnButtonClicked(object sender, EventArgs e)
        {
            var name = Username.Text;
            Label.Text = $"Hello,{name}!";
        }
    }
}
