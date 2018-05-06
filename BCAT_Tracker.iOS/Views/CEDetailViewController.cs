using BCAT_Tracker.Core;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views; 
namespace BCAT_Tracker.iOS.Views
{
    public partial class CEDetailViewController : MvxViewController<CEDetailViewModel>
    {
        public CEDetailViewController() : base("CEDetailViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            try
            {


                base.ViewDidLoad();
                var set = this.CreateBindingSet<CEDetailViewController,  CEDetailViewModel>();
                set.Bind(btnLoadService).To(vm => vm.ServiceCall);
                set.Apply();
            }
            catch(System.Exception ex)
            {
               var list =  ex.InnerException;
            }

            // Perform any additional setup after loading the view, typically from a nib.
        } 
    }
}

