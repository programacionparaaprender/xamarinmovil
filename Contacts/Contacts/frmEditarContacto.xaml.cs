using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Classes;
using System.ComponentModel;
using SQLite;


namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmEditarContacto : ContentPage
    {
        private Contact contacto;
        public frmEditarContacto(Contact contacto)
        {
            InitializeComponent();
            this.contacto = contacto;
            nameEntry.Text = contacto.Name;
            lastNameEntry.Text = contacto.Lastname;
            eamilEntry.Text = contacto.Email;
            phoneEntry.Text = contacto.PhoneNumber;
            addressEntry.Text = contacto.Address;
        }
        private void BtnSave_Clicked(object sender, EventArgs e)
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
                var contacts = conn.Table<Contact>().ToList();
                foreach (Contact temp in contacts)
                {
                    if (temp.Email == contact.Email)
                    {
                        return;
                    }
                }

            }

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                int rowsAdded = conn.Update(contact);
            }

            Navigation.PushAsync(new ContactsPage());
        }
    }
}