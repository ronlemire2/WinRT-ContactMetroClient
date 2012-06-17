using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ContactWinFormsClient {
    public partial class Form1 : Form {
        // TODO: URLs should come from config file.
        public const string CONTACT_SERVICE_MULTIPLE_URL = @"http://192.168.1.71:8080/service.svc/ContactList";
        public const string CONTACT_SERVICE_SINGLE_URL = @"http://192.168.1.71:8080/service.svc/Contact/";
        //public const string CONTACT_SERVICE_MULTIPLE_URL = @"http://rjl005.cloudapp.net:81/service.svc/ContactList";
        //public const string CONTACT_SERVICE_SINGLE_URL = @"http://rjl005.cloudapp.net:81/service.svc/Contact/";

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnGetContactList_Click(object sender, EventArgs e) {
            ClearForm();

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_MULTIPLE_URL);
            req.Method = "Get";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK) {
                using (Stream respStream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    txtResults.Text = reader.ReadToEnd();
                }
            }
        }

        private void btnGetContact_Click(object sender, EventArgs e) {
            txtResults.Text = String.Empty;

            if (txtGetId.Text == string.Empty) {
                MessageBox.Show("Enter Contact Id to Get");
                return;
            }

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + txtGetId.Text);
            req.Method = "Get";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK) {
                using (Stream respStream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    txtResults.Text = reader.ReadToEnd();
                }
            }

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonContact = txtResults.Text.Substring(1, txtResults.Text.Length - 2);
            Contact contact = ser.Deserialize<Contact>(jsonContact);
            txtId.Text = contact.Id;
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            txtEmail.Text = contact.Email;
        }

        private void btnAddContact_Click(object sender, EventArgs e) {
            txtResults.Text = String.Empty;

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + "0");
            req.Method = "PUT";
            req.ContentType = @"application/json; charset=utf-8";

            string id = string.Format(@"{{""Id"": ""{0}""", "0");
            string firstName = string.Format(@"""FirstName"": ""{0}""", txtFirstName.Text);
            string lastName = string.Format(@"""LastName"": ""{0}""", txtLastName.Text);
            string email = string.Format(@"""Email"": ""{0}""}}", txtEmail.Text);
            string addContactString = string.Format("{0},{1},{2},{3}", id, firstName, lastName, email);
            req.ContentLength = Encoding.UTF8.GetByteCount(addContactString);

            using (Stream stream = req.GetRequestStream()) {
                stream.Write(Encoding.UTF8.GetBytes(addContactString), 0, Encoding.UTF8.GetByteCount(addContactString));
            }

            HttpWebResponse resp = null;
            try {
                resp = req.GetResponse() as HttpWebResponse;
                txtResults.Text = string.Format("Status Code: {0}, Status Description: {1}",
                    resp.StatusCode, resp.StatusDescription);
            }
            catch (WebException we) {
                txtResults.Text = we.Message;
            }
        }


        private void btnUpdateContact_Click(object sender, EventArgs e) {
            txtResults.Text = String.Empty;

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + txtGetId.Text);
            req.Method = "PUT";
            req.ContentType = @"application/json; charset=utf-8";

            string id = string.Format(@"{{""Id"": ""{0}""", txtId.Text);
            string firstName = string.Format(@"""FirstName"": ""{0}""", txtFirstName.Text);
            string lastName = string.Format(@"""LastName"": ""{0}""", txtLastName.Text);
            string email = string.Format(@"""Email"": ""{0}""}}", txtEmail.Text);
            string updateContactString = string.Format("{0},{1},{2},{3}", id, firstName, lastName, email);
            req.ContentLength = Encoding.UTF8.GetByteCount(updateContactString);

            using (Stream stream = req.GetRequestStream()) {
                stream.Write(Encoding.UTF8.GetBytes(updateContactString), 0, Encoding.UTF8.GetByteCount(updateContactString));
            }

            HttpWebResponse resp = null;
            try {
                resp = req.GetResponse() as HttpWebResponse;
                txtResults.Text = string.Format("Status Code: {0}, Status Description: {1}",
                    resp.StatusCode, resp.StatusDescription);
            }
            catch (WebException we) {
                txtResults.Text = we.Message;
            }
        }

        private void btnDeleteContact_Click(object sender, EventArgs e) {
            txtResults.Text = String.Empty;

            if (txtGetId.Text == string.Empty) {
                MessageBox.Show("Enter Contact Id to Get");
                return;
            }

            WebRequest req = WebRequest.Create(CONTACT_SERVICE_SINGLE_URL + txtGetId.Text);
            req.Method = "DELETE";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK) {
                using (Stream respStream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    txtResults.Text = reader.ReadToEnd();
                }
            }
        }

        private void ClearForm() {
            txtResults.Text = string.Empty;
            txtId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}
