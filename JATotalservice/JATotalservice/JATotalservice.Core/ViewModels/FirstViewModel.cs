using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace JATotalservice.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        public async Task Initialize()
        {
            await base.Initialize();
        }

        public async Task Some1Method()
        {
            await _navigationService.Navigate<MaterialsViewModel>();
        }

        public void ttt()
        {

        }

        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }
    }
}
