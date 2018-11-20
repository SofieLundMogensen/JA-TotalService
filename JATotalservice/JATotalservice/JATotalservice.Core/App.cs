using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.IoC;
using MvvmCross;

namespace JATotalservice.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Client")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            // register the appstart object
            RegisterCustomAppStart<AppStart>();
        }
    }
}