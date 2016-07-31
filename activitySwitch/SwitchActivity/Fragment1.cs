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
    public class Fragment1 : Fragment
    {
        
        int count = 1;
        string btnText = "count 0";
        public override void OnCreate(Bundle savedInstanceState)
        {
            //count = savedInstanceState.GetInt("counter",1);
            
            base.OnCreate(savedInstanceState);
            this.RetainInstance = true;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Franment1, container, false);
            Button fr1 = view.FindViewById<Button>(Resource.Id.Fr1);
            fr1.Text = btnText;
            fr1.Click += (s, e) => {
                btnText = $"clicks in fr1: {count++}";
                fr1.Text = btnText;
            };
            
            return view;
        }
        //public void setData(int param) {
        //    this.count = param;
        //}
        //public int getData()
        //{
        //    return count;
        //}
        //public override void OnSaveInstanceState(Bundle outState)
        //{
        //    outState.PutInt("c", count);
        //    base.OnSaveInstanceState(outState);
        //}
        //public override void OnActivityCreated(Bundle savedInstanceState)
        //{
        //    base.OnActivityCreated(savedInstanceState);
        //    if (savedInstanceState != null)
        //    {
        //        savedInstanceState.GetInt("c");
        //    }
        //}
    }
}