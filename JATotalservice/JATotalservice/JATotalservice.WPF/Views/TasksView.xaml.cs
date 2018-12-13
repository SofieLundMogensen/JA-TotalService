using JATotalservice.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace JATotalservice.WPF.Views
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>

    [MvxViewFor(typeof(TaskViewModel))]
    public partial class TasksView : MvxWpfView
    {
        TaskViewModel taskViewModel;
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
             var task =   (ModelLayer.Task)itme.SelectedItem;
            taskViewModel.Task = task;
            Name.Content = task.name;
            Description.Content = task.description;
            double timeused = 0;
            foreach (var item in task.timeRegistrations)
            {
               double time = item.endTime.Hour - item.startTime.Hour;
                timeused =  time + timeused;
            }
            Time.Content = timeused;
            Materials.ItemsSource = task.materials;
            Console.WriteLine("Wuo wup");
        }

        private void PrintFaktura_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("-----------------------Hej med dig, jeg er mega sej-----------------");
            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 42, 35);
            PdfWriter w = PdfWriter.GetInstance(doc, new FileStream("File.pdf", FileMode.Create));

            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Det her pdf generering virker bare");
            doc.Open();
            doc.AddAuthor("Dennis");
            doc.AddCreator("Visual Studio");
            doc.AddSubject("PDF File");
            doc.AddTitle("Title");
            doc.Add(p);
            doc.Add(p);
            doc.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = true;
        }
    }
}
