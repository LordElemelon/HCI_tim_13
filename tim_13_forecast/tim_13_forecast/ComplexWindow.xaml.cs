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
using System.Windows.Shapes;
using System.IO;
using System.Reflection;

namespace tim_13_forecast
{
    /// <summary>
    /// Interaction logic for ComplexWindow.xaml
    /// </summary>
    public partial class ComplexWindow : Window
    {
        public ComplexWindow()
        {
            InitializeComponent();
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;
            this.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\complex.jpg")));
            Closing += this.OnWindowClosing;
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
