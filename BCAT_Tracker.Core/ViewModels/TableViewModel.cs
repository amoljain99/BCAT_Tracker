using BCAT_Tracker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BCAT_Tracker.Core.ViewModels
{
    public class TableViewModel : MvxViewModel
    {
        public List<TableModel> TableModel
        {
            get;
        }

        public TableViewModel()
        {
            TableModel = new List<TableModel>();
            TableModel.Add(new TableModel() { Title = "Dashboard", ImageName = "ic_build_white", Navigate = NavigateHome });
            TableModel.Add(new TableModel() { Title = "View/Edit Supervisors", ImageName = "ic_description_white", Navigate = NavigateOtherViewModel });
            TableModel.Add(new TableModel() { Title = "Set Reminder", ImageName = "ic_settings_white", Navigate = NavigateOtherViewModel });
            TableModel.Add(new TableModel() { Title = "Settings", ImageName = "ic_explore_white", Navigate = NavigateOtherViewModel });
            TableModel.Add(new TableModel() { Title = "Logout", ImageName = "ic_credit_card_white", Navigate = NavigateOtherViewModel });
            TableModel.Add(new TableModel() { Title = "Evolve", ImageName = "ic_device_hub_white", Navigate = NavigateOtherViewModel });

        }

        public ICommand SelectTodoItemCommand
        {
            get
            {
                return new MvxCommand<TableModel>(item => {
                    switch(item.Title)
                    {
                        case "Dashboard":
                            ShowViewModel<CEDetailViewModel>();
                          break;
                        case "View/Edit Supervisors":
                            ShowViewModel<CEDetailViewModel>();
                            break;
                        case "Settings":
                            ShowViewModel<CEDetailViewModel>();
                            break;

                    }
                    //Mvx.Resolve<IDialog>().ShowMessage("Item clicked", item.Title + " clicked");
                });
            }
        }

        private MvxCommand _resetCommand;
        public MvxCommand NavigateHome
        {
            get
            {
                _resetCommand = _resetCommand ?? new MvxCommand(() => ShowViewModel<CEDetailViewModel>());
                return _resetCommand;
            }
        }

        private MvxCommand _navigateOtherViewModel;
        public MvxCommand NavigateOtherViewModel
        {
            get
            {
                _navigateOtherViewModel = _navigateOtherViewModel ?? new MvxCommand(() => ShowViewModel<CEDetailViewModel>());
                return _navigateOtherViewModel;
            }
        } 
    }
}
