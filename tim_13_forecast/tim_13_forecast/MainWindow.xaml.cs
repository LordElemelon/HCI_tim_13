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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using tim_13_forecast.models;

namespace tim_13_forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        static string apiFiveDayUrl = "data/2.5/forecast?q=";
        static string apiCurrentUrl = "data/2.5/weather?q=";
        static string apiAppId = "&appid=f2dc7da9486c3f883a8caa8329c8b11d";

        static async Task<CurrentForecast> GetCurrentAsync(string path)
        {
            CurrentForecast product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // OTKOMENTARISATI KADA SE NAPRAVI KLASA CurrentForecast
                //product = await response.Content.ReadAsAsync<CurrentForecast>();
                string yeet = await response.Content.ReadAsStringAsync();
                Console.WriteLine(yeet);
            }
            return product;
        }

        static async Task<FiveDayForecast> GetFiveDayAsync(string path)
        {
            FiveDayForecast product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // OTKOMENTARISATI KADA SE NAPRAVI KLASA CurrentForecast
                //product = await response.Content.ReadAsAsync<FiveDayForecast>();
                string yeet = await response.Content.ReadAsStringAsync();
                Console.WriteLine(yeet);
            }
            return product;
        }

        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://api.openweathermap.org/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // SVAKA FUNKCIJA KOJA POZIVA API MORA BITI ASYNC
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // SVAKI POZIV API TREBA DA IMA AWAIT ISPRED FUNKCIJE
            await GetCurrentAsync(apiCurrentUrl + "London,us" + apiAppId);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await GetCurrentAsync(apiFiveDayUrl + "London,us" + apiAppId);
        }
    }
}
