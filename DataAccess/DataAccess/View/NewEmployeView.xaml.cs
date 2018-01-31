using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmployeView : ContentPage
    {
        public NewEmployeView()
        {
            InitializeComponent();
            BindingContext = new EmployeViewModel();

        }
    }
}