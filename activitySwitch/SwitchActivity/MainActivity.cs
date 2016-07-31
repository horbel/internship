using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SwitchActivity
{
    [Activity(Label = "SwitchActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private Fragment mFrag1, mFrag2;
      
      

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button b2 = FindViewById<Button>(Resource.Id.button1);
            //Button myButton = FindViewById<Button>(Resource.Id.)

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            button.Click += (sender, args) => StartActivity(typeof(Activity2));
            bool flag = true;  //for switch between frags
            mFrag2 = new Fragment2();
            b2.Click += (s, e) =>
            {
                FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
                if (flag)
                {        
                    fragmentTx.Replace(Resource.Id.fragmentContainer, mFrag2, "frag2");
                    flag = !flag;                  
                }
                else
                {
                    fragmentTx.Replace(Resource.Id.fragmentContainer, mFrag1, "frag1");
                    flag = !flag;
                }
                fragmentTx.AddToBackStack(null);
                fragmentTx.Commit();

            };
            var fragCheck1 = FragmentManager.FindFragmentByTag("frag1");
            //var fragCheck1 = FragmentManager.FindFragmentById(Resource.Id.Fr1);
            if (fragCheck1!=null)
            {
                mFrag1 = fragCheck1 as Fragment1;
            }
            else
            {
                FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
                mFrag1 = new Fragment1();
                fragmentTx.Add(Resource.Id.fragmentContainer, mFrag1, "frag1");
                fragmentTx.AddToBackStack(null);
                fragmentTx.Commit();

            }            
           
        }
   
    }

}

