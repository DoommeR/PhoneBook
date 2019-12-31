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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
            
            var contact = JsonConvert.DeserializeObject<Contact>(Intent.GetStringExtra("Contact"));
            FindViewById<TextView>(Resource.Id.detail_firstname).Text= contact.name.First;
            FindViewById<TextView>(Resource.Id.detail_lastname).Text = contact.name.Last;
            FindViewById<TextView>(Resource.Id.detail_phone).Text = contact.Phone;
        }
    }
}