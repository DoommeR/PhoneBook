using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core;

namespace PhoneBookHW
{
    class ImageDownloaderFromUri
    {
        public string Uri { get; set}
        public Bitmap imageBitmap { get; private set; }

        public void SetImageFromUrlTask() {
            ThreadPool.QueueUserWorkItem(o => SetImageBitmapFromUrl(Uri, ImageView));
        }
        private void SetImageBitmapFromUrl(string url,ImageView view)
        {
            imageBitmap = null;

            using (var webClient = ServiceManager.Resolve<WebClient>())
            {

                webClient.DownloadDataAsync(url);
                webClient.DownloadDataCompleted += WebClient_DownloadDataCompleted;
                //var imageBytes = webClient.DownloadDataAsync(url);
                /*if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    view.SetImageBitmap(imageBitmap);
                }
                */
            }
        }

        private static void WebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            
        }

        private void DownloadCompleted() { 
        
        }
    }

    
}