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

        public IMvxCommand NavigateToTimeRegistrationCommand => new MvxAsyncCommand(NavigateToTimeRegistration);
        public IMvxCommand NavigateToEstimatePriceCommand => new MvxAsyncCommand(NavigateToEstimatePrice);
        public IMvxCommand NavigateToMaterialsCommand => new MvxAsyncCommand(NavigateToMaterials);
        public IMvxCommand NavigateToTasksCommand => new MvxAsyncCommand(NavigateToTasks);

 

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

        public async Task NavigateToTimeRegistration()
        {
            await _navigationService.Navigate<TimeViewModel>();
        }

        public async Task NavigateToMaterials()
        {
            await _navigationService.Navigate<MaterialsViewModel>();
        }
        
        public async Task NavigateToEstimatePrice()
        {
            await _navigationService.Navigate<EstimateViewModel>();
        }
        public async Task NavigateToTasks()
        {
            await _navigationService.Navigate<TaskViewModel>();
        }



        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }
    }
}
