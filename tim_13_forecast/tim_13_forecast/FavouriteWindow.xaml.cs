using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace tim_13_forecast
{
    /// <summary>
    /// Interaction logic for FavouriteWindow.xaml
    /// </summary>
    public partial class FavouriteWindow : Window
    {
        private readonly MainWindow _owner;
        
        
        public FavouriteWindow(MainWindow owner)
        {
            InitializeComponent();
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;
            listView.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\fav.jpg")));
            _owner = owner;
            Closing += this.OnWindowClosing;


        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

           
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                this._owner.favouriteNO.Visibility = Visibility.Hidden;
                this._owner.favouriteYES.Visibility = Visibility.Visible;
                this._owner.cityToRefresh = (string)item;
                _owner.setupTimer();

            }
            else
            {
                this._owner.favouriteNO.Visibility = Visibility.Visible;
                this._owner.favouriteYES.Visibility = Visibility.Hidden;
            }

        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        [ValueConversion(typeof(double), typeof(double))]
        public class WidthFourConverter : IValueConverter
        {
            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((double)value) * 0.25;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((double)value) / 0.25;
            }

            #endregion
        }

        [ValueConversion(typeof(double), typeof(double))]
        public class HeightConverter : IValueConverter
        {
            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((double)value - 50.0) * 0.10;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((double)value) / 0.10 + 50.0;
            }

            #endregion
        }
    }
}
