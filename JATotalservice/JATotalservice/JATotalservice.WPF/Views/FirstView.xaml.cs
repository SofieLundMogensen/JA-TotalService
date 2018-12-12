

using JATotalservice.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace JATotalservice.WPF.Views
{
    [MvxViewFor(typeof(FirstViewModel))]
    public partial class FirstView : MvxWpfView
    {
        public FirstView()
        {
           
            this.InitializeComponent();
        }
    }
}
