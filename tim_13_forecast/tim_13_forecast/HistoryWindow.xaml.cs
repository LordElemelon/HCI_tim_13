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
using tim_13_forecast.models;

namespace tim_13_forecast
{
    public class ServerListItem
    {
        public string City { get; set; }
        public string Degree { get; set; }
        public Image Picture { get; set; }
    }

    public partial class HistoryWindow : Window
    {
        MainWindow mw;

        public HistoryWindow(MainWindow mw)// List<string> temperature
        {
            InitializeComponent();
            this.mw = mw;
            Closing += this.OnWindowClosing;
        }

        public void update(List<string> temperature)//List<string> temperature
        {
            History.Items.Clear();
            int brojac = 0;
            foreach (City city in mw.CitiesHistory)
            {
                ServerListItem item = new ServerListItem
                {
                    City = city.name + "," + city.country,
                    Degree = temperature.ElementAt(brojac),
                };

                History.Items.Add(item);
                brojac++;
            }
            //this.History.Items.Refresh();
        }
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void History_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            ServerListItem temp=History.SelectedItems[0] as ServerListItem;
            mw.setCityToRefresh(temp.City);
        }
    }
}
