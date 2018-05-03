using MvvmCross.Base;
using System.Collections.Generic;

namespace BCAT_Tracker.Core.Models
{
    public interface IDataService
    {
        void Save(Logins item); 
        Logins Load();
    }

    public interface IMvxTextSerializers : IMvxTextSerializer
    { }
}