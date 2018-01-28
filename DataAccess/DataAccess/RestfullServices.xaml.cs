using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 
namespace DataAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestfullServices : ContentPage
    {
        private ObservableCollection<Departement> _departements;

        public class Departement
        {
            public int DepartementId { get; set; }
            public string Name { get; set; }
        }
        public RestfullServices()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            RestClient<Departement> restClient = new RestClient<Departement>();

            var depts = await restClient.GetAsync();
            _departements = new ObservableCollection<Departement>(depts);
            DepartementsList.ItemsSource = _departements;

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

           await Navigation.PushAsync(new PostDepartement());
        }

        private async void DepartementsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Departement dept =(Departement) e.SelectedItem;
           await  Navigation.PushAsync(new PostDepartement(dept));
        }
    }
}