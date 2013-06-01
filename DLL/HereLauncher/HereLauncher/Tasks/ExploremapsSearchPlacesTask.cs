using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Net;

/// <summary>
/// The ExploremapsSearchPlacesTask allows you to start the Maps application with search view. 
/// The SearchTerm used in the search must be defined alongside with the Location for which the search will be performed.
/// </summary>
/// <param name="Location">Center coordinate for the map-search(required) </param>
/// <param name="SearchTerm">Search query to be performed(required) </param>
/// 


namespace Nokia.Phone.HereLaunchers
{
    public sealed class ExploremapsSearchPlacesTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Location coordinates.
        /// </summary>
        /// <value>
        /// The Location coordinate as GeoCoordinate.
        /// </value>
        public GeoCoordinate Location { get; set; }

        /// <summary>
        /// Gets or sets the SearchTerm term.
        /// </summary>
        /// <value>
        /// The SearchTerm term string.
        /// </value>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Shows Nokia Maps with search for specified search term
        /// If location is not specified, users current location will be used
        /// </summary>
        public void Show()
        {
            if (!string.IsNullOrEmpty(this.SearchTerm))
            {
                string encodedTerm = Uri.EscapeDataString(this.SearchTerm);
                string UrlToUse = "explore-maps://v2.0/search/places/?term=" + encodedTerm;

                if (this.Location != null)
                {
                    string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    UrlToUse = UrlToUse + "&latlon=" + latStr + "," + lonStr;
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set the search term before calling Show()");
            }
        }
    }
}
