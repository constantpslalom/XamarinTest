using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PhonewordBlank
{
    public partial class TestTabbedPage : TabbedPage
    {
        public TestTabbedPage()
        {
            InitializeComponent();

            ItemsSource = new ObservableCollection<TestTabbedModel>
            {
                new TestTabbedModel {
                    Name = "Zero",
                    PhotoUrl = "icon.png",
                    Weapon = "Z-Saber"
                },
                new TestTabbedModel {
                    Name = "X",
                    PhotoUrl = "https://pbs.twimg.com/profile_images/933480702267363329/8aEmXgCX_400x400.jpg",
                    Weapon = "X-Buster"
                }
            };
        }

        protected override void OnAppearing() {
            DisplayAlert("OnAppearing", "Hi!", "Proceed"); // don't need to supply both buttons
        }

        protected override async void OnDisappearing()
        {
            var action = await DisplayActionSheet("ActionSheet: Select Option", "Cancel", "Delete", "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }
    }

    public class TestTabbedModel
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Weapon { get; set; }
    }
}
