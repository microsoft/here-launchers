using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FullDemo.Resources;

using Nokia.Phone.HereLaunchers;

namespace FullDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_gridbut_Click(object sender, RoutedEventArgs e)
        {
            if (sender == GuidanceButton)
            {
                NavigationService.Navigate(new Uri("/GuidanceDriveWalkPage.xaml", UriKind.Relative));
            }
            else if (sender == searchButton)
            {
                NavigationService.Navigate(new Uri("/SearchPlacesPage.xaml", UriKind.Relative));
            }
            else if (sender == routeButton1)
            {
                NavigationService.Navigate(new Uri("/DirectionsShowRoutePage.xaml", UriKind.Relative));
            }
            else if (sender == routeButton2)
            {
                NavigationService.Navigate(new Uri("/DirectionsShowRouteToPage.xaml", UriKind.Relative));
            }
            else if (sender == showButton)
            {
                NavigationService.Navigate(new Uri("/ShowMapPage.xaml", UriKind.Relative));
            }
            else if (sender == placeButton)
            {
                NavigationService.Navigate(new Uri("/ShowPlacePage.xaml", UriKind.Relative));
            }
            else if (sender == NearbyButton)
            {
                NavigationService.Navigate(new Uri("/ExplorePlacesPage.xaml", UriKind.Relative));
            }
            else if (sender == NlaceButton)
            {
                NavigationService.Navigate(new Uri("/PlacesShowByIDPage.xaml", UriKind.Relative));
            }
            else if (sender == NLocPlaButton)
            {
                NavigationService.Navigate(new Uri("/PlacesShowByLocationPage.xaml", UriKind.Relative));
            }
            else if (sender == JourneyButton)
            {
                NavigationService.Navigate(new Uri("/PublicTrasportShowJourneys.xaml", UriKind.Relative));
            }
            else if (sender == StopsButton)
            {
                PublicTransitSearchStopsTask taks = new PublicTransitSearchStopsTask();
                // shows nearby based on current location, no data needed.
                taks.Show();
            }
        }
    }
}