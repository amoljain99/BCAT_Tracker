using Android.App;
using Android.OS;
using Android.Widget;
using BCAT_Tracker.Core;
using BCATTracker.Helper.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using System;

namespace BCAT_Tracker.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity
    {
        public new CEDetailViewModel ViewModel
        {
            get { return (CEDetailViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var bindingSet = this.CreateBindingSet<MainView, CEDetailViewModel>(); 
            bindingSet.Apply();

            Button btn = this.FindViewById<Button>(Resource.Id.btnservice);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
           

        }
       
        
    }


}
