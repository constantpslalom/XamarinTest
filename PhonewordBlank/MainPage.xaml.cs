using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhonewordBlank
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        SomeViewModel _someViewModel = new SomeViewModel();

        string translatedNumber;
        string _userName = "Zero";

        public SomeViewModel SomeViewModelProp { 
            get {
                return _someViewModel;
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand StatusChangeCommand { get; set; }

        string _displayText = "Status: Untranslated";
        public string DisplayText
        {
            get
            {
                return _displayText;
            }

            set
            {
                _displayText = value;
                Debug.WriteLine(_displayText);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            // this MUST be assigned before calling InitializeComponent()
            StatusChangeCommand = new Command<string>((input) =>
            {
                DisplayText = $"Status: {input} Translated";
            });

            InitializeComponent();
            this.BindingContext = this;

            MessagingCenter.Subscribe<CallHistoryPage, string>(this, "TappedMessage", (sender, arg) =>
            {
                UserName = arg;
            });
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            var answer = await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + translatedNumber + "?",
                "Yes",
                "No");
    
            Debug.WriteLine("Answer: " + answer);

            if (answer)
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    App.PhoneNumbers.Add(translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
                }
            }
        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }

        async void OnToListing(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListingPage());
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        async void OnToTabbedPage(object sender, EventArgs e) {
            await Navigation.PushAsync(new TestTabbedPage());
            // await Navigation.PopToRootAsync ();
        }
    }

    public class SomeViewModel : INotifyPropertyChanged {

        public ICommand StatusChangeCommand;

        string _displayText = "Status: Untranslated";
        public string DisplayText { 
            get {
                return _displayText;
            }

            set {
                _displayText = value;
                Debug.WriteLine(_displayText);
                OnPropertyChanged();
            }
        }

        public SomeViewModel() {
            StatusChangeCommand = new Command<string>((inputText) =>
            {
                DisplayText = $"Status: {inputText} Translated";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}