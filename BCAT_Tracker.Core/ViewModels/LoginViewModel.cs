using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using BCAT_Tracker.Core.Models;

namespace BCAT_Tracker.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;
        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }
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
                return new MvxCommand(DoSave);
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
