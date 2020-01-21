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
using API.Models;
using Newtonsoft.Json;

namespace PhoneBookHW
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        Contact contact;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
            
            contact = JsonConvert.DeserializeObject<Contact>(Intent.GetStringExtra("Contact"));

            var img = FindViewById<ImageView>(Resource.Id.detail_icon);
            ImageDownloaderFromUri.SetImageFromUrlTask(contact.picture.medium, img);
            img.Click += Img_Click;

            FindViewById<TextView>(Resource.Id.detail_firstname).Text= contact.name.First;
            FindViewById<TextView>(Resource.Id.detail_lastname).Text = contact.name.Last;
            FindViewById<TextView>(Resource.Id.detail_phone).Text = contact.Phone;
        }

        private void Img_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ImageZoomActivity));
            intent.PutExtra("url", JsonConvert.SerializeObject(contact.picture.large));
            StartActivity(intent);
        }
    }
}