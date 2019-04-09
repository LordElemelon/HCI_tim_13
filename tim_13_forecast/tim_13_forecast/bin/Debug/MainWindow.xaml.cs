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
using System.ComponentModel;
using System.Timers;
using System.Device.Location;

namespace tim_13_forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private FiveDayForecast product;
        private DateTime count;
        private int dayComparison;
        public string cityToRefresh;
        private FavouriteWindow favWin;
        private ComplexWindow s;
        public List<City> CitiesHistory { get; set; }
        public List<City> Favourites { get; set; }
        public ObservableCollection<string> AllCityList { get; set; }
        private static System.Timers.Timer guiRefreshTimer;
        static HttpClient client = new HttpClient();
        static HttpClient client2 = new HttpClient();
        static string apiFiveDayUrl = "data/2.5/forecast?q=";
        static string apiCurrentUrl = "data/2.5/weather?q=";
        static string apiAppId = "&appid=f2dc7da9486c3f883a8caa8329c8b11d";
        static string apiFiveDayUrlIP = "data/2.5/forecast?";
        static string apiIP = "?access_key=0aaf859bb32648d8c05bf3b57ff79a88&fields=latitude,longitude";

        

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        

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

                product = JsonConvert.DeserializeObject<FiveDayForecast>(yeet);

            }
            return product;
        }

        static async Task<IP> GetCurrentLocation(string path)
        {
            IP product = null;
            HttpResponseMessage response = await client2.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // OTKOMENTARISATI KADA SE NAPRAVI KLASA CurrentForecast
                //product = await response.Content.ReadAsAsync<FiveDayForecast>();
                string yeet = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<IP>(yeet);

            }
            return product;
        }

        private void LoadFavourites()
        {

            using (StreamReader file = File.OpenText("../../favourites.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<City> fav = (List<City>)serializer.Deserialize(file, typeof(List<City>));
                if (fav == null)
                    Favourites = new List<City>();
                else {
                    Favourites = fav;
                    foreach(City c in fav)
                    {
                        favWin.listView.Items.Add(c.name + ","+c.country);
                    }
                }
            }


        }

        public MainWindow()
        {
            InitializeComponent();
            this.count = new DateTime();
            this.product = new FiveDayForecast();
            this.cityToRefresh = "";
            this.dayComparison = 0;
            this.favWin = new FavouriteWindow(this);
            this.s = new ComplexWindow();
            Closing += this.OnWindowClosing;
            CitiesHistory = new List<City>(10);

            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;
            this.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\oblacno.png")));
            Day4.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\SmallButton.png")));
            

            #region CityList
            AllCityList = new ObservableCollection<string>();
            AllCityList.Add("London,UK");
            AllCityList.Add("London,US");
            AllCityList.Add("Paris,FR");
            AllCityList.Add("Bangkok,TH");
            AllCityList.Add("Singapore,SG");
            AllCityList.Add("New York,US");
            AllCityList.Add("Kuala Lumpur,MY");
            AllCityList.Add("Hong Kong,HK");
            AllCityList.Add("Dubai,AE");
            AllCityList.Add("Istanbul,TR");
            AllCityList.Add("Rome,IT");
            AllCityList.Add("Shangai,CN");
            AllCityList.Add("Los Angeles,CL");
            AllCityList.Add("Las Vegas,US");
            AllCityList.Add("Miami,US");
            AllCityList.Add("Toronto,CA");
            AllCityList.Add("Barcelona,ES");
            AllCityList.Add("Dublin,IE");
            AllCityList.Add("Amsterdam,NL");
            AllCityList.Add("Moscow,RU");
            AllCityList.Add("Cairo,EG");
            AllCityList.Add("Prague,CZ");
            AllCityList.Add("Belgrade,RS");
            AllCityList.Add("Novi Sad,RS");
            AllCityList.Add("Tokyo,JP");

            this.DataContext = this;
            #endregion

            LoadFavourites();

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

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private async void LocationMethod(string ip)
        {
            IP ip2 = await GetCurrentLocation(ip + apiIP);
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            watcher.Start();
            GeoCoordinate cord = watcher.Position.Location;
            if (!watcher.Position.Location.IsUnknown)
            {
                double lat = cord.Latitude;
                double lon = cord.Longitude;


            }

            product = await GetFiveDayAsync(apiFiveDayUrlIP + "lat=" + ip2.latitude + "&lon=" + ip2.longitude + apiAppId);
            searchBox.Text = product.city.name + "," + product.city.country;
            this.cityToRefresh = searchBox.Text;
            setupTimer();
        }

        // SVAKA FUNKCIJA KOJA POZIVA API MORA BITI ASYNC


        private async void refreshGui(Object source = null, ElapsedEventArgs e = null)
        {
            await this.Dispatcher.Invoke(async () =>
            {
                product = await GetFiveDayAsync(apiFiveDayUrl + cityToRefresh + apiAppId);
                City.Content = cityToRefresh;

                this.Day1.Content = DateTime.Parse(product.list[0].dt_txt).Day + "/" + DateTime.Parse(product.list[0].dt_txt).Month + "/" + DateTime.Parse(product.list[0].dt_txt).Year;
                this.Day2.Content = DateTime.Parse(product.list[8].dt_txt).Day + "/" + DateTime.Parse(product.list[8].dt_txt).Month + "/" + DateTime.Parse(product.list[8].dt_txt).Year;
                this.Day3.Content = DateTime.Parse(product.list[16].dt_txt).Day + "/" + DateTime.Parse(product.list[16].dt_txt).Month + "/" + DateTime.Parse(product.list[16].dt_txt).Year;
                this.Day4.Content = DateTime.Parse(product.list[24].dt_txt).Day + "/" + DateTime.Parse(product.list[24].dt_txt).Month + "/" + DateTime.Parse(product.list[24].dt_txt).Year;
                this.Day5.Content = DateTime.Parse(product.list[32].dt_txt).Day + "/" + DateTime.Parse(product.list[31].dt_txt).Month + "/" + DateTime.Parse(product.list[31].dt_txt).Year;
                Overview.Content = product.list[dayComparison].weather[0].description;

                double min = 900000, max = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (min > product.list[dayComparison + i].main.temp_min)
                    {
                        min = product.list[dayComparison + i].main.temp_min;
                    }
                    if (max < product.list[dayComparison + i].main.temp_max)
                    {
                        max = product.list[dayComparison + i].main.temp_max;
                    }
                }

                Temperatura.Content = Math.Round(min - 272.15) + "°C" + "/" + Math.Round(max - 272.15) + "°C";
                CurTemp.Content = Math.Round(product.list[dayComparison].main.temp - 272.15) + "°C";
                Humidity.Content = "Humidity: " + product.list[dayComparison].main.humidity + "%";
                Wind.Content = "Wind: " + product.list[dayComparison].wind.speed + "km/s";
                this.Draw(image, product.list[dayComparison].weather[0].main);
                
            });

        }


        public void setupTimer()
        {
            if (guiRefreshTimer != null)
            {
                guiRefreshTimer.Stop();
                guiRefreshTimer.Dispose();
            }
            refreshGui();
            guiRefreshTimer = new System.Timers.Timer(5000);
            guiRefreshTimer.Elapsed += refreshGui;
            guiRefreshTimer.AutoReset = true;
            guiRefreshTimer.Enabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.cityToRefresh = searchBox.Text;
            setupTimer();
            AddToHistory();

        }

        private void Day1_Click(object sender, RoutedEventArgs e)
        {
           
            dayComparison = 0;
            setupTimer();
        }

        private void Day2_Click(object sender, RoutedEventArgs e)
        {
            
            dayComparison = 8;
            setupTimer();
        }

        private void Day3_Click(object sender, RoutedEventArgs e)
        {
            dayComparison = 16;
            setupTimer();
        }

        private void Day4_Click(object sender, RoutedEventArgs e)
        {
            
            dayComparison = 24;
            setupTimer();
        }

        private void Day5_Click(object sender, RoutedEventArgs e)
        {
           
            dayComparison = 31;
            setupTimer();
        }

        private void Detailed_View_Click(object sender, RoutedEventArgs e)
        {

            s.Show();
            this.Draw(s.image1, product.list[this.dayComparison].weather[0].main);
            s.label11.Content = DateTime.Parse(product.list[this.dayComparison].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison].dt_txt).Minute;
            s.label12.Content = Math.Round(product.list[this.dayComparison].main.temp - 272.15);

            this.Draw(s.image2, product.list[this.dayComparison + 1].weather[0].main);
            s.label21.Content = DateTime.Parse(product.list[this.dayComparison + 1].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 1].dt_txt).Minute;
            s.label22.Content = Math.Round(product.list[this.dayComparison + 1].main.temp - 272.15);


            this.Draw(s.image3, product.list[this.dayComparison + 2].weather[0].main);
            s.label31.Content = DateTime.Parse(product.list[this.dayComparison + 2].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 2].dt_txt).Minute;
            s.label32.Content = Math.Round(product.list[this.dayComparison + 2].main.temp - 272.15);


            this.Draw(s.image4, product.list[this.dayComparison + 3].weather[0].main);
            s.label41.Content = DateTime.Parse(product.list[this.dayComparison + 3].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 3].dt_txt).Minute;
            s.label42.Content = Math.Round(product.list[this.dayComparison + 3].main.temp - 272.15);


            this.Draw(s.image5, product.list[this.dayComparison + 4].weather[0].main);
            s.label51.Content = DateTime.Parse(product.list[this.dayComparison + 4].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 4].dt_txt).Minute;
            s.label52.Content = Math.Round(product.list[this.dayComparison + 4].main.temp - 272.15);


            this.Draw(s.image6, product.list[this.dayComparison + 5].weather[0].main);
            s.label61.Content = DateTime.Parse(product.list[this.dayComparison + 5].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 5].dt_txt).Minute;
            s.label62.Content = Math.Round(product.list[this.dayComparison + 5].main.temp - 272.15);


            this.Draw(s.image7, product.list[this.dayComparison + 6].weather[0].main);
            s.label71.Content = DateTime.Parse(product.list[this.dayComparison + 6].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 6].dt_txt).Minute;
            s.label72.Content = Math.Round(product.list[this.dayComparison + 6].main.temp - 272.15);


            this.Draw(s.image8, product.list[this.dayComparison + 7].weather[0].main);
            s.label81.Content = DateTime.Parse(product.list[this.dayComparison + 7].dt_txt).Hour + ":" + DateTime.Parse(product.list[this.dayComparison + 7].dt_txt).Minute;
            s.label82.Content = Math.Round(product.list[this.dayComparison + 7].main.temp - 272.15);





            s.Show();
        }


        private void Draw(Image image, string type)
        {
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;

            if (type.Equals("Clear"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\sun.png"));
                this.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\suncano.jpg")));

            }
            else if (type.Equals("Clouds"))
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\cloud.png"));
                this.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\oblacno.png")));
            }
            else
            {
                image.Source = new BitmapImage(new Uri(path + @"\images\rain.png"));
                this.Background = new ImageBrush(new BitmapImage(new Uri(path + @"\images\kisa.jpg")));
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

        public void SaveFavourites()
        {
            using (StreamWriter file = File.CreateText(@"../../favourites.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Favourites);
            }
        }

        
        private void favourite_Checked(object sender, RoutedEventArgs e)
        {

            this.favouriteNO.Visibility = Visibility.Hidden;
            this.favouriteYES.Visibility = Visibility.Visible;

            if (product.city == null)
            {
                this.favouriteNO.Visibility = Visibility.Visible;
                this.favouriteYES.Visibility = Visibility.Hidden;
                return;
            }
            bool exists = false;
            for (int i = 0; i < Favourites.Count; i++)
            {
                if (product.city.id == Favourites.ElementAt(i).id)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                Favourites.Add(new City(product.city.id, product.city.name, product.city.coord, product.city.country, product.city.population));
                favWin.listView.Items.Add(product.city.name + "," + product.city.country);
                SaveFavourites();
            }


        }

    private void favourite_Unchecked(object sender, RoutedEventArgs e)
        {

            this.favouriteYES.Visibility = Visibility.Hidden;
            this.favouriteNO.Visibility = Visibility.Visible;
            this.favouriteNO.Visibility = Visibility.Visible;
            for (int i = 0; i < Favourites.Count; i++)
            {
                if (product.city.id == Favourites.ElementAt(i).id)
                {
                    Favourites.Remove(Favourites.ElementAt(i));
                    favWin.listView.Items.Remove(product.city.name + "," + product.city.country);
                    SaveFavourites();
                    break;
                }
            }

        }
       
        private void ComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            this.favouriteYES.Visibility = Visibility.Hidden;
            this.favouriteNO.Visibility = Visibility.Visible;

        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.cityToRefresh = searchBox.Text;
            setupTimer();
            AddToHistory();

            string selected_city = null;
            bool found = false;
            try
            {
                selected_city = searchBox.SelectedValue.ToString();

            }
            catch
            {
                return;
            }
            
            for (int i = 0; i < Favourites.Count; i++)
            {
                if (selected_city == Favourites.ElementAt(i).name + "," + Favourites.ElementAt(i).country)
                {
                    this.favouriteYES.Visibility = Visibility.Visible;
                    this.favouriteNO.Visibility = Visibility.Hidden;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.favouriteYES.Visibility = Visibility.Hidden;
                this.favouriteNO.Visibility = Visibility.Visible;
            }

        }

        private async void AddToHistory()
        {
            product = await GetFiveDayAsync(apiFiveDayUrl + searchBox.Text + apiAppId);
            City currentCity = product.city;
            City.Content = searchBox.Text;

            foreach (City city in CitiesHistory)
            {
                if (city.id.Equals(currentCity.id))
                {
                    CitiesHistory.Remove(city);
                    break;
                }
            }

            if (CitiesHistory.Count == 10)
            {
                CitiesHistory.RemoveAt(9);
            }
            CitiesHistory.Insert(0, currentCity);



        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                this.cityToRefresh = searchBox.Text;
                setupTimer();
                bool found = false;
                string selected_city = searchBox.Text;
                for (int i = 0; i < Favourites.Count; i++)
                {
                    if (selected_city == Favourites.ElementAt(i).name + "," + Favourites.ElementAt(i).country)
                    {
                        this.favouriteYES.Visibility = Visibility.Visible;
                        this.favouriteNO.Visibility = Visibility.Hidden;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    this.favouriteYES.Visibility = Visibility.Hidden;
                    this.favouriteNO.Visibility = Visibility.Visible;
                }
            }
            else
            {

                return;    
            }
            

        }

        private void FavClick(object sender, RoutedEventArgs e)
        {
            favWin.Show();
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName).FullName;
            List<string> temperature = new List<string>();
            List<Image> slike = new List<Image>();
            int brojac = 0;
            foreach (City city in CitiesHistory)
            {
                var product1 = await GetFiveDayAsync(apiFiveDayUrl + city.name + "," + city.country + apiAppId);
                string temperatura = product1.list[dayComparison].main.temp_min + "/" + product.list[dayComparison].main.temp_max;
                temperature.Add(temperatura);
                string type = product1.list[dayComparison].weather[0].main;
                if (type.Equals("Clear"))
                {
                    slike.Add(new Image());
                    slike.ElementAt(brojac).Source = new BitmapImage(new Uri(path + @"\images\sun.png"));

                }
                else if (type.Equals("Clouds"))
                {
                    slike.Add(new Image());
                    slike.ElementAt(brojac).Source = new BitmapImage(new Uri(path + @"\images\cloud.png"));
                }
                else
                {
                    slike.Add(new Image());
                    slike.ElementAt(brojac).Source = new BitmapImage(new Uri(path + @"\images\rain.png"));
                }
                brojac++;
            }
            var history = new HistoryWindow(CitiesHistory, this, temperature, slike);
            history.Show();
        }

        public void setCityToRefresh(string city)
        {
            cityToRefresh = city;
            setupTimer();
        }
    }
}
