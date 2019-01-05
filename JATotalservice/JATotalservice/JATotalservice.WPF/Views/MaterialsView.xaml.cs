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
        public new MaterialsViewModel ViewModel
        {
            get { return (MaterialsViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public MaterialsView()

        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MaterialName.Text = "";
            MaterialPrice.Text = "";
            MaterialDescription.Text = "";
        }

        private void CreateMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material material = new Material { name = MaterialName.Text, price = double.Parse(MaterialPrice.Text), description = MaterialDescription.Text };
            ViewModel.PostMaterial(material);
            Materials.ItemsSource = ViewModel.Materials;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.DeleteMaterial(ViewModel.Material.id);
            Materials.ItemsSource = ViewModel.Materials;
        }

        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            var material = ViewModel.Material;
            material.name = MaterialName.Text;
            
            material.price = double.Parse(MaterialPrice.Text);
            material.description = MaterialDescription.Text;
        
            ViewModel.Edit(material);
            Materials.ItemsSource = ViewModel.Materials;

        }

        private void Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var material = (Material)item.SelectedItem;
            ViewModel.Material = material;
            ViewModel.GetMaterials();
        }
    }
}
