using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess.Annotations;
using DataAccess.Model;
using DataAccess.Service;
using Xamarin.Forms;

namespace DataAccess.ViewModel
{
    public class EmployeViewModel :INotifyPropertyChanged
    {
        private List<Employe> _employes;

        public List<Employe> Employes
        {
            get { return _employes; }
            set
            {
                if(_employes ==value)
                    return;
                _employes = value;
                OnPropertyChanged();
            }
          
        }

        public async Task GetEmployeList()
        {
            EmployeService employeService = new EmployeService();
            Employes = await employeService.GetEmployeAsync();
        }

        public EmployeViewModel()
        {
            GetEmployeList();
        }

        private ICommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                return  new Command(

                    async () =>
                    {
                        IsRefresh = true;
                       await GetEmployeList();
                        IsRefresh = false;

                    });
            }
        }

        private bool _isRefresh = false;

        public bool IsRefresh
        {
            get { return _isRefresh; }
            set
            {
                if (_isRefresh == value)
                    return;
                _isRefresh = value;
                OnPropertyChanged();
            }
        }

        private Employe _myEmploye = new Employe();

        public Employe MyEmploye
        {
            get { return _myEmploye; }
            set
            {
                if(_myEmploye==value)
                    return;
                _myEmploye = value;
                OnPropertyChanged();
            }
        }

        private ICommand _postEmploye;
        public ICommand PostEmploye
        {
            get
            {
                return new Command(

                    async () =>
                    {

                        EmployeService employeService = new EmployeService();
                        await employeService.PostEmployeAsync(MyEmploye);

                    });
            }
        }
        public ICommand DeleteEmploye
        {
            get
            {
                return new Command(

                    async (d) =>
                    {
                        Employe e = new Employe();
                        e = (Employe) d;
                        EmployeService employeService = new EmployeService();
                        await employeService.DeleteAsync(e.DepartementId,e);

                    });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
