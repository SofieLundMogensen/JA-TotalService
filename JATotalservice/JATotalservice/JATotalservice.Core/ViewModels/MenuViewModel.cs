using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowTimeCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TimeViewModel>());
            ShowEstimatedCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<EstimateViewModel>());
            ShowMaterialsCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MaterialsViewModel>());
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowMaterialsCommand { get; private set; }
        public IMvxCommand ShowTimeCommand { get; private set; }
        public IMvxCommand ShowEstimatedCommand { get; private set; }

        // Private methods
    }
}
