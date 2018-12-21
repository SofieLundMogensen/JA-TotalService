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
        }

        private void CreateMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material material = new Material { name = MaterialName.Text, price = double.Parse(MaterialPrice.Text), description = MaterialDescription.Text };
            materialsViewModel.PostMaterial(material);
            Materials.ItemsSource = materialsViewModel.Materials;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            materialsViewModel.DeleteMaterial(materialsViewModel.Material.id);
            Materials.ItemsSource = materialsViewModel.Materials;
        }

        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            var material = materialsViewModel.Material;
            material.name = MaterialName.Text;
            
            material.price = double.Parse(MaterialPrice.Text);
            material.description = MaterialDescription.Text;
        
            materialsViewModel.Edit(material);
            Materials.ItemsSource = materialsViewModel.Materials;

        }

        private void Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var material = (Material)item.SelectedItem;
            materialsViewModel.Material = material;
            materialsViewModel.GetMaterials();
        }
    }
}
