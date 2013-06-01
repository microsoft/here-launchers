using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Net;


/// <summary>
/// The PlacesShowDetailsByIdHrefTask allows you to start the Maps application with places view for the selected place. 
/// One of the place Id or the place Href parameters must be defined. 
/// Both of these values can be fetched via Nokia Places APIs, and only values submitted by the Nokia places APIs can be used with them. 
/// </summary>
/// <param name="Id">Nokia Place Id (optionally-required)</param>
/// <param name="Href">Nokia Place Href (optionally-required)</param>
/// <param name="Title">Custom place title</param>
/// 

namespace Nokia.Phone.HereLaunchers
{
    public sealed class PlacesShowDetailsByIdHrefTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Place Href Url strings.
        /// </summary>
        /// <value>
        /// The Place Href Url as a strings 
        /// </value>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the Id string for the place.
        /// </summary>
        /// <value>
        /// The Nokia place Id for the place as string.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Title string for the place.
        /// </summary>
        /// <value>
        /// The Title to be used with the place as string.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Shows Nokia Maps application with the place as set with the attributes
        /// </summary>
        public void Show()
        {
            if ((!string.IsNullOrEmpty(this.Href)) || (!string.IsNullOrEmpty(this.Id)))
            {
                string UrlToUse = "places://v2.0/show/details/?";

                if (!string.IsNullOrEmpty(this.Href))
                {
                    string encodedHref = Uri.EscapeDataString(this.Href);
                    UrlToUse = UrlToUse + "href=" + encodedHref;
                }
                else
                {
                    UrlToUse = UrlToUse + "id=" + this.Id;
                }

                if (!string.IsNullOrEmpty(this.Title))
                {
                    string encodedName = Uri.EscapeDataString(this.Title);
                    UrlToUse = UrlToUse + "&title=" + encodedName;
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set the Place Id or Href for the place before calling Show()");
            }
        }
    }
}