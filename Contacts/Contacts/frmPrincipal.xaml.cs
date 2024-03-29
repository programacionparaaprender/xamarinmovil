﻿using Contacts.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //    new Position(19.242142, -90.237137),
            //    Distance.FromKilometers(10)
            //    ));

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        
        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Contacts());
        }

        private void ToolbarItem_GoogleMaps(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmGoogleMaps());
        }
    }
}