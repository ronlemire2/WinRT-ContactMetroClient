using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMetroClient.Model {
    public class Contact : INotifyPropertyChanged {
        private int _id;
        public int Id {
            get { return _id; }
            set {
                _id = value;
                CP("Id");
            }
        }
        private string _firstName;
        public string FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                CP("FirstName");
            }
        }
        private string _lastName;
        public string LastName {
            get { return _lastName; }
            set {
                _lastName = value;
                CP("LastName");
            }
        }
        private string _email;
        public string Email {
            get { return _email; }
            set {
                _email = value;
                CP("Email");
            }
        }

        private void CP(string s) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
