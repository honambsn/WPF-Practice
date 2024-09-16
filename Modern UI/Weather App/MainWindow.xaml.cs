using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
			string url = $"{BaseUrl}?id={CityId}&appid={ApiKey}&units=metric";

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
					string description = weatherData["weather"][0]["description"].ToString();
					string icon = weatherData["weather"][0]["icon"].ToString(); // Get the weather icon code

					// Update ViewModel properties
					_viewModel.Description = $"{description}";
					_viewModel.Temperature = $"{temperature}°C";
					_viewModel.IconUrl = $"http://openweathermap.org/img/wn/{icon}@2x.png";
				}
				catch (HttpRequestException ex)
				{
					_viewModel.Description = $"Error: {ex.Message}";
				}
			}
		}
	}
}
