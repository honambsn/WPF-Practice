using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weather_App.ViewModel;

namespace Weather_App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			_viewModel = new WeatherViewModel();
			DataContext = _viewModel;

			// Optionally, you can fetch the weather data when the window loads
			LoadWeatherData();
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}

		private void textSearch_MouseDown(object sender, MouseButtonEventArgs e)
		{
			textSearch.Focus();
		}

		private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text.Length > 0)
			{
				textSearch.Visibility = Visibility.Collapsed;
			}
			else
			{
				textSearch.Visibility = Visibility.Visible;
			}	
		}


		private WeatherViewModel _viewModel;

		private const string ApiKey = "d4c56fcae54bbc960c8385227bee335b";
		private const string CityId = "1566083";
		private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";


		private async void LoadWeatherData()
		{
			//string url = $"{BaseUrl}?id={CityId}&appid={ApiKey}";
			string url = $"https://api.openweathermap.org/data/2.5/weather?id=1566083&appid=d4c56fcae54bbc960c8385227bee335b&units=metric";

			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();

					// Parse the JSON data
					JObject weatherData = JObject.Parse(responseBody);
					string temperature = weatherData["main"]["temp"].ToString();
					string mainWeather = weatherData["weather"][0]["main"].ToString();
					string description = weatherData["weather"][0]["description"].ToString();

					if (weatherData["rain"] != null)
					{
						_viewModel.RainAmount = $"{weatherData["rain"]["1h"]} mm";
					}
					else
					{
						_viewModel.RainAmount = "No rain";
					}


					string icon = weatherData["weather"][0]["icon"].ToString(); // Get the weather icon code

					string cityName = weatherData["name"].ToString();
					string countryName = weatherData["sys"]["country"].ToString();
					// Update ViewModel properties
					_viewModel.mainWeather = $"{mainWeather}";
					_viewModel.Description = $"{description}";
					_viewModel.Temperature = $"{temperature}°C";
					_viewModel.CityName = $"{cityName}";
					_viewModel.CountryName = $"{countryName}";
					_viewModel.IconUrl = $"http://openweathermap.org/img/wn/{icon}@2x.png";


					//get time
					int timezone = int.Parse(weatherData["timezone"].ToString());

					//int offsetSeconds = timezone; // 7 hours in seconds

					//// Convert offset to TimeSpan
					//TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);

					//// Example: Get current UTC time
					//DateTime utcNow = DateTime.UtcNow;

					//// Apply the offset to get the local time
					//DateTime localTime = utcNow.Add(offset);

					//// Output the results
					//MessageBox.Show("UTC Time: " + utcNow);
					//MessageBox.Show("Local Time with Offset: " + localTime);


					int offsetSeconds = timezone; // 7 hours in seconds

					// Convert offset to TimeSpan
					TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);

					// Example: Get current UTC time
					DateTime utcNow = DateTime.UtcNow;

					// Apply the offset to get the local time
					DateTime localTime = utcNow.Add(offset);

					// Extract date and time components
					string datePart = localTime.ToString("dd/MM/yyyy"); // Format as Day/Month/Year
					string timePart = localTime.ToString("HH:mm:ss");   // Format as Hour:Minute:Second

					// Output the results
					//MessageBox.Show("UTC Time: " + utcNow);
					//MessageBox.Show("Local Time with Offset: " + localTime);
					//MessageBox.Show("Date Part: " + datePart);

					//MessageBox.Show("Time Part: " + timePart);
					
					
					_viewModel.LocalTime = timePart;
					_viewModel.LocalDate = datePart;



					// date of week
					DateTime today = DateTime.Today;					
					// Get the abbreviated name for today
					string todayAbbreviation = today.ToString("ddd"); // "ddd" gives abbreviated day name

					_viewModel.LocalDoWeek = todayAbbreviation;

					string windSpeed = weatherData["wind"]["speed"].ToString();
					_viewModel.WindSpeed = $"{windSpeed}";

					string humidity = weatherData["main"]["humidity"].ToString();
					_viewModel.Humidity = $"{humidity}";
				}
				catch (HttpRequestException ex)
				{
					_viewModel.Description = $"Error: {ex.Message}";
				}
			}
		}

	}
}
