using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PhonewordBlank
{
    public partial class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty CharNameProperty =
            BindableProperty.Create("CharName", typeof(string), typeof(CustomViewCell), "CharName");

        /*
        public static readonly BindableProperty AgeProperty =
            BindableProperty.Create("", typeof(int), typeof(CustomCell), 0);
        public static readonly BindableProperty LocationProperty =
            BindableProperty.Create("Location", typeof(string), typeof(CustomCell), "Location");
        */

        public string charName
        {
            get { return (string)GetValue(CharNameProperty); }
            set { SetValue(CharNameProperty, value); }
        }


        public CustomViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                labelOne.Text = charName;
            }
        }
    }
}
