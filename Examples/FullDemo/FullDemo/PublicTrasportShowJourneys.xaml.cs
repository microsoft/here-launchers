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
    public partial class PublicTrasportShowJourneys : PhoneApplicationPage
    {
        public PublicTrasportShowJourneys()
        {
            InitializeComponent();

            Arrtoggle.Click += Arrtoggle_Click;
            Deptoggle.Click += Arrtoggle_Click;
        }

        void Arrtoggle_Click(object sender, RoutedEventArgs e)
        {
            if (Arrtoggle.IsChecked == true)
            {
                ArrTimeBox.IsEnabled = true;
            }
            else
            {
                ArrTimeBox.IsEnabled = false;
            }

            if (Deptoggle.IsChecked == true)
            {
                DepTimeBox.IsEnabled = true;
            }
            else
            {
                DepTimeBox.IsEnabled = false;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if ((Application.Current as App).RouteOriginLocation != null)
            {
                LatitudeBox2.Text = (Application.Current as App).RouteOriginLocation.Latitude.ToString();
                LongittudeBox2.Text = (Application.Current as App).RouteOriginLocation.Longitude.ToString();

                (Application.Current as App).RouteOriginLocation = null;
            }

            if ((Application.Current as App).SelectedLocation != null)
            {
                LatitudeBox1.Text = (Application.Current as App).SelectedLocation.Latitude.ToString();
                LongittudeBox1.Text = (Application.Current as App).SelectedLocation.Longitude.ToString();

                (Application.Current as App).SelectedLocation = null;
            }
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            (Application.Current as App).RouteOriginLocation = null;
            try
            {
                (Application.Current as App).RouteOriginLocation = new GeoCoordinate(Double.Parse(LatitudeBox2.Text), Double.Parse(LongittudeBox2.Text));
            }
            catch { }

            (Application.Current as App).SelectedLocation = null;
            try
            {
                (Application.Current as App).SelectedLocation = new GeoCoordinate(Double.Parse(LatitudeBox1.Text), Double.Parse(LongittudeBox1.Text));
            }
            catch { }

            base.OnNavigatedFrom(e);
        }

        private void Button_gridbut_Click(object sender, RoutedEventArgs e)
        {
            if (sender == LaunchButton)
            {
                try
                {
                    PublicTransitRouteDestinationTask JourneyTask = new PublicTransitRouteDestinationTask();

                    GeoCoordinate toGeo2 = null;

                    if(LatitudeBox2.Text.Length > 0){
                        toGeo2 = new GeoCoordinate(Double.Parse(LatitudeBox2.Text), Double.Parse(LongittudeBox2.Text));
                    }

                    JourneyTask.Origin = toGeo2;
                    JourneyTask.Destination = new GeoCoordinate(Double.Parse(LatitudeBox1.Text), Double.Parse(LongittudeBox1.Text));

                    if (Arrtoggle.IsChecked == true)
                    {
                        JourneyTask.ArrivalTime = (DateTime)ArrTimeBox.Value;
                    }

                    if (Deptoggle.IsChecked == true)
                    {
                        JourneyTask.DepartureTime = (DateTime)DepTimeBox.Value;
                    }
                    //Additionally origin & destination could have titles set
                    //JourneyTask.OriginTitle = StringBox1.Text;
                    //JourneyTask.DestinationTitle = StringBox2.Text;

                    JourneyTask.Show();
                }
                catch (Exception erno)
                {
                    MessageBox.Show("Error message: " + erno.Message);
                }

            }
            else if (sender == getGeoButton1)
            {
                NavigationService.Navigate(new Uri("/LocationSelectorPage.xaml?target=Origin", UriKind.Relative));
            }
            else if (sender == getGeoButton2)
            {   
                NavigationService.Navigate(new Uri("/LocationSelectorPage.xaml?target=Destination", UriKind.Relative));
            }
        }
    }
}