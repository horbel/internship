using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListViewHomeTask
{
    [Activity(Label = "ListViewHomeTask", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        Context context = Application.Context;
        private List<Person> mPersons;
        private ListView mListView;
      

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);                        
            SetContentView(Resource.Layout.Main);       
            Button addBtn = FindViewById<Button>(Resource.Id.addBtn);
            Button deleteBtn = FindViewById<Button>(Resource.Id.deleteBtn);
            mPersons = new List<Person>()
            {
                new Person{FirstName="FName1", LastName="Lname1" },
                new Person{FirstName="FName2", LastName="Lname2" },
                new Person{FirstName="FName3", LastName="Lname3" },
                new Person{FirstName="FName4", LastName="Lname4" },
                new Person{FirstName="FName5", LastName="Lname5" },
                new Person{FirstName="FName6", LastName="Lname6" }

            };
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            
            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            PersonToListViewAdapter adapter = new PersonToListViewAdapter(this, mPersons);
            mListView.Adapter = adapter;

            addBtn.Click += (sender, e) =>
            {
                adapter.AddPerson();               
                RunOnUiThread(() =>
                {
                    adapter.NotifyDataSetChanged();
                });               
            };
            deleteBtn.Click += (sender, e) =>
              {
                  adapter.DeletePerson();
                  RunOnUiThread(() => {
                      adapter.NotifyDataSetChanged();
                  });
              };

            mListView.ItemClick += (sender, e) =>
            {
                Toast.MakeText(this, mPersons[e.Position].FirstName, ToastLength.Short).Show();
            };

            
        }
        
     
    }
}

