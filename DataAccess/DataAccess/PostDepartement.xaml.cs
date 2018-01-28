using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDepartement : ContentPage
    {
        RestfullServices.Departement departement = new RestfullServices.Departement();
        public PostDepartement()
        {
            InitializeComponent();
            DeleteBtn.IsEnabled = false;
            PostBtn.Text = "Post Department";
        }
        public PostDepartement(RestfullServices.Departement d)
        {
            InitializeComponent();
            departement = d;
            DeleteBtn.IsEnabled = true;
            DepartementName.Text = d.Name;
            PostBtn.Text = "Put Department";

        }



        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            if (btn.Text.Contains("Post"))
            {


                RestfullServices.Departement d = new RestfullServices.Departement
                {
                    Name = DepartementName.Text
                };

                RestClient<RestfullServices.Departement> restClient = new RestClient<RestfullServices.Departement>();
                await Navigation.PopAsync();
                await restClient.PostAsync(d);
            }
            else
            {

                departement.Name = DepartementName.Text;
               // d.DepartementId = departement.DepartementId;
                

                RestClient<RestfullServices.Departement> restClient = new RestClient<RestfullServices.Departement>();
                await restClient.PutAsync(departement.DepartementId, departement);

                await Navigation.PopAsync();
            }

        }

        private async void ButtonDelete_OnClicked(object sender, EventArgs e)
        {
            RestClient<RestfullServices.Departement> restClient = new RestClient<RestfullServices.Departement>();
            await restClient.DeleteAsync(departement.DepartementId, departement);

            await Navigation.PopAsync();
        }
    }
}