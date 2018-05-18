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
    [Register ("TableViewController")]
    partial class TableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tbldata { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tbldata != null) {
                tbldata.Dispose ();
                tbldata = null;
            }
        }
    }
}