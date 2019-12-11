using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Classes;
using SQLite;


namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contacts : ContentPage
    {
        public Contacts()
        {
            InitializeComponent();
        }
        //private void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();
                contactsListView.ItemsSource = contacts;
            }
        }
        private void EliminarContacto(object sender, EventArgs e)
        {
            if (contactsListView.SelectedItem == null) 
            {
                return;
            }
            Contact contact = (Contact)contactsListView.SelectedItem;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();
                foreach (Contact temp in contacts)
                {
                    if (temp.Id == contact.Id)
                    {
                        int rowsAdded = conn.Delete(contact);
                    }
                }

            }
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            if (contactsListView.SelectedItem == null)
            {
                return;
            }
            Contact contact = (Contact)contactsListView.SelectedItem;
            Navigation.PushAsync(new frmEditarContacto(contact));
        }
    }
}
