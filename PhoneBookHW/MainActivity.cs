using Android.App;
using Android.OS;
using Android.Runtime;
using API.Interfaces;
using API.Services;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using Core;
using API.Models;
using System.Collections.Generic;
using Android.Util;

namespace PhoneBookHW
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Core.Init.CoreInit();
            var elem = new ContractElement();

            var res = await elem.getContactsList();
            var contactAdapter = new ContactAdapter(res);


            /*
            var element = new ContractElement();
            var list = await element.getContactsList();

            string[] lel = { "kek", "shmek" };
    
            ListView lw = FindViewById<ListView>(Resource.Id.lvMain);
            var ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.content_main,Resource.Id.lvMain, lel);
            lw.SetAdapter(ListAdapter);
            */
            ListView lw = FindViewById<ListView>(Resource.Id.lvMain);
            lw.Adapter = contactAdapter;
            
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

