using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAT_Tracker.Core.Models
{
   public class TableModel
    {
        public String Title
        {
            get;
            set;
        }

        public String ImageName
        {
            get;
            set;
        }

        public IMvxCommand Navigate
        {
            get;
            set;
        }

        public TableModel() { }
    }
}
