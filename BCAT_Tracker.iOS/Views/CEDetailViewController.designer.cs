// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BCAT_Tracker.iOS.Views
{
    [Register ("CEDetailViewController")]
    partial class CEDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLoadService { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLoadService != null) {
                btnLoadService.Dispose ();
                btnLoadService = null;
            }
        }
    }
}