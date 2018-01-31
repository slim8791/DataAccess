using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeView : ContentPage
    {
        public EmployeView()
        {
            InitializeComponent();
            BindingContext = new EmployeViewModel();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NewEmployeView());
        }

        private async void EmployesList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Employe emp = (Employe) e.Item;
            var verif = await DisplayAlert("Confirm delete", "Do you want to delete the employe "+emp.Name, "Confirm", "Candel");
            if (verif)
            {
                EmployeViewModel evm = new EmployeViewModel();
                evm.DeleteEmploye.Execute(e.Item);
            }

        }
    }
}