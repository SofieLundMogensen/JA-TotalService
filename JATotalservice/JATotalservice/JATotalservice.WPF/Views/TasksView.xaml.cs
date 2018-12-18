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
        TaskViewModel taskViewModel;
        PDFHelper pDFHelper = new PDFHelper();
        public TasksView()
        {
            taskViewModel = new TaskViewModel();
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
                taskViewModel.Task = task;
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
            }
         
        }

        private void PrintFaktura_Click(object sender, RoutedEventArgs e)
        {
            pDFHelper.CreatePDF(taskViewModel.Task);
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
            taskViewModel.PostTask(task);
            PopupCreate.IsOpen = false;
            Tasks.ItemsSource = taskViewModel.Tasks;

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
            var task = taskViewModel.Task;
            task.isComplete = IsDone.IsChecked.Value;
            task.name = TaskName.Text;
            task.description = TaskDescription.Text;
            taskViewModel.Edit(task);
            EditTask.Visibility = Visibility.Hidden;
            IsDone.Visibility = Visibility.Hidden;
            CreateTask.Visibility = Visibility.Visible;
            PopupCreate.IsOpen = false;
            Tasks.ItemsSource = taskViewModel.Tasks;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CreateTask.Visibility = Visibility.Hidden;
            EditTask.Visibility = Visibility.Visible;
            IsDone.Visibility = Visibility.Visible;
            PopupCreate.IsOpen = true;
            var task = taskViewModel.Task;
            IsDone.IsChecked = task.isComplete;
            TaskName.Text = task.name;
            TaskDescription.Text = task.description;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            taskViewModel.delete(taskViewModel.Task.id);
            Tasks.ItemsSource = taskViewModel.Tasks;

            //Optimalt en check på om man vil slette eller ej.
        }
        
    }
}
