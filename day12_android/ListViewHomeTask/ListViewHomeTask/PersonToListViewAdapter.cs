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

namespace ListViewHomeTask
{
    class PersonToListViewAdapter : BaseAdapter<Person>
    {
        private List<Person> mPersons;
        private Context context;



        public void AddPerson()
        {
            Person person = new Person() { FirstName = $"Fname{mPersons.Count+1}", LastName = $"Lname{mPersons.Count+1}" };
            
            mPersons.Add(person);
        }

        public void DeletePerson()
        {
            if (mPersons.Count == 0)
                return;
            mPersons.RemoveAt(mPersons.Count - 1);
        }


        public PersonToListViewAdapter(Context context, List<Person> dataSource)
        {
            mPersons = dataSource;
            this.context = context;
        }
        public override Person this[int position]
        {
            get
            {
                return mPersons[position];
            }
        }

        public override int Count
        {
            get
            {
                return mPersons.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.listView_row, null, false);
            }
            TextView txtFirstName = row.FindViewById<TextView>(Resource.Id.txtFirstName);
            row.FindViewById<TextView>(Resource.Id.txtFirstName).Text = mPersons[position].FirstName;
            TextView txtLastName = row.FindViewById<TextView>(Resource.Id.txtLastName);
            row.FindViewById<TextView>(Resource.Id.txtLastName).Text = mPersons[position].LastName;
            return row;
        }
    }
}