using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataAccess
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("ToDo"))
                MyEntry.Text = "Text";
                           //Application.Current.Properties["ToDo"].ToString();
            if (Application.Current.Properties.ContainsKey("IsTrue"))

                MySwitch.On = (bool)Application.Current.Properties["IsTrue"];
            //   FillData();


        }

        public async void FillData()
        {
            try
            {
                MyEntry.Text = Application.Current.Properties["ToDosdf"].ToString();
                MySwitch.On = (bool)Application.Current.Properties["IsTrue"];
            }
            catch (Exception e)
            {
                await  DisplayAlert("Exception", e.Message, "Ok");
            }
        }
        protected async override  void OnDisappearing()
        {
            base.OnDisappearing();
            await Application.Current.SavePropertiesAsync();

        }

        private async void OnChage(object sender, EventArgs e)
        {
            Application.Current.Properties["ToDo"] = MyEntry.Text;
            Application.Current.Properties["IsTrue"] = MySwitch.On;
            //await Application.Current.SavePropertiesAsync();

        }
    }
}
