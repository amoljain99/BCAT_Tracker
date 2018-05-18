using BCAT_Tracker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using System;

using UIKit;

namespace BCAT_Tracker.iOS.Views.TableListExample
{
    public partial class TableViewController : MvxViewController
    {
        public TableViewController() : base("TableViewController", null)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var source = new MvxSimpleTableViewSource(tbldata, TableViewCell.Key, TableViewCell.Key);
            tbldata.Source = source;

            var set = this.CreateBindingSet<TableViewController, TableViewModel>();
            set.Bind(source).To(vm => vm.TableModel);
            set.Bind(source).For(vm => vm.SelectionChangedCommand).To(vm => vm.SelectTodoItemCommand);
            //set.Bind(source);//.To(item => item.TableModel).For(s => s.SelectionChangedCommand).To(vm => vm.NavigateOtherViewModel);
            set.Apply();
            tbldata.ReloadData();

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }


    }
}