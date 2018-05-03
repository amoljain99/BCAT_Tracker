using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace BCAT_Tracker.iOS.Views
{
 
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainView, Core.ViewModels.LoginViewModel>();
            //set.Bind(TextField).To(vm => vm.Text);
            //set.Bind(Button).To(vm => vm.ResetTextCommand);
            set.Apply();
        }
    }
}
