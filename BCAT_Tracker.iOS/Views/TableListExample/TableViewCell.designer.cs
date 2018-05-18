// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace BCAT_Tracker.iOS.Views.TableListExample
{
    [Register ("TableViewCell")]
    partial class TableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelMenuItemName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelMenuItemName != null) {
                LabelMenuItemName.Dispose ();
                LabelMenuItemName = null;
            }
        }
    }
}