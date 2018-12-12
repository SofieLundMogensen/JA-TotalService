using JATotalservice.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JATotalservice.WPF.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [MvxViewFor(typeof(FirstViewModel))]
    public partial class FirstView : MvxWpfView
    {
        public FirstView()
        {
            InitializeComponent();
        }
    }
}
