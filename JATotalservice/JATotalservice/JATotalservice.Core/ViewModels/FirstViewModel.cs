using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace JATotalservice.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;





        public IMvxCommand navigateCommand => new MvxAsyncCommand(Some1Method);

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public FirstViewModel()
        {
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public async Task Some1Method()
        {
            await _navigationService.Navigate<MaterialsViewModel>();
        }
        

        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }
    }
}
