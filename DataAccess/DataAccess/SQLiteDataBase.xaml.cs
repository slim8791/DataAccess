using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Annotations;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteDataBase : ContentPage
    {
        private int nbr = 1;
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Contact> _contacts; 
        [Table("Contact")]
        public class Contact :INotifyPropertyChanged
        {
            [SQLite.PrimaryKey]
            [SQLite.AutoIncrement]
            public int ContactId { get; set; }
            [MaxLength(20)]
            public string Name { get; set; }

            public string LastName
            {
                get { return _lastName; }
                set {
                    if (_lastName == value)
                    return;
                    _lastName = value;
                    OnPropertyChanged1();
                }
            }
            public string Email { get; set; }
            public string Phone { get; set; }
            
            private string _lastName { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged1([CallerMemberName] string propertyName = null)
            {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public SQLiteDataBase()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected async override void OnAppearing()
        {
          await _connection.DropTableAsync<Contact>();

          await _connection.CreateTableAsync<Contact>();
             var contacts = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(contacts);
            nbr = _contacts.Count;
            ContactList.ItemsSource = _contacts;

            base.OnAppearing();
        }

        private async void AddEvent(object sender, EventArgs e)
        {
            
            Contact c = new Contact
            {
                Email = "h.slim@french-co.fr",
               LastName = "Hammami",
            Name = "Slim "+DateTime.Now,
            Phone = "44 922 325",
            ContactId =  nbr++
            };
            _contacts.Add(c);

            await _connection.InsertAsync(c);
        }

        private async void UpdateEvent(object sender, EventArgs e)
        {

            Contact c = _contacts[0];
            c.LastName += " Updated";
            await  _connection.UpdateAsync(c);
        }

        private async void DeleteEvent(object sender, EventArgs e)
        {
            Contact c = _contacts[0];
            _contacts.Remove(c);
            //await _connection.DeleteAsync(c);
            await _connection.QueryAsync<Contact>("delete from Contact where ContactId = " + c.ContactId);
    

    }
}
}