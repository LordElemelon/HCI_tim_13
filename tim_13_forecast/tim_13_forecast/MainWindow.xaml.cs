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
using tim_13_forecast.models2;
using tim_13_forecast.models;
using System.Web;
using Newtonsoft.Json;
using System.Net.Sockets;
using tim_13_forecast.models3;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;

namespace tim_13_forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FiveDayForecast product;
        private DateTime count;
        public ObservableCollection<string> AllCityList { get; set; }
        static HttpClient client = new HttpClient();
        static HttpClient client2 = new HttpClient();
        static string apiFiveDayUrl = "data/2.5/forecast?q=";
        static string apiCurrentUrl = "data/2.5/weather?q=";
        static string apiAppId = "&appid=f2dc7da9486c3f883a8caa8329c8b11d";
        static string apiIP = "?access_key=0aaf859bb32648d8c05bf3b57ff79a88&fields=latitude,longitude";

        static async Task<CurrentForecast> GetCurrentAsync(string path)
        {
            CurrentForecast product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // OTKOMENTARISATI KADA SE NAPRAVI KLASA CurrentForecast
                // product = await response.Content.ReadAsAsync<CurrentForecast>();
                string yeet = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<CurrentForecast>(yeet);
                Console.WriteLine(product.weather[0].main);


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

                product = JsonConvert.DeserializeObject<FiveDayForecast>(yeet);

            }
            return product;
        }

        static async Task<string> GetCurrentLocation(string path)
        {
            string product = null;
            HttpResponseMessage response = await client2.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // OTKOMENTARISATI KADA SE NAPRAVI KLASA CurrentForecast
                //product = await response.Content.ReadAsAsync<FiveDayForecast>();
                string yeet = await response.Content.ReadAsStringAsync();
                Console.WriteLine(yeet);
                product = yeet;

            }
            return product;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.count = new DateTime();
            this.product = new FiveDayForecast();

            this.AllCityList = new ObservableCollection<string>()
            {
            "London,uk",
            "London,us"
            };


            client2.BaseAddress = new Uri("http://api.ipstack.com/");
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ip = GetLocalIPAddress();
            Console.WriteLine(ip + " OVO JE IP ADRESA");

            string ip2 = "188.2.100.218";
            LocationMethod(ip2);

            client.BaseAddress = new Uri("http://api.openweathermap.org/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void LocationMethod(string ip)
        {
            string ip2 = await GetCurrentLocation(ip+ apiIP);
            Console.WriteLine(ip2 + " IPA 2 ");
        }

        // SVAKA FUNKCIJA KOJA POZIVA API MORA BITI ASYNC
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // SVAKI POZIV API TREBA DA IMA AWAIT ISPRED FUNKCIJE
            CurrentForecast product = await GetCurrentAsync(apiCurrentUrl + searchBox.Text + apiAppId);
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;

            if (product.weather[0].main.Equals("Clear"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\sun.png"));

            }
            else if (product.weather[0].main.Equals("Clouds"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\sun.png"));
            }
            else
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\sun.png"));
            }



        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City.Content = searchBox.Text;

            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(startDate.Month + "/" + startDate.Day + " OVO JE DATUM");
                if (Math.Abs(tz.TotalMinutes) <= 90)
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private async void Day1_Click(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City.Content = searchBox.Text;
            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(tz.TotalMinutes + " minutaza");
                Console.WriteLine(startDate.Month + "/" + startDate.Day + " OVO JE DATUM");

                if (Math.Abs(tz.TotalMinutes) <= 90)
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private async void Day2_Click(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City.Content = searchBox.Text;
            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(tz.TotalMinutes + " minutaza");
                Console.WriteLine(startDate.Date + " date");

                if (Math.Abs(tz.TotalMinutes) > 1440)
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private async void Day3_Click(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City.Content = searchBox.Text;
            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(startDate.Month + "/" + startDate.Day + " OVO JE DATUM");

                if (Math.Abs(tz.TotalMinutes) > 1440 * 2)
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private async void Day4_Click(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City.Content = searchBox.Text;
            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(startDate.Month + "/" + startDate.Day + " OVO JE DATUM");

                if (Math.Abs(tz.TotalMinutes) > 1440 * 3 )
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private async void Day5_Click(object sender, RoutedEventArgs e)
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + "London,us" + apiAppId);
            City.Content = searchBox.Text;
            foreach (models.List list in product.list)
            {
                DateTime startDate = DateTime.Parse(list.dt_txt);

                TimeSpan tz = DateTime.Now - startDate;
                Console.WriteLine(startDate.Month + "/" + startDate.Day + " OVO JE DATUM");

                if (Math.Abs(tz.TotalMinutes) > 1440 * 4)
                {
                    this.count = startDate;
                    Overview.Content = list.weather[0].description;
                    Temperatura.Content = list.main.temp_min + "/" + list.main.temp_max;
                    Humidity.Content = "Humidity: " + list.main.humidity + "%";
                    Wind.Content = "Wind: " + list.wind.speed + "km/s";
                    this.Draw(image, list.weather[0].main);
                    break;
                }


            }
        }

        private void Detailed_View_Click(object sender, RoutedEventArgs e)
        {
            var s = new ComplexWindow();
            for (int i = 0; i < product.list.Count;i++){
                if (count.Equals(DateTime.Parse(product.list[i].dt_txt)))
                {
                    this.Draw(s.image1, product.list[i].weather[0].main);

                    this.Draw(s.image2, product.list[i+1].weather[0].main);

                    this.Draw(s.image3, product.list[i+2].weather[0].main);

                    this.Draw(s.image4, product.list[i+3].weather[0].main);

                    this.Draw(s.image5, product.list[i+4].weather[0].main);

                    this.Draw(s.image6, product.list[i + 5].weather[0].main);

                    this.Draw(s.image7, product.list[i + 6].weather[0].main);

                    this.Draw(s.image8, product.list[i + 7].weather[0].main);

                    break;
                }
            }
            s.Show();
        }

        private void Draw(Image image, String type)
        {
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;

            if (type.Equals("Clear"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\sun.png"));

            }
            else if (type.Equals("Clouds"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\cloud.png"));
            }
            else
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\rain.png"));
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
