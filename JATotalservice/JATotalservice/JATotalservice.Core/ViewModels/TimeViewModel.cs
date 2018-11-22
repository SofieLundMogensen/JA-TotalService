using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JATotalservice.Core.ViewModels
{
    public class TimeViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        string testString = "Du er i TimeView'et";
        public IMvxCommand navigateCommand => new MvxAsyncCommand(PostTimeRegistration);
        public string TestString
        {
            get { return testString; }
            set { SetProperty(ref testString, value); }
        }



        public TimeViewModel()
        {
            
        }

        public async Task PostTimeRegistration()
        {


            await _navigationService.Navigate<MaterialsViewModel>();
        }


    }
}
