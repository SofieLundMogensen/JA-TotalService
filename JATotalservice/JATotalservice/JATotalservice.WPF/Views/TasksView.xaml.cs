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
using JATotalservice.WPF.Helpers;

namespace JATotalservice.WPF.Views
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>

    [MvxViewFor(typeof(TaskViewModel))]
    public partial class TasksView : MvxWpfView
    {
      
        PDFHelper pDFHelper = new PDFHelper();
        public new TaskViewModel ViewModel
        {
            get { return (TaskViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public TasksView()

        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, MouseButtonEventArgs e)
        {

        }

        private void Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itme = (ListBox)sender;
            var task = (ModelLayer.Task)itme.SelectedItem;
            if (task != null)
            {
                ViewModel.Task = task;
                Name.Content = task.name;
                Description.Content = task.description;
                double timeused = 0;
                if (task.timeRegistrations != null)
                {
                    foreach (var item in task.timeRegistrations)
                    {
                        double time = item.endTime.Hour - item.startTime.Hour;
                        timeused = time + timeused;
                    }
                }
                Time.Content = timeused;
                if (task.materials != null)
                {
                    Materials.ItemsSource = task.materials;
                }
                if (task.timeRegistrations != null)
                {
                    Timeregistration.ItemsSource = task.timeRegistrations;
                }
            }

        }

        private void PrintFaktura_Click(object sender, RoutedEventArgs e)
        {
            pDFHelper.CreatePDF(ViewModel.Task);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            TaskName.Text = "";
            TaskDescription.Text = "";
            PopupCreate.IsOpen = true;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {

            ModelLayer.Task task = new ModelLayer.Task { name = TaskName.Text, description = TaskDescription.Text };
            ViewModel.PostTask(task);
            PopupCreate.IsOpen = false;
            Tasks.ItemsSource = ViewModel.Tasks;

        }

        private void AnnullCreate_Click(object sender, RoutedEventArgs e)
        {
            EditTask.Visibility = Visibility.Hidden;
            IsDone.Visibility = Visibility.Hidden;
            CreateTask.Visibility = Visibility.Visible;
            PopupCreate.IsOpen = false;
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            var task = ViewModel.Task;
            task.isComplete = IsDone.IsChecked.Value;
            task.name = TaskName.Text;
            task.description = TaskDescription.Text;
            ViewModel.Edit(task);
            EditTask.Visibility = Visibility.Hidden;
            IsDone.Visibility = Visibility.Hidden;
            CreateTask.Visibility = Visibility.Visible;
            PopupCreate.IsOpen = false;
            Tasks.ItemsSource = ViewModel.Tasks;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CreateTask.Visibility = Visibility.Hidden;
            EditTask.Visibility = Visibility.Visible;
            IsDone.Visibility = Visibility.Visible;
            PopupCreate.IsOpen = true;
            var task = ViewModel.Task;
            IsDone.IsChecked = task.isComplete;
            TaskName.Text = task.name;
            TaskDescription.Text = task.description;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Er du sikker på du vil slette?", "Slette bekræftelse", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ViewModel.delete(ViewModel.Task.id);
                Tasks.ItemsSource = ViewModel.Tasks;
            }
           
        }

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            Amount.Text = null;
            MaterialsAmount.SelectedItem = null;
            PopupMaterial.IsOpen = true;
        }

        private void MaterialAccept_Click(object sender, RoutedEventArgs e)
        {
            var task = ViewModel.Task;
            var m = MaterialsAmount.SelectedItem;
            task.materials.Add(Tuple.Create((Material)m, Int32.Parse(Amount.Text)));
            ViewModel.addMaterial(task);
            Tasks.ItemsSource = ViewModel.Tasks;
            if (task.materials != null)
            {
                Materials.ItemsSource = ViewModel.Tasks.Find(v => v.id == task.id).materials;
            }

            PopupMaterial.IsOpen = false;
        }

        private void MaterialCancell_Click(object sender, RoutedEventArgs e)
        {
            MaterialsAmount.SelectedItem = null;
            Amount.Text = null;
            PopupMaterial.IsOpen = false;
        }

        private void EditMaterial_Click(object sender, RoutedEventArgs e)
        {
            MaterialEdit.Visibility = Visibility.Visible;
            PopupMaterial.IsOpen = true;
            Tuple<Material, int> test = Materials.SelectedItem as Tuple<Material, int>;
            // MaterialsAmount.SelectedItem = (Material)test.Item1;
            Amount.Text = test.Item2.ToString();

        }

        private void MaterialEdit_Click(object sender, RoutedEventArgs e)
        {
            Tuple<Material, int> old = Materials.SelectedItem as Tuple<Material, int>;
            var m = MaterialsAmount.SelectedItem;

            var t = Tuple.Create((Material)m, Int32.Parse(Amount.Text));
            ViewModel.editMaterial(t, old);

            var task = ViewModel.Task;
            Tasks.ItemsSource = ViewModel.Tasks;
            PopupMaterial.IsOpen = false;
            if (task.materials != null)
            {
                Materials.ItemsSource = task.materials;
            }
            MaterialEdit.Visibility = Visibility.Hidden;
        }

        private void DeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Er du sikker på du vil slette?", "Slette bekræftelse", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ViewModel.deleteMaterial(Materials.SelectedItem as Tuple<Material, int>);
                var task = ViewModel.Task;
                Tasks.ItemsSource = ViewModel.Tasks;
                if (task.materials != null)
                {
                    Materials.ItemsSource = ViewModel.Tasks.Find(m => m.id == task.id).materials;
                }
            }
        }

        private void AddTime_Click(object sender, RoutedEventArgs e)
        {
            StartTime.Text = "";
            EndTime.Text = "";
            PopupTime.IsOpen = true;
        }

        private void TimeAccept_Click(object sender, RoutedEventArgs e)
        {
            string iDate = StartTime.Text;
            DateTime oDate = Convert.ToDateTime(iDate);

            string iEndDate = EndTime.Text;
            DateTime oEndDate = Convert.ToDateTime(iEndDate);
            ViewModel.addTime(oDate, oEndDate);
            PopupTime.IsOpen = false;

            Tasks.ItemsSource = ViewModel.Tasks;
            Timeregistration.ItemsSource = null;
            Timeregistration.ItemsSource = ViewModel.Task.timeRegistrations;
        }

        private void TimeCancell_Click(object sender, RoutedEventArgs e)
        {
            StartTime.Text = "";
            EndTime.Text = "";
            PopupTime.IsOpen = false;
            TimeEdit.Visibility = Visibility.Hidden;
        }

        private void TimeEdit_Click(object sender, RoutedEventArgs e)
        {
           
            string iDate = StartTime.Text;
            DateTime oDate = Convert.ToDateTime(iDate);
            string iEndDate = EndTime.Text;
            DateTime oEndDate = Convert.ToDateTime(iEndDate);
            var t = (TimeRegistartion)Timeregistration.SelectedItem;
            ViewModel.editTime(t, oDate, oEndDate);
            PopupTime.IsOpen = false;
            Tasks.ItemsSource = ViewModel.Tasks;
           
            PopupTime.IsOpen = false;
            TimeEdit.Visibility = Visibility.Hidden;
            Timeregistration.ItemsSource = null;
            Timeregistration.ItemsSource = ViewModel.Task.timeRegistrations;
        }

        private void EditTime_Click(object sender, RoutedEventArgs e)
        {
            var t = (TimeRegistartion)Timeregistration.SelectedItem;
            StartTime.Text = t.startTime.ToString();
            EndTime.Text = t.endTime.ToString();
            TimeEdit.Visibility = Visibility.Visible;
            PopupTime.IsOpen = true;
        }

        private void Deletetime_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Er du sikker på du vil slette?", "Slette bekræftelse", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var t = (TimeRegistartion)Timeregistration.SelectedItem;
                ViewModel.deleteTime(t);
                Tasks.ItemsSource = ViewModel.Tasks;
                Timeregistration.ItemsSource = null;
                Timeregistration.ItemsSource = ViewModel.Task.timeRegistrations;
            }
        }
    }
}
