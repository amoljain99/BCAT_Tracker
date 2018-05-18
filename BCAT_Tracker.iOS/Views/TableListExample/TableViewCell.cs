using System;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using UIKit;
using MvvmCross.Binding.BindingContext;
using BCAT_Tracker.Core.Models;

namespace BCAT_Tracker.iOS.Views.TableListExample
{
    public partial class TableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TableViewCell");
        public static readonly UINib Nib;

        static TableViewCell()
        {
            Nib = UINib.FromName("TableViewCell", NSBundle.MainBundle);
        }

        protected TableViewCell(IntPtr handle) : base(handle)
        {

            this.DelayBind(() => {
                var set = this.CreateBindingSet<TableViewCell, TableModel>();
                set.Bind(LabelMenuItemName).To(item => item.Title);
                set.Apply();
            });
            
        }

    }
}
