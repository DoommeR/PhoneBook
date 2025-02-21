﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Core;
using API.Models;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;


namespace PhoneBookHW
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<Contact> res;   
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
         
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Core.Init.CoreInit();
            var elem = new ContractElement();

             res = await elem.getContactsList();
            var contactAdapter = new ContactAdapter(res);

            ListView lw = FindViewById<ListView>(Resource.Id.lvMain);
            lw.Adapter = contactAdapter;
            lw.ItemClick += Lw_ItemClick;
            
        }

        private void Lw_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            Intent intent = new Intent(this, typeof(DetailActivity));
            intent.PutExtra("Contact", JsonConvert.SerializeObject(res[e.Position]));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

