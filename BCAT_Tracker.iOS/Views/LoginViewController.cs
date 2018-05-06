using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace BCAT_Tracker.iOS
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class LoginViewController : MvxViewController
    {
        public LoginViewController() : base("LoginViewController", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<LoginViewController, Core.LoginViewModel>();
            set.Bind(txtUserName).To(vm => vm.UserName);
            set.Bind(txtPassword).To(vm => vm.Password);
            set.Bind(btnSubmit).To(vm => vm.NavigateToSecondPageCommand);
            set.Bind(imgLogo).To(vm => vm.Load);
            set.Apply();    
        }  
    }
}

