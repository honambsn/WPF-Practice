using Files_Explorer.Models;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Files_Explorer.ViewModel
{
	internal class ViewModel : INotifyPropertyChanged
	{
		#region Properties
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		readonly ResourceDictionary _iconDictionary = 
			Application.LoadComponent(new Uri("/Files Explorer;component/Resources/Icons.xaml",
				UriKind.RelativeOrAbsolute)) as ResourceDictionary;

		public string ParentDirectory { get; set; }
		public string PreviousDirectory { get; set; }
		public string CurrentDirectory { get; set; }
		public string NextDirectory { get; set; }
		public string SelectedDriveSize { get; set; }
		public string SelectedFolderDetails { get; set; }
		

		public ObservableCollection<FileDetailsModel> FavoriteFolders { get; set; }
		public ObservableCollection<FileDetailsModel> RemoteFolders { get; set; }
		public ObservableCollection<FileDetailsModel> LibraryFolders { get; set; }
		public ObservableCollection<FileDetailsModel> ConnectedDevices { get; set; }
		public ObservableCollection<FileDetailsModel> NavigatedFolderFiles { get; set; }
		#endregion

		#region Functions

		public ViewModel()
		{
			RemoteFolders = new ObservableCollection<FileDetailsModel>()
			{
				new FileDetailsModel()
				{
					Name = "OneDrive",
					IsDirectory = true,
					Path = Environment.GetEnvironmentVariable("OneDriveConsumer"),
					FileIcon = (PathGeometry)_iconDictionary["OneDrive"]
				},
				new FileDetailsModel()
				{
					Name = "Google Drive",
					IsDirectory = true,
					//Path = Environment.GetEnvironmentVariable("GoogleDrive"),
					Path = "",
					FileIcon = (PathGeometry)_iconDictionary["GoogleDrive"]
				},
				new FileDetailsModel()
				{
					Name = "Dropbox",
					IsDirectory = true,
					//Path = Environment.GetEnvironmentVariable("Dropbox"),
					Path = "",
					FileIcon = (PathGeometry)_iconDictionary["Dropbox"]
				}
			};

			LibraryFolders = new ObservableCollection<FileDetailsModel>()
			{
				new FileDetailsModel()
				{
					Name = "Desktop",
					IsDirectory = true,
					Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
					FileIcon = (PathGeometry)_iconDictionary["DesktopFolder"]
				},
				new FileDetailsModel()
				{
					Name = "Documents",
					IsDirectory = true,
					Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
					FileIcon = (PathGeometry)_iconDictionary["DocumentsFolder"]
				},
				new FileDetailsModel()
				{
					Name = "Downloads",
					IsDirectory = true,
					Path = new KnownFolder(KnownFolderType.Downloads).Path,
					FileIcon = (PathGeometry)_iconDictionary["DownloadsFolder"]
				},
				new FileDetailsModel()
				{
					Name = "Pictures",
					IsDirectory = true,
					Path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
					FileIcon = (PathGeometry)_iconDictionary["PicturesFolder"]
				},
				new FileDetailsModel()
				{
					Name = "Videos",
					IsDirectory = true,
					Path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
					FileIcon = (PathGeometry)_iconDictionary["VideosFolder"]
				},
				new FileDetailsModel()
				{
					Name = "Music",
					IsDirectory = true,
					Path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
					FileIcon = (PathGeometry)_iconDictionary["MusicFolder"]
				}
			};
		}	
		#endregion
	}
}
