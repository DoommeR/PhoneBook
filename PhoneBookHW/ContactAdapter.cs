using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Models;

using Android.Views;
using Android.Widget;
using System.Net;
using Android.Graphics;

namespace PhoneBookHW
{
    class ContactAdapter : BaseAdapter<Contact>
    {

        protected IList<Contact> _contacts;

        public ContactAdapter(IList<Contact> contacts)
        {
            _contacts = contacts;
        }

        public override Contact this[int position]
        {
            get
            {
                return _contacts[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.contact_row, parent, false);
            //view.FindViewById<ImageView>(Resource.Id.contact_row__icon).SetImageDrawable(LoadImageFromWebOperations(thi[position].picture.thumbnail));
            //view.FindViewById<ImageView>(Resource.Id.contact_row__icon).SetImageURI(Android.Net.Uri.Parse(this[position].picture.thumbnail));
            view.FindViewById<ImageView>(Resource.Id.contact_row__icon).SetImageBitmap(GetImageBitmapFromUrl(this[position].picture.thumbnail));
            view.FindViewById<TextView> (Resource.Id.contact_row_phone).Text =this[position].Phone;
            view.FindViewById<TextView>(Resource.Id.contact_row_name).Text = this[position].name.First;

            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return _contacts.Count();
            }
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}