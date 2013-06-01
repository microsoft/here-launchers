using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Collections.Generic;


/// <summary>
/// The ExploremapsExplorePlacesTask allows you to start the Maps application where nearby places of interest are shown. 
/// </summary>
/// <param name="Center">coordinate for the map</param>
/// <param name="Category">list of categories to limit which categories are shown in the map</param>
/// 

namespace Nokia.Phone.HereLaunchers
{
    public sealed class ExploremapsExplorePlacesTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Location coordinates.
        /// </summary>
        /// <value>
        /// The Location coordinate as GeoCoordinate.
        /// </value>
        public GeoCoordinate Location  { get; set; }

        /// <summary>
        /// Gets the Category list.
        /// </summary>
        /// <value>
        /// The Category  string.
        /// </value>
        public List<string> Category  { get; set; }

        /// <summary>
        ///   Initializes a new instance of the ExploremapsExplorePlacesTask class
        /// </summary>
        public ExploremapsExplorePlacesTask()
            : base()
        {
            Category = new List<string>();
        }

        /// <summary>
        /// Shows Nokia Maps application with places for selected coordinate
        /// if no coordinate is selected, then user current location is used as location
        /// </summary> 
        public void Show()
        {
           string UrlToUse = "explore-maps://v2.0/explore/places/";

           if (this.Category != null && (this.Category.Count > 0))
            {
                UrlToUse = UrlToUse + "?category=" + this.Category[0];
                if (this.Category.Count > 1)
                {
                    for (int i = 1; i < this.Category.Count; i++)
                    {
                        UrlToUse = UrlToUse + "," + Uri.EscapeDataString(this.Category[i]);
                    }
                }

                if (this.Location != null)
                {
                    string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    UrlToUse = UrlToUse + "&latlon=" + latStr + "," + lonStr;
                }
            }
           else if (this.Location != null)
            {
                string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                UrlToUse = UrlToUse + "?latlon=" + latStr + "," + lonStr;
            }

           this.Launch(new Uri(UrlToUse));//no fallback available
        }
    }
}