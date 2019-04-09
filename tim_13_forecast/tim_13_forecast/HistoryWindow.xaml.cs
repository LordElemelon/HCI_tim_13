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

        public HistoryWindow(List<City> CitiesHistory, MainWindow mw, List<string> temperature, List<Image> slike)
        {
            InitializeComponent();
            this.mw = mw;

            History.Items.Clear();
            int brojac = 0;
            foreach (City city in CitiesHistory)
            {
                ServerListItem item = new ServerListItem
                {
                    City = city.name + "," + city.country,
                    Degree = temperature.ElementAt(brojac),
                    Picture = slike.ElementAt(brojac)
                };

                History.Items.Add(item);
                brojac++;
            }
        }

        private void History_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            mw.setCityToRefresh(History.SelectedValue.ToString());
        }
    }
}
