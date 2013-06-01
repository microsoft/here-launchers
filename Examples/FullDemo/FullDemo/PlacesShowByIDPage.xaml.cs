using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Nokia.Phone.HereLaunchers;

namespace FullDemo
{
    public partial class PlacesShowByIDPage : PhoneApplicationPage
    {
        public PlacesShowByIDPage()
        {
            InitializeComponent();
        }
        private void Button_gridbut_Click(object sender, RoutedEventArgs e)
        {
            if (sender == LaunchButton)
            {
                try
                {
                    PlacesShowDetailsByIdHrefTask placeTask = new PlacesShowDetailsByIdHrefTask();
                    placeTask.Id = idBox.Text;
                    placeTask.Title = StringBox.Text;
                    placeTask.Show();
                }
                catch (Exception erno)
                {
                    MessageBox.Show("Error message: " + erno.Message);
                }

            }

        }
    }
}