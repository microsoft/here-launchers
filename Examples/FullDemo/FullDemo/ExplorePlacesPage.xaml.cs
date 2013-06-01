using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;
using System.Device.Location;
using System.Globalization;
using System.Windows.Media;

using Nokia.Phone.HereLaunchers;

namespace FullDemo
{
    public partial class ExplorePlacesPage : PhoneApplicationPage
    {
        public ExplorePlacesPage()
        {
            InitializeComponent();

            List<string> cities = new List<string>();
            cities.Add(PlaceCategoryId.accommodation);
            cities.Add(PlaceCategoryId.administrative_areas_buildings); 
            cities.Add(PlaceCategoryId.eat_drink);
            cities.Add(PlaceCategoryId.going_out);
            cities.Add(PlaceCategoryId.leisure_outdoor);
            cities.Add(PlaceCategoryId.natural_geographical);
            cities.Add(PlaceCategoryId.shopping);
            cities.Add(PlaceCategoryId.sights_museums);
            cities.Add(PlaceCategoryId.transport); 
            StringBox.ItemsSource = cities;  
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((Application.Current as App).SelectedLocation != null)
            {
                LatitudeBox.Text = (Application.Current as App).SelectedLocation.Latitude.ToString();
                LongittudeBox.Text = (Application.Current as App).SelectedLocation.Longitude.ToString();

                (Application.Current as App).SelectedLocation = null;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            (Application.Current as App).SelectedLocation = null;
            try
            {
                (Application.Current as App).SelectedLocation = new GeoCoordinate(Double.Parse(LatitudeBox.Text), Double.Parse(LongittudeBox.Text));
            }
            catch { }

            base.OnNavigatedFrom(e);
        }

        private void Button_gridbut_Click(object sender, RoutedEventArgs e)
        {
            if (sender == LaunchButton)
            {
                GeoCoordinate toGeo = null;
                try
                {
                    toGeo = new GeoCoordinate(Double.Parse(LatitudeBox.Text), Double.Parse(LongittudeBox.Text));
                }
                catch (Exception)
                {
                    toGeo = null;
                }

                try
                {
                    ExploremapsExplorePlacesTask searchMap = new ExploremapsExplorePlacesTask();

                    searchMap.Location = toGeo;
                    if (StringBox.Text.Length > 0){
                        searchMap.Category.Add(StringBox.Text);
                    }

                    searchMap.Show();
                }
                catch (Exception erno)
                {
                    MessageBox.Show("Error message: " + erno.Message);
                }
            }
            else if (sender == getGeoButton)
            {
                NavigationService.Navigate(new Uri("/LocationSelectorPage.xaml?target=Location", UriKind.Relative));
            }
        }
    }
}