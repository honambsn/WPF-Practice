using Files_Explorer.Commands;
using Files_Explorer.Models;
using Microsoft.VisualBasic;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;



namespace Files_Explorer.ViewModel
{
	public class ViewModel : INotifyPropertyChanged
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
		public ObservableCollection<SubMenuItemDetails> HomeTabSubMenuCollection { get; set; }
		public ObservableCollection<SubMenuItemDetails> ViewTabSubMenuCollection { get; set; }
		internal ReadOnlyCollection<string> tempFolderCollection;

		private BackgroundWorker bgGetFilesBackgroundWorker = new BackgroundWorker()
		{
			WorkerReportsProgress = true,
			WorkerSupportsCancellation = true
		};

		private BackgroundWorker bgGetFilesSizeBackgroundWorker = new BackgroundWorker()
		{
			WorkerSupportsCancellation = true
		};
		#endregion

		#region Functions

		internal bool IsFileHidden(string fileName)
		{
			System.IO.FileAttributes attr = (FileAttributes)FileAttribute.Normal;
			try
			{
				attr = File.GetAttributes(fileName);
			}
			catch
			{
				//return false;
			}
			return attr.HasFlag(FileAttributes.Hidden);
		}

		internal bool IsFileReadOnly(string path)
		{
			//var attr = FileAttribute.Normal;
			try
			{
				if (Directory.Exists(path))
					return (new DirectoryInfo(path).Attributes & FileAttributes.ReadOnly) != 0;

				return (new FileInfo(path).Attributes & FileAttributes.ReadOnly) != 0;
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
			catch (FileNotFoundException)
			{
				return false;
			}
			catch(DirectoryNotFoundException)
			{
				return false;
			}
		}
		
		internal bool IsDirectory(string fileName)
		{
			System.IO.FileAttributes attr = (FileAttributes)FileAttribute.Normal;
			try
			{
				attr = File.GetAttributes(fileName);
			}
			catch (FileNotFoundException)
			{
				return false;
			}
			return attr.HasFlag(FileAttributes.Directory);
		}
		internal string GetFileExtension(string fileName)
		{
			if (fileName == null) return string.Empty;
			
			var extension = Path.GetExtension(fileName);
			var CultureInfo = Thread.CurrentThread.CurrentCulture;
			var textInfo = CultureInfo.TextInfo;
			var data = textInfo.ToTitleCase(extension.Replace(".", string.Empty));

			return data;
		}

		internal static readonly List<string> ImageExtensions = new List<string>
		{
			".jpg", ".jpeg", ".png", ".bmp", ".gif"
		};
		internal static readonly List<string> VideoExtensions = new List<string>
		{
			"mp4",
			"m4v",
			"mov",
			"wmv",
			"avi",
			"avchd",
			"flv",
			"f4v",
			"swf",
			"mkv",
			"webm",
		};

		internal PathGeometry GetImageForExtension(FileDetailsModel file)
		{
			var fileExtension = file.FileExtension;
			if (Directory.Exists(file.Path))
				return (PathGeometry)_iconDictionary["Folder"];

			if (file.IsImage)
				return (PathGeometry)_iconDictionary["ImageFile"];

			if (file.IsVideo)
				return (PathGeometry)_iconDictionary["VideoFile"];

			if((PathGeometry)_iconDictionary[$"{fileExtension}File"]==null)
				return (PathGeometry)_iconDictionary["File"];
			
			return (PathGeometry)_iconDictionary[$"{fileExtension}File"];

		}

		void LoadDirectory(FileDetailsModel fileDetailsModel)
		{
			NavigatedFolderFiles.Clear();
			tempFolderCollection = null;

			if (bgGetFilesBackgroundWorker.IsBusy)
				bgGetFilesBackgroundWorker.CancelAsync();

			bgGetFilesBackgroundWorker.RunWorkerAsync(fileDetailsModel);
		}
		private void BgGetFilesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var fileOrFolder = (FileDetailsModel)e.Argument;
			//if (fileOrFolder == null)
			//{
			//	throw new ArgumentNullException(nameof(e.Argument), "The argument passed to the background worker cannot be null.");
			//}

			tempFolderCollection =
				new ReadOnlyCollectionBuilder<string>(Directory.GetDirectories(fileOrFolder.Path)
				.Concat(Directory.GetFiles(fileOrFolder.Path))).ToReadOnlyCollection();

			foreach (var filename in tempFolderCollection)
				bgGetFilesBackgroundWorker.ReportProgress(1, filename);

			CurrentDirectory = fileOrFolder.Path;
			OnPropertyChanged(nameof(CurrentDirectory));
		}

		private void BgGetFilesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			var fileName = e.UserState.ToString();
			var file = new FileDetailsModel();
			file.Name = Path.GetFileName(fileName);
			file.Path = fileName;
			file.IsHidden = IsFileHidden(fileName);
			file.IsDirectory = IsDirectory(fileName);
			file.FileExtension = GetFileExtension(fileName);
			file.IsImage = ImageExtensions.Contains(file.FileExtension.ToLower());
			file.IsVideo = VideoExtensions.Contains(file.FileExtension.ToLower());
			file.FileIcon = GetImageForExtension(file);

			NavigatedFolderFiles.Add(file);
			OnPropertyChanged(nameof(NavigatedFolderFiles));

		}

		private void BgGetFilesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//throw new NotImplementedException();
		}

		internal string CalculateSize(long bytes)
		{
			var suffix = new[] { "B", "KB", "MB", "GB", "TB" };
			float byteNumber = bytes;

			for (var i = 0; i < suffix.Length; i++)
			{
				if (byteNumber < 1000)
				{
					if (i == 0)
						return $"{byteNumber} {suffix[i]}";
					else
						return $"{byteNumber:0.#0} {suffix[i]}";
				}
				else
				{
					byteNumber /= 1024;
				}
			}
			return $"{byteNumber:N} {suffix[suffix.Length - 1]}";
		}

		internal static long GetDirectorySize(string directoryPath)
		{
			try
			{
				var d = new DirectoryInfo(directoryPath);
				return d.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
			}
			catch (UnauthorizedAccessException)
			{
				return 0;
			}
			catch(FileNotFoundException)
			{
				return 0;
			}
			catch(DirectoryNotFoundException)
			{
				return 0;
			}
		}

		private void BgGetFilesSizeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var FileSize = NavigatedFolderFiles.Where(File=>File.IsSelected && !File.IsDirectory)
				.Sum(x=> new FileInfo(x.Path).Length);


			SelectedFolderDetails = CalculateSize(FileSize);
			OnPropertyChanged(nameof(SelectedFolderDetails));

			var Directories = NavigatedFolderFiles.Where(directory => directory.IsSelected && directory.IsDirectory);
			try
			{
				foreach(var directory in Directories)
				{
					FileSize += GetDirectorySize(directory.Path);
					SelectedFolderDetails = CalculateSize(FileSize);
					OnPropertyChanged(nameof(SelectedFolderDetails));
				}
			}
			//catch (UnauthorizedAccessException)
			//{
			//	SelectedFolderDetails = "Access Denied";
			//	OnPropertyChanged(nameof(SelectedFolderDetails));
			//}
			//catch (FileNotFoundException)
			//{
			//	SelectedFolderDetails = "File Not Found";
			//	OnPropertyChanged(nameof(SelectedFolderDetails));
			//}
			//catch (DirectoryNotFoundException)
			//{
			//	SelectedFolderDetails = "Directory Not Found";
			//	OnPropertyChanged(nameof(SelectedFolderDetails));
			//}
			catch (InvalidOperationException)
			{

			}
		}


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

			ConnectedDevices = new ObservableCollection<FileDetailsModel>();

			foreach (var drive in DriveInfo.GetDrives())
			{
				var name = string.IsNullOrEmpty(drive.VolumeLabel) ? "Local Disk" : drive.VolumeLabel;
				ConnectedDevices.Add(new FileDetailsModel()
				{
					Name = $"{name}({drive.Name.Replace(@"\", "")})",
					Path = drive.RootDirectory.FullName,
					IsDirectory = true,
					FileIcon = drive.Name.Contains("C:")
					? (PathGeometry)_iconDictionary["CDrive"]
					: (PathGeometry)_iconDictionary["NormalDrive"]
				});
			}

			//HomeTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>();

			LoadSubenuCollectionsCommmand.Execute(null);

			CurrentDirectory = @"C:\";

			OnPropertyChanged(nameof(CurrentDirectory));
			
			NavigatedFolderFiles = new ObservableCollection<FileDetailsModel>();

			bgGetFilesBackgroundWorker.DoWork += BgGetFilesBackgroundWorker_DoWork;
			bgGetFilesBackgroundWorker.ProgressChanged += BgGetFilesBackgroundWorker_ProgressChanged;
			bgGetFilesBackgroundWorker.RunWorkerCompleted += BgGetFilesBackgroundWorker_RunWorkerCompleted;

			LoadDirectory(new FileDetailsModel()
			{
				Path =CurrentDirectory 
				
			});
		}

		#endregion


		#region Commands

		private ICommand _openSettingsCommand;

		public ICommand OpenSettingsCommand
		{
			get
			{
				return _openSettingsCommand ??
					(_openSettingsCommand = new Command(() => Process.Start("ms-settings:home")));
			}
		}

		private ICommand _openUserProfileSettingsCommand;

		public ICommand OpenUserProfileSettingsCommand
		{
			get
			{
				return _openUserProfileSettingsCommand ??
									(_openUserProfileSettingsCommand = new Command(() => Process.Start("ms-settings:yourinfo")));
			}
		}

		private ICommand _loadSubMenuCollectionsCommand;
		public ICommand LoadSubenuCollectionsCommmand => _openSettingsCommand ??
			(_openUserProfileSettingsCommand = new Command(() =>
			{
				HomeTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
				{
					new SubMenuItemDetails()
					{
						Name = "Pin",
						Icon = (PathGeometry)_iconDictionary["Pin"]
					},
					new SubMenuItemDetails()
					{
						Name = "Copy",
						Icon = (PathGeometry)_iconDictionary["Copy"]
					},
					new SubMenuItemDetails()
					{
						Name = "Cut",
						Icon = (PathGeometry)_iconDictionary["Cut"]
					},
					new SubMenuItemDetails()
					{
						Name = "Paste",
						Icon = (PathGeometry)_iconDictionary["Paste"]
					},
					new SubMenuItemDetails()
					{
						Name = "Delete",
						Icon = (PathGeometry)_iconDictionary["Delete"]
					},
					new SubMenuItemDetails()
					{
						Name = "Rename",
						Icon = (PathGeometry)_iconDictionary["Rename"]
					},
					new SubMenuItemDetails()
					{
						Name = "New Folder",
						Icon = (PathGeometry)_iconDictionary["NewFolder"]
					},
					new SubMenuItemDetails()
					{
						Name = "Properties",
						Icon = (PathGeometry)_iconDictionary["FileSettings"]
					},
				};

				ViewTabSubMenuCollection = new ObservableCollection<SubMenuItemDetails>
				{
					new SubMenuItemDetails()
					{
						Name = "List",
						Icon = (PathGeometry)_iconDictionary["ListView"]
					},
					new SubMenuItemDetails()
					{
						Name = "Tile",
						Icon = (PathGeometry)_iconDictionary["TileView"]
					}
				};
			}));

		protected ICommand _getFilesListCommand;
		public ICommand GetFilesListCommand => _getFilesListCommand ??
			(_getFilesListCommand = new RelayCommand(parameter =>
			{
				var file = parameter as FileDetailsModel;
				if (file == null) return;

				LoadDirectory(file);
			}));

		protected ICommand _getFilesSizeCommand;
		public ICommand GetFilesSizeCommand => _getFilesSizeCommand ??
			(_getFilesSizeCommand = new RelayCommand(parameter =>
			{
				var file = parameter as FileDetailsModel;
				if (file == null) return;

				//LoadDirectory(file);
				SelectedFolderDetails = "Calculating size...";
				OnPropertyChanged(nameof(SelectedFolderDetails));
				bgGetFilesSizeBackgroundWorker.DoWork -= BgGetFilesBackgroundWorker_DoWork;
				bgGetFilesSizeBackgroundWorker.DoWork += BgGetFilesBackgroundWorker_DoWork;

				bgGetFilesSizeBackgroundWorker.RunWorkerAsync();

				if (bgGetFilesSizeBackgroundWorker.IsBusy)
					bgGetFilesSizeBackgroundWorker.CancelAsync();
				
				if (bgGetFilesBackgroundWorker.CancellationPending)
				{ 
					bgGetFilesSizeBackgroundWorker.Dispose();
					bgGetFilesSizeBackgroundWorker = new BackgroundWorker()
					{
						WorkerSupportsCancellation = true
					};
				}
			}));

		#endregion
	}
}
