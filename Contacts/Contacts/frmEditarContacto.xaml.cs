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
            contacto.Name = nameEntry.Text;
            contacto.Lastname = lastNameEntry.Text;
            contacto.Email = eamilEntry.Text;
            contacto.PhoneNumber = phoneEntry.Text;
            contacto.Address = addressEntry.Text;
            

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                int rowsAdded = conn.Update(contacto);
            }

            Navigation.PushAsync(new ContactsPage());
        }
    }
}