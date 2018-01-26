using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PhonewordBlank
{
    public partial class ListingPage : ContentPage
    {
        public List<Character> Characters { get; set; }

        public ListingPage()
        {
            Characters = new List<Character> {
                new Character {
                    Name = "Name A",
                    Class = "Warrior"
                },
                new Character {
                    Name = "Name B",
                    Class = "Archer"
                }
            };

            InitializeComponent();
            this.BindingContext = this;
        }
    }

    public class Character {
        public string Name { get; set; }
        public string Class { get; set; }
    }

    public class ViewCellCustom : ViewCell
    {
        public ViewCellCustom()
        {
            //instantiate each of our views
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "Name");
            right.SetBinding(Label.TextProperty, "Class");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}
