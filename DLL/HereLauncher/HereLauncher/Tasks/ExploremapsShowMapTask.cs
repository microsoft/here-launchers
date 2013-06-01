using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;


/// <summary>
/// The ExploremapsShowMapTask allows you to start the Maps application with map centered to the specified location. 
/// The location for the map must be defined by either using the ViewPort or the Location argument.
/// </summary>
/// <param name="ViewPort">Viewport of the map(optionally-required)</param>
/// <param name="Location">Center coordinate for the map view.(optionally-required)</param>
/// <param name="Zoom">Zoom level for the map view. Allowed values from 1.0 to 20.</param>
/// 

namespace Nokia.Phone.HereLaunchers
{
    public sealed class ExploremapsShowMapTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the bounding box for the map to be shown.
        /// </summary>
        /// <value>
        /// LocationRectangle specifying the bounding box of the map.
        /// </value>
        public LocationRectangle ViewPort { get; set; }

        /// <summary>
        /// Gets or sets the Location coordinates.
        /// </summary>
        /// <value>
        /// The Location coordinate as GeoCoordinate.
        /// </value>
        public GeoCoordinate Location { get; set; }

        /// <summary>
        /// Gets or sets the zoom level value.
        /// </summary>
        /// <value>
        /// The zoom level value. Only used with Location, and ignored with viewport.
        /// </value>
        public double Zoom { get; set; }

        /// <summary>
        /// Shows Nokia Maps application
        /// </summary> 
        public void Show()
        {
            if (this.Location != null)
            {
                string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "explore-maps://v2.0/show/map/?latlon=" + latStr + "," + lonStr;

                if (this.Zoom > 1 && this.Zoom < 21)
                {
                    string zoomStr = this.Zoom.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    UrlToUse = UrlToUse + "&zoom=" + zoomStr;
                }

                this.Launch(new Uri(UrlToUse));
            }
            else if (this.ViewPort != null)
            {
                string NElatStr = this.ViewPort.Northeast.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string NElonStr = this.ViewPort.Northeast.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string SWlatStr = this.ViewPort.Southwest.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string SWlonStr = this.ViewPort.Southwest.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "explore-maps://v2.0/show/map/?viewport=" + NElatStr + "," + NElonStr + "," + SWlatStr + "," + SWlonStr;
                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set an location/viewport coordinates before calling Show()");
            }
        }
    }
}
