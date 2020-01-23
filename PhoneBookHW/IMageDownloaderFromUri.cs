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
        public Uri Uri { get; set; }
        public static ImageView ImageView { get; set; }
        
        public ImageDownloaderFromUri(string uri,ImageView imageView) {
            Uri = new Uri(uri);
            ImageView = imageView;
        }

        public void SetImageFromUrlTask() {
            //ThreadPool.QueueUserWorkItem(o => SetImageBitmapFromUrl());
            SetImageFromUrlTask();
        }
        private void SetImageBitmapFromUrl()
        {
            //ServiceManager.Resolve<WebClient>()
            //using (var webClient = ServiceManager.Resolve<WebClient>())
            //{


            //    webClient.DownloadDataCompleted += WebClient_DownloadDataCompleted;
            //    webClient.DownloadDataAsync(Uri);
            //    //while (webClient.IsBusy) { Thread.Sleep(100); };
            //}
            AsyncHttpClient client = new AsyncHttpClient();
            client.get(image_url, null, new AsyncHttpResponseHandler() {

    public void onSuccess(byte[] fileData)
            {
                Bitmap image = BitmapFactory.decodeByteArray(fileData, 0, fileData.length);
                //Do whatever you want with the image variable    
            }
        });
        }

        private static void WebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            byte[] raw = e.Result;
            Bitmap image = null;
            if (raw != null && raw.Length > 0)
            {
                image = BitmapFactory.DecodeByteArray(raw, 0, raw.Length);
                ImageView.SetImageBitmap(image);
            }
        }
    }

    
}