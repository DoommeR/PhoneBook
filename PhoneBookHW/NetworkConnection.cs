using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.Interfaces;

namespace PhoneBookHW
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }


        public void CheckNetworkConnection() {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;

            IsConnected = 
            if (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting) { 
            
            }

        }
    }
}