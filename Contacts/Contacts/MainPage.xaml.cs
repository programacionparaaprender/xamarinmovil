using Contacts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;


namespace Contacts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.btnSave.Clicked += GuardarDatos;

        }
        public void GuardarDatos(object sender, System.EventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameEntry.Text,
                Lastname = lastNameEntry.Text,
                Email = eamilEntry.Text,
                PhoneNumber = phoneEntry.Text,
                Address = addressEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                int rowsAdded = conn.Insert(contact);
            }
        }
    }
}
