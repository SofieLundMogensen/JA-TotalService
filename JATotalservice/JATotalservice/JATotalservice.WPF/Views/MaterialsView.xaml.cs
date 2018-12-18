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
using ModelLayer;


namespace JATotalservice.WPF.Views
{
    /// <summary>
    /// Interaction logic for MaterialsView.xaml
    /// </summary>
   [MvxViewFor(typeof(MaterialsViewModel))]
    public partial class MaterialsView : MvxWpfView
    {
        MaterialsViewModel materialsViewModel;

        public MaterialsView()
        {
            materialsViewModel = new MaterialsViewModel();
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MaterialName.Text = "";
            MaterialPrice.Text = "";
            MaterialDescription.Text = "";
            PopupCreate.IsOpen = true;
        }

        private void CreateMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material material = new Material { name = MaterialName.Text, price = double.Parse(MaterialName.Text), description = MaterialDescription.Text };
            materialsViewModel.PostMaterial(material);
            PopupCreate.IsOpen = false;
        }

        private void AnnullCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateMaterial.Visibility = Visibility.Visible;
            EditMaterial.Visibility = Visibility.Hidden;
            PopupCreate.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    CreateMaterial.Visibility = Visibility.Hidden;
        //    EditMaterial.Visibility = Visibility.Visible;
        //    PopupCreate.IsOpen = true;
        //    var material = materialsViewModel.Materials;
        //    MaterialName.Text = material.name;
        //}

        //private void EditMaterial_Click(object sender, RoutedEventArgs e)
        //{
        //    var mat = materialsViewModel.Materials;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
