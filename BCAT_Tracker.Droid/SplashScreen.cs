using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace BCAT_Tracker.Droid
{
    [Activity(
        Label = "BCAT_Tracker.Droid"
        , MainLauncher = true
        
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
