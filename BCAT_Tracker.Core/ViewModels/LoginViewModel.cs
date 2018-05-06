using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using BCAT_Tracker.Core.Models;
using System.Windows.Input;

namespace BCAT_Tracker.Core 
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;

        public LoginViewModel(IDataService dataService)
        {
            this._dataService = dataService; 
        } 

        private string _Password; 

        public string Password
        {
            get { return this._Password; }
            set { this.RaiseAndSetIfChanged(ref this._Password, value); }
        }

        private string _UserName;

        public string UserName
        {
            get { return this._UserName; }
            set { this.RaiseAndSetIfChanged(ref this._UserName, value); }
        }

        private string _Name;

        public string Name
        {
            get { return this._Name; }
            set { this.RaiseAndSetIfChanged(ref this._Name, value); }
        }

        public MvxCommand Save
        {
            get
            {
               return   new MvxCommand(DoSave); 
            }
        }


        public ICommand NavigateToSecondPageCommand
        {
            get
            {
                return new MvxCommand(() => {
                    ShowViewModel<CEDetailViewModel>();
                });
            }
        }


        public MvxCommand Load
        {
            get
            {
                return new MvxCommand(DoLoad);
            }
        }

        void DoSave()
        {
            this._dataService.Save(new Logins { UserName = this.UserName });
        }

        void DoLoad()
        {
            this.UserName = this._dataService.Load()?.UserName ?? "no value";
        }
    }
}
