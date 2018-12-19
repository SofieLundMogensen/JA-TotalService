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
        }

        //private void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    materialsViewModel.DeleteMaterial(Material.id);
        //}
        private void EditMaterial_Click(object sender, RoutedEventArgs e)
        {
            var mat = materialsViewModel.Material;
            mat.name = MaterialName.Text;
            mat.price = double.Parse(MaterialPrice.Text);
            mat.description = MaterialDescription.Text;
            materialsViewModel.Edit(mat);
        }


        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            MaterialsViewModel materialsViewModel = new MaterialsViewModel();
            var material = materialsViewModel.Material;
            MaterialName.Text = material.name;
            material.price = double.Parse(MaterialPrice.Text);
            MaterialDescription.Text = material.description;
            materialsViewModel.Edit_Click(material);

        }
        
        private void Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var material = (Material)item.SelectedItem;
            materialsViewModel.GetMaterials();
        }
    }
}
