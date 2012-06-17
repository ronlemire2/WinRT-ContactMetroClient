using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactMetroClient.Model;

namespace ContactMetroClient.ViewModel {
    class ContactViewModel : INotifyPropertyChanged {
        public ObservableCollection<Contact> Contacts { get; set; }
        DB db = new DB();

        public ContactViewModel() {
            AddCommand = new MyCommand<object>(OnAdd);
            SaveCommand = new MyCommand<object>(OnSave);
            UpdateCommand = new MyCommand<object>(OnUpdate);
            DeleteCommand = new MyCommand<object>(OnDelete);
            GetCommand = new MyCommand<object>(GetContact);
        }

        public MyCommand<object> GetCommand { get; set; }
        async void GetContact(object obj) {
            //if (Contacts == null) Contacts = new ObservableCollection<Contact>();
            //Contacts.Clear();
            await db.GetContactList();
            Contacts = db.contactlist;

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Contacts"));

            Debug.WriteLine("Get Contact");
        }
        
        public MyCommand<object> AddCommand { get; set; }
        void OnAdd(object obj) {
            Contact c = new Contact { Id = 0, FirstName = string.Empty, LastName = string.Empty, Email = string.Empty };
            SelectedContact = c;
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedContact"));

            Debug.WriteLine("Add Contact");
        }

        public MyCommand<object> SaveCommand { get; set; }
        void OnSave(object obj) {
            db.Save(SelectedContact);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedContact"));
            Debug.WriteLine("Save Contact");
        }

        public MyCommand<object> UpdateCommand { get; set; }
        void OnUpdate(object obj) {
            db.Update(SelectedContact);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedContact"));
            Debug.WriteLine("Update Contact");
        }

        public MyCommand<object> DeleteCommand { get; set; }
        void OnDelete(object obj) {
            db.Delete(SelectedContact);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedContact"));
            Debug.WriteLine("Delete Contact");
        }

        private Contact _ctc = new Contact();
        public Contact SelectedContact {
            get { return _ctc; }
            set {
                _ctc = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedContact"));

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
