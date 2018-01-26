using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PhonewordBlank
{
    public partial class CallHistoryPage : ContentPage
    {
        public CallHistoryPage()
        {
            InitializeComponent();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            await DisplayAlert("Tapped!", e.SelectedItem + " was tapped.", "OK");
            MessagingCenter.Send<CallHistoryPage, string>(this, "TappedMessage", "Megaman X");
        }
    }
}
