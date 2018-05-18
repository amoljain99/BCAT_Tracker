using BCAT_Tracker.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace BCAT_Tracker.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<TableViewModel>();
        }
    }
}
