// -----------------------------------------------------------------------
// <copyright file="TaskBase.cs" company="Nokia">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Phone.Info;
using Microsoft.Phone.Tasks;

namespace Nokia.Phone.HereLaunchers
{
     /// <summary>
    /// Base class for Nokia Maps/Drive/Public Transit Tasks launchers
    /// </summary>
    public class TaskBase
    {
        /// <summary>
        /// Launches the specified app to app URI 
        /// uses the appToAppUri with Nokia devices, and webFallbackUri with others (when available).
        /// </summary>
        /// <param name="appToAppUri">The app to app URI.</param>
        [SuppressMessage("Microsoft.Security", "CA2140:TransparentMethodsMustNotReferenceCriticalCodeFxCopRule", Justification = "Adding the SecurityCritical attribute was over the top")]
        protected void Launch(Uri appToAppUri)
        {
            if (Environment.OSVersion.Version.Major >= 8)
            {
                string _uri = appToAppUri.OriginalString;
                string _appid = Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId;
                if (_uri.EndsWith("/"))
                    _uri += "?appid=" + _appid;
                else
                    _uri += "&appid=" + _appid;

                Debug.WriteLine("Launching Nokia App with " + _uri);
#pragma warning disable 4014  // Disable as we're launching the app - we don't want to wait
                Windows.System.Launcher.LaunchUriAsync(new Uri(_uri));
#pragma warning restore 4014  // CS4014
                return;
            }
            else
            {
                throw new InvalidOperationException("This API is intented to work only from Windowns Phone 8 and newer");
            }
        }
    }
}
