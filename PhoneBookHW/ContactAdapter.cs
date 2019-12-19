using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Models;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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

    }
}