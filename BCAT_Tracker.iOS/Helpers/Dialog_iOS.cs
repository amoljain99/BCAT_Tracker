using BCAT_Tracker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace BCAT_Tracker.iOS.Helpers
{
    public class Dialog_iOS : IDialog
    {
        public Dialog_iOS()
        {
        }

        public void ShowMessage(string title, string message)
        {
            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            UIViewController rootViewController = UIApplication.SharedApplication.Windows[1].RootViewController;
            UIViewController childViewController = rootViewController.PresentedViewController;

            if (childViewController != null)
            {
                childViewController.PresentViewController(alertController, true, null);

            }
            else
            {
                rootViewController.PresentViewController(alertController, true, null);
            }
        }
    }
}