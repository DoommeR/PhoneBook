using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace PhoneBookHW
{
    [Activity(Label = "ImageZoomActivity")]
    public class ImageZoomActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_zoomImage);

            var url = JsonConvert.DeserializeObject<string>(Intent.GetStringExtra("url"));
            FindViewById<ImageView>(Resource.Id.zoom_img).SetImageBitmap(Utils.GetImageBitmapFromUrl(url));
            
        }
    }
}