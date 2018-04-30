using System;

using UIKit;

namespace BCAT_Tracker.iOS.Views
{
    public partial class CEDetailViewController : UIViewController
    {
        public CEDetailViewController() : base("CEDetailViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

