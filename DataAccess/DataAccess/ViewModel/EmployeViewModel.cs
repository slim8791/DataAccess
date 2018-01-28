using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Annotations;
using DataAccess.Model;
using DataAccess.Service;

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




        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
