using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The PublicTransitSearchStopsTask allows you to start the Public Transit application with the nearby stops view. 
/// </summary>
/// 
namespace Nokia.Phone.HereLaunchers
{
    public sealed  class PublicTransitSearchStopsTask : TaskBase
    {
        /// <summary>
        /// Shows Nokia Public Transit Application with nearby stops based on current location
        /// </summary>
        public void Show()
        {
            string UrlToUse = "public-transit://v2.0/search/stops/";
            this.Launch(new Uri(UrlToUse));
        }
    }
}
