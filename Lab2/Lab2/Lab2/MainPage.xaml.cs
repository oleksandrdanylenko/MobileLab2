using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public List<Phone> Phones { get; set; }

        public MainPage()
        {
            Label header = new Label
            {
                Text = "List of models",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Phones = new List<Phone>
            {
                new Phone {Title = "Galaxy S8", Company = "Samsung", Price = 48000},
                new Phone {Title = "Huawei P10", Company = "Huawei", Price = 35000},
                new Phone {Title = "HTC U Ultra", Company = "HTC", Price = 42000},
                new Phone {Title = "iPhone 7", Company = "Apple", Price = 52000}
            };
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Phones,
                ItemTemplate = new DataTemplate(() =>
                {

                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Title");

                    Label companyLabel = new Label();
                    companyLabel.SetBinding(Label.TextProperty, "Company");


                    Label priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, "Price");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { titleLabel, companyLabel, priceLabel }
                        }
                    };
                })
            };
            this.Content = new StackLayout { Children = { header, listView } };
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Phone selectedPhone = e.Item as Phone;
            if (selectedPhone != null)
                await DisplayAlert("Selected Model", $"{selectedPhone.Company} - {selectedPhone.Title}", "OK");
        }
    }
}
