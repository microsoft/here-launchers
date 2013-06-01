using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Net;

/// <summary>
/// The PlacesShowDetailsByLocationTask allows you to start the Maps application with places view for the selected place. 
/// In general, places view shows minimap for the selected location, and uses geocoding services for finding the address for the location
/// </summary>
/// <param name="Location">Place coordinate (required)</param>
/// <param name="Title">Custom place title</param>
/// 


namespace Nokia.Phone.HereLaunchers
{
    public sealed class PlacesShowDetailsByLocationTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Location coordinates.
        /// </summary>
        /// <value>
        /// The Location coordinate as GeoCoordinate.
        /// </value>
        public GeoCoordinate Location  { get; set; }

        /// <summary>
        /// Gets or sets the Title string for the place.
        /// </summary>
        /// <value>
        /// The Title string to be used with the place.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Shows Nokia Maps application with the place as set with the attributes
        /// </summary>
        public void Show()
        {
            if (this.Location != null)
            {
                string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "places://v2.0/show/details/?latlon=" + latStr + "," + lonStr;

                if (!string.IsNullOrEmpty(this.Title))
                {
                    string encodedName = Uri.EscapeDataString(this.Title);
                    UrlToUse = UrlToUse + "&title=" + encodedName;
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set an location coordinates for the place before calling Show()");
            }
        }
    }
}

