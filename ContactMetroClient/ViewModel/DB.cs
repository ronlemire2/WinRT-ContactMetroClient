using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using ContactMetroClient.Model;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace ContactMetroClient.ViewModel {
    public class DB {
        // TODO: URLs should come from config file.
        //public const string CONTACT_SERVICE_MULTIPLE_URL = @"http://192.168.1.71:8080/service.svc/ContactList";
        //public const string CONTACT_SERVICE_SINGLE_URL = @"http://192.168.1.71:8080/service.svc/Contact/";
        public const string CONTACT_SERVICE_MULTIPLE_URL = @"http://rjl006.cloudapp.net:81/service.svc/ContactList";
        public const string CONTACT_SERVICE_SINGLE_URL = @"http://rjl006.cloudapp.net:81/service.svc/Contact/";

        public ObservableCollection<Contact> contactlist { get; set; }

        public async Task GetContactList() {
            WebRequest req = WebRequest.Create(CONTACT_SERVICE_MULTIPLE_URL);
            req.Method = "Get";

            string contactsString = string.Empty;
            HttpWebResponse resp = await req.GetResponseAsync() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK) {
                using (Stream respStream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    contactsString = reader.ReadToEnd();
                }
            }

            JsonArray ja = JsonArray.Parse(contactsString);
            var qry = from j in ja
                      select new Contact {
                          Id = (int) j.GetObject()["Id"].GetNumber(),
                          FirstName = j.GetObject()["FirstName"].GetString(),
                          LastName = j.GetObject()["LastName"].GetString(),
                          Email = j.GetObject()["Email"].GetString()
                      };

            if (contactlist == null) contactlist = new ObservableCollection<Contact>();
            contactlist.Clear();

            foreach (Contact c in qry) {
                contactlist.Add(new Contact { Id = c.Id, FirstName = c.FirstName, LastName = c.LastName, Email = c.Email });
            }

        }

        public async void Save(Contact c) {
            string results = String.Empty;

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + c.Id.ToString());
            req.Method = "PUT";
            req.ContentType = @"application/json; charset=utf-8";

            string id = string.Format(@"{{""Id"": ""{0}""", "0");
            string firstName = string.Format(@"""FirstName"": ""{0}""", c.FirstName);
            string lastName = string.Format(@"""LastName"": ""{0}""", c.LastName);
            string email = string.Format(@"""Email"": ""{0}""}}", c.Email);
            string addContactString = string.Format("{0},{1},{2},{3}", id, firstName, lastName, email);
            //req.ContentLength = Encoding.UTF8.GetByteCount(addContactString);

            using (Stream stream = await req.GetRequestStreamAsync()) {
                stream.Write(Encoding.UTF8.GetBytes(addContactString), 0, Encoding.UTF8.GetByteCount(addContactString));
            }

            HttpWebResponse resp = null;
            try {
                resp = await req.GetResponseAsync() as HttpWebResponse;
                results = string.Format("Status Code: {0}, Status Description: {1}",
                    resp.StatusCode, resp.StatusDescription);
            }
            catch (WebException we) {
                results = we.Message;
            }
        }

        public async void Update(Contact c) {
            string results = String.Empty;

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + c.Id.ToString());
            req.Method = "PUT";
            req.ContentType = @"application/json; charset=utf-8";

            string id = string.Format(@"{{""Id"": ""{0}""", c.Id);
            string firstName = string.Format(@"""FirstName"": ""{0}""", c.FirstName);
            string lastName = string.Format(@"""LastName"": ""{0}""", c.LastName);
            string email = string.Format(@"""Email"": ""{0}""}}", c.Email);
            string updateContactString = string.Format("{0},{1},{2},{3}", id, firstName, lastName, email);

            using (Stream stream = await req.GetRequestStreamAsync()) {
                stream.Write(Encoding.UTF8.GetBytes(updateContactString), 0, Encoding.UTF8.GetByteCount(updateContactString));
            }

            HttpWebResponse resp = null;
            try {
                resp = await req.GetResponseAsync() as HttpWebResponse;
                results = string.Format("Status Code: {0}, Status Description: {1}",
                    resp.StatusCode, resp.StatusDescription);
            }
            catch (WebException we) {
                results = we.Message;
            }
        }

        public async void Delete(Contact c) {
            string results = String.Empty;

            if (c.Id == 0) {
                await new MessageDialog("Contact Id is 0", "Delete Error").ShowAsync();
                return;
            }

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + c.Id.ToString());
            req.Method = "DELETE";

            HttpWebResponse resp = await req.GetResponseAsync() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK) {
                using (Stream respStream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    results = reader.ReadToEnd();
                }
            }
        }
    }
}
