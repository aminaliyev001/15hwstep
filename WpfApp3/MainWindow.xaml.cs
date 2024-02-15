using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
       public void Load()
        {
            var Processes = Process.GetProcesses();
            ListView.Items.Clear();
            foreach (var process in Processes)
            {
                var item = new {Id = process.Id, Name = process.ProcessName, MachineName = Environment.MachineName};
                ListView.Items.Add(item);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var str = textbox1.Text.ToString();
            try
            {
                Process.Start(str);
                Load();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Errorr:{err.Message}");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(ListView.SelectedItem != null)
            {
                ListView.Items.Remove(ListView.SelectedItem);
                Load();
            } else
            {
                MessageBox.Show("hec bir task secilmeyib");
            }
        }
    }
}