using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SwitchActivity
{
    public class Fragment2 : Fragment
    {
        int count = 1;        
        string btnText = "count 0";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);
            Button fr2 = view.FindViewById<Button>(Resource.Id.Fr2);
            fr2.Text = btnText;
            fr2.Click += (s, e) => {
                btnText = $"clicks in fr1: {count++}";
                fr2.Text = btnText;
            };
            return view;
        }
    }
}