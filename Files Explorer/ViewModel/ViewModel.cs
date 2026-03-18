using Files_Explorer.Commands;
using Files_Explorer.Models;
using Files_Explorer.Views;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
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
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using SearchOption = System.IO.SearchOption;



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
		public string NewFolderName { get; set; }
		public bool IsListView { get; set; }
		public string DriveSize { get; set; }
		public bool IsInSearchMode { get; set; }

		public ObservableCollection<FileDetailsModel> FavoriteFolders { get; set; }
		public ObservableCollection<FileDetailsModel> RemoteFolders { get; set; }
		public ObservableCollection<FileDetailsModel> LibraryFolders { get; set; }
		public ObservableCollection<FileDetailsModel> ConnectedDevices { get; set; }
		public ObservableCollection<FileDetailsModel> NavigatedFolderFiles { get; set; }
		public ObservableCollection<SubMenuItemDetails> HomeTabSubMenuCollection { get; set; }
		public ObservableCollection<SubMenuItemDetails> ViewTabSubMenuCollection { get; set; }
		public ObservableCollection<FileDetailsModel> ClipBoardCollection { get; set; }
		public ObservableCollection<string> PathHistoryCollection { get; set; }
		internal int position = 0;
		public bool CanGoBack { get; set; }
		public bool CanGoFoward { get; set; }
		public bool IsAtRootDirectory { get; set; }
		public bool IsMoveOperation { get; set; }
		internal bool _pathDisrupted;
		public bool PathDisrupted
		{
			get => _pathDisrupted;
			set
			{
				_pathDisrupted = value;
				if (_pathDisrupted)
				{
					var tempCollection = new ObservableCollection<string>();
					for (int i = position; i < PathHistoryCollection.Count - 1; i++)
					{
						tempCollection.Add(PathHistoryCollection[i]);
					}

					foreach (var path in tempCollection)
					{
						PathHistoryCollection.Remove(path);
					}
					OnPropertyChanged(nameof(PathHistoryCollection));
					_pathDisrupted = false;
				}
			}
		}

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
			catch (DirectoryNotFoundException)
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

			if ((PathGeometry)_iconDictionary[$"{fileExtension}File"] == null)
				return (PathGeometry)_iconDictionary["File"];

			return (PathGeometry)_iconDictionary[$"{fileExtension}File"];

		}

		void LoadDirectory(FileDetailsModel fileDetailsModel)
		{
			CanGoBack = position != 0;
			OnPropertyChanged(nameof(CanGoBack));

			// updatee the UI on the UI thread
			Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				NavigatedFolderFiles.Clear();
			}), DispatcherPriority.DataBind);

			tempFolderCollection = null;

			DriveSize = CalculateSize(new DriveInfo(fileDetailsModel.Path).TotalSize);
			OnPropertyChanged(nameof(DriveSize));

			if (PathHistoryCollection != null && position > 0)
			{
				if (PathHistoryCollection.ElementAt(position) != fileDetailsModel.Path)
				{
					PathDisrupted = true;
				}
			}

			if (bgGetFilesBackgroundWorker.IsBusy)
				bgGetFilesBackgroundWorker.CancelAsync();

			bgGetFilesBackgroundWorker.RunWorkerAsync(fileDetailsModel);
		}


		//void LoadDirectory(FileDetailsModel fileDetailsModel)
		//{
		//	CanGoBack = position != 0;
		//	OnPropertyChanged(nameof(CanGoBack));

		//	NavigatedFolderFiles.Clear();
		//	tempFolderCollection = null;

		//	if (PathHistoryCollection != null && position > 0)
		//	{
		//		if (PathHistoryCollection.ElementAt(position) != fileDetailsModel.Path)
		//		{
		//			PathDisrupted = true;
		//		}
		//	}

		//	if (bgGetFilesBackgroundWorker.IsBusy)
		//		bgGetFilesBackgroundWorker.CancelAsync();

		//	bgGetFilesBackgroundWorker.RunWorkerAsync(fileDetailsModel);
		//}
		private void BgGetFilesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var fileOrFolder = (FileDetailsModel)e.Argument;

			tempFolderCollection =
				new ReadOnlyCollectionBuilder<string>(Directory.GetDirectories(fileOrFolder.Path)
				.Concat(Directory.GetFiles(fileOrFolder.Path))).ToReadOnlyCollection();

			foreach (var filename in tempFolderCollection)
				bgGetFilesBackgroundWorker.ReportProgress(1, filename);

			CurrentDirectory = fileOrFolder.Path;
			OnPropertyChanged(nameof(CurrentDirectory));

			var root = Path.GetPathRoot(fileOrFolder.Path);
			if (string.IsNullOrWhiteSpace(CurrentDirectory)
				|| CurrentDirectory == root)
			{
				IsAtRootDirectory = true;
				OnPropertyChanged(nameof(IsAtRootDirectory));
			}
			else
			{
				IsAtRootDirectory = false;
				OnPropertyChanged(nameof(IsAtRootDirectory));
			}
		}

		private void BgGetFilesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			var fileName = e.UserState.ToString();
			var file = new FileDetailsModel();
			file.Name = Path.GetFileName(fileName);
			file.Path = fileName;
			file.CreatedOn = GetCreatedOn(fileName);
			file.DateModified = GetDateModified(fileName);
			file.DateModified = GetLastAccessedOn(fileName);
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
			foreach (var file in NavigatedFolderFiles)
			{
				var subWorker = new BackgroundWorker();
				subWorker.DoWork += (o, args) =>
				{
					file.IsReadOnly = IsFileReadOnly(file.Path);
				};
				subWorker.RunWorkerCompleted += (o, args) =>
				{
					subWorker.Dispose();
					CollectionViewSource.GetDefaultView(NavigatedFolderFiles).Refresh();
				};
				subWorker.RunWorkerAsync();
			}
		}

		internal BackgroundWorker bgGetFoundFilesWorker = new BackgroundWorker()
		{
			WorkerSupportsCancellation = true,
			WorkerReportsProgress = true
		};
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
				if (FileSystem.DirectoryExists(directoryPath))
				{
					var d = new DirectoryInfo(directoryPath);
					return d.EnumerateFiles("*", System.IO.SearchOption.AllDirectories).Sum(fi => fi.Length);
				}

				return new FileInfo(directoryPath).Length;
			}
			catch (UnauthorizedAccessException)
			{
				return 0;
			}
			catch (FileNotFoundException)
			{
				return 0;
			}
			catch (DirectoryNotFoundException)
			{
				return 0;
			}
		}

		private void BgGetFilesSizeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var FileSize = NavigatedFolderFiles.Where(File => File.IsSelected && !File.IsDirectory)
				.Sum(x => new FileInfo(x.Path).Length);


			SelectedFolderDetails = CalculateSize(FileSize);
			OnPropertyChanged(nameof(SelectedFolderDetails));

			var Directories = NavigatedFolderFiles.Where(directory => directory.IsSelected && directory.IsDirectory);
			try
			{
				foreach (var directory in Directories)
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

		internal void UpdatePathHistory(string path)
		{
			if (PathHistoryCollection != null && !string.IsNullOrEmpty(path))
			{
				PathHistoryCollection.Add(path);
				position++;
				OnPropertyChanged(nameof(PathHistoryCollection));
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
				Path = CurrentDirectory

			});

			PathHistoryCollection = new ObservableCollection<string>();
			PathHistoryCollection.Add(CurrentDirectory);

			CanGoBack = position != 0;
			OnPropertyChanged(nameof(CanGoBack));
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

				SelectedFolderDetails = string.Empty;
				OnPropertyChanged(nameof(SelectedFolderDetails));

				if (Directory.Exists(file.Path))
				{
					UpdatePathHistory(file.Path);
					LoadDirectory(file);
				}
				else
				{
					try
					{
						Process.Start(new ProcessStartInfo(file.Path));
					}
					catch (Win32Exception w3Ex)
					{
						MessageBox.Show(w3Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						//MessageBox.Show("The file cannot be opened.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					catch (InvalidOperationException iOEx)
					{
						//	MessageBox.Show(iOEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						MessageBox.Show($"{file.Name} cannot be opened.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}

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

		protected ICommand _goToPreviousDirectoryCommand;
		public ICommand GoToPreviousDirectoryCommand => _goToPreviousDirectoryCommand ??
			(_goToPreviousDirectoryCommand = new Command(() =>
			{
				if (position >= 1)
				{
					position--;
					LoadDirectory(new FileDetailsModel()
					{
						Path = PathHistoryCollection.ElementAt(position)
					});

					CanGoFoward = true;
					OnPropertyChanged(nameof(CanGoFoward));

					PathDisrupted = false;
					OnPropertyChanged(nameof(PathDisrupted));
				}

			}));

		protected ICommand _goToFowardDirectoryCommand;
		public ICommand GoToFowardDirectoryCommand => _goToFowardDirectoryCommand ??
			(_goToFowardDirectoryCommand = new Command(() =>
			{
				if (position < PathHistoryCollection.Count - 1)
				{
					position++;
					LoadDirectory(new FileDetailsModel()
					{
						Path = PathHistoryCollection.ElementAt(position)
					});

					CanGoFoward =
						position < PathHistoryCollection.Count - 1 &&
						position != PathHistoryCollection.Count - 1;
					OnPropertyChanged(nameof(CanGoFoward));

					//PathDisrupted = false;
					//OnPropertyChanged(nameof(PathDisrupted));
				}
			}));

		protected ICommand _goToParentDirectoryCommand;
		public ICommand GoToParentDirectoryCommand => _goToParentDirectoryCommand ??
			(_goToParentDirectoryCommand = new Command(() =>
			{
				var ParentDirectory = string.Empty;
				PathDisrupted = true;

				var d = new DirectoryInfo(CurrentDirectory);

				if (d.Parent != null)
				{
					ParentDirectory = d.Parent.FullName;
					IsAtRootDirectory = false;
					OnPropertyChanged(nameof(IsAtRootDirectory));
				}
				else if (d.Root == null)
				{
					IsAtRootDirectory = true;
					OnPropertyChanged(nameof(IsAtRootDirectory));
					return;
				}
				else
				{
					ParentDirectory = d.Root.ToString()
					.Split(Path.DirectorySeparatorChar)[1];
				}

				GetFilesListCommand.Execute(new FileDetailsModel()
				{
					Path = ParentDirectory
				});
			}));

		protected ICommand _navigateToPathCommand;
		public ICommand NavigateToPathCommand => _navigateToPathCommand ??
			(_navigateToPathCommand = new RelayCommand((parameter) =>
			{
				var path = parameter as string;
				if (!string.IsNullOrEmpty(path))
					GetFilesListCommand.Execute(new FileDetailsModel()
					{
						Path = path
					});

				//if (Directory.Exists(path))
				//{
				//	UpdatePathHistory(path);
				//	LoadDirectory(new FileDetailsModel()
				//	{
				//		Path = path
				//	});
				//}
				//else
				//{
				//	MessageBox.Show("The path does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				//}
			}));

		internal void PinFolder()
		{
			if (FavoriteFolders == null)
				FavoriteFolders = new ObservableCollection<FileDetailsModel>();

			try
			{
				var selectedFile =
					NavigatedFolderFiles
					.Where(folder => folder.IsSelected && !folder.IsPinned && folder.IsDirectory);

				foreach (var directory in selectedFile)
				{
					directory.IsPinned = true;
					FavoriteFolders.Add(directory);
				}

				OnPropertyChanged(nameof(FavoriteFolders));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		internal void CopyFolder()
		{
			if (ClipBoardCollection == null)
				ClipBoardCollection = new ObservableCollection<FileDetailsModel>();
			var selectedFile =
				NavigatedFolderFiles
				.Where(file => file.IsSelected && !file.IsDirectory);
			foreach (var file in selectedFile)
			{
				if (!ClipBoardCollection.Contains(file))
					ClipBoardCollection.Add(file);
			}

			OnPropertyChanged(nameof(ClipBoardCollection));
			IsMoveOperation = false;
		}

		internal void CutFolder()
		{
			if (ClipBoardCollection == null)
				ClipBoardCollection = new ObservableCollection<FileDetailsModel>();

			ClipBoardCollection.Clear();

			var selectedFile =
				NavigatedFolderFiles
				.Where(file => file.IsSelected && file.IsSelected);

			foreach (var file in selectedFile)
			{
				if (!ClipBoardCollection.Contains(file))
					ClipBoardCollection.Add(file);
			}

			OnPropertyChanged(nameof(ClipBoardCollection));
			IsMoveOperation = true;
		}

		internal void Paste(bool IsMoveOperation)
		{
			if (ClipBoardCollection != null && ClipBoardCollection.Count > 0)
			{
				var destinationPath = CurrentDirectory;
				if (!IsMoveOperation)
				{
					foreach (var file in ClipBoardCollection)
					{
						var sourcePath = file.Path;
						var desPath = CurrentDirectory + "\\" + file.Name;
						desPath = Path.Combine(sourcePath, desPath);
						var temp = Path.GetExtension(file.Path);

						if (string.IsNullOrWhiteSpace(temp))
							Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(file.Path, desPath, UIOption.AllDialogs, UICancelOption.DoNothing);
						else
						{
							Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(file.Path, desPath, UIOption.AllDialogs, UICancelOption.DoNothing);
						}
					}
				}
				else
				{
					foreach (var file in ClipBoardCollection)
					{
						var sourcePath = file.Path;
						var desPath = CurrentDirectory + "\\" + file.Name;
						desPath = Path.Combine(sourcePath, desPath);
						var temp = Path.GetExtension(file.Path);

						if (string.IsNullOrWhiteSpace(temp))
							Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(file.Path, desPath, UIOption.AllDialogs, UICancelOption.DoNothing);
						else
						{
							Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(file.Path, desPath, UIOption.AllDialogs, UICancelOption.DoNothing);
						}
					}
				}

				LoadDirectory(new FileDetailsModel()
				{
					Path = destinationPath
				});
				IsMoveOperation = false;
			}
		}

		internal void Delete(bool IsMoveOperation)
		{
			var selectedFile =
				NavigatedFolderFiles
				.Where(file => file.IsSelected);

			if (selectedFile.Count() > 1)
			{
				if (MessageBoxResult.Yes == MessageBox.Show($"Are u sure you want to delete {selectedFile.Count()} files?", "Delete multiple items", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No))
				{
					foreach (var file in selectedFile)
					{
						try
						{
							if (string.IsNullOrWhiteSpace(Path.GetExtension(file.Path)))
							{
								Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(file.Path ?? String.Empty, UIOption.OnlyErrorDialogs,
									RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
							}
							else
							{
								Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(file.Path, UIOption.OnlyErrorDialogs,
									RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						}
					}
				}
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(selectedFile.ElementAt(0).Path))
				{
					Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(selectedFile.ElementAt(0).Path, UIOption.OnlyErrorDialogs,
						RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
				}
				else
				{
					Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(selectedFile.ElementAt(0).Path, UIOption.OnlyErrorDialogs,
						RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
				}
				LoadDirectory(new FileDetailsModel()
				{
					Path = CurrentDirectory
				});
			}
		}

		internal void RenameFolder()
		{
			var selectedFiles = new ObservableCollection<FileDetailsModel>(NavigatedFolderFiles.Where(x => x.IsSelected));

			foreach (var file in selectedFiles)
			{
				if (file.IsSelected)
				{
				restart:
					try
					{
						new RenameDialog()
						{
							DataContext = this,
							Owner = Application.Current.MainWindow,
							ShowActivated = true,
							ShowInTaskbar = false,
							Topmost = true,
							OldFolderName = $"Remaining: {file.Name}",

						}.ShowDialog();

						if (!string.IsNullOrWhiteSpace(NewFolderName))
						{
							if (file.IsDirectory)
								Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(file.Path, NewFolderName);
							else
								Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(file.Path, $"{NewFolderName}.{file.FileExtension.ToLower()}");

							file.Name = NewFolderName;
							file.IsSelected = false;

							NavigatedFolderFiles.Remove(file);
							OnPropertyChanged(nameof(NavigatedFolderFiles));

							NavigatedFolderFiles.Add(file);
							OnPropertyChanged(nameof(NavigatedFolderFiles));

							NewFolderName = string.Empty;
							OnPropertyChanged(nameof(NewFolderName));
						}
					}
					catch (UnauthorizedAccessException)
					{
						goto restart;
					}
					catch (Exception ex)
					{
						//MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						MessageBox.Show(ex.Message, ex.Source);
					}
				}
			}
		}

		internal void CreateNewFolder()
		{
			CreateNewFolderCommand.Execute(null);
		}

		internal static string GetCreatedOn(string path)
		{
			try
			{
				if (FileSystem.DirectoryExists(path))
				{
					return $"{FileSystem.GetDirectoryInfo(path).CreationTime.ToShortDateString()} {FileSystem.GetDirectoryInfo(path).CreationTime.ToShortTimeString()}";
				}
				return $"{FileSystem.GetFileInfo(path).CreationTime.ToShortDateString()} {FileSystem.GetFileInfo(path).CreationTime.ToShortTimeString()}";
			}
			catch (UnauthorizedAccessException)
			{
				return String.Empty;
			}
			catch (FileNotFoundException)
			{
				return String.Empty;
			}
			catch (DirectoryNotFoundException)
			{
				return String.Empty;
			}
		}

		internal static string GetDateModified(string path)
		{
			try
			{
				if (FileSystem.DirectoryExists(path))
				{
					return $"{FileSystem.GetDirectoryInfo(path).LastWriteTime.ToShortDateString()} {FileSystem.GetDirectoryInfo(path).LastWriteTime.ToShortTimeString()}";
				}
				return $"{FileSystem.GetFileInfo(path).LastWriteTime.ToShortDateString()} {FileSystem.GetFileInfo(path).LastWriteTime.ToShortTimeString()}";
			}
			catch (UnauthorizedAccessException)
			{
				return String.Empty;
			}
			catch (FileNotFoundException)
			{
				return String.Empty;
			}
			catch (DirectoryNotFoundException)
			{
				return String.Empty;
			}
		}

		internal static string GetLastAccessedOn(string path)
		{
			try
			{
				if (FileSystem.DirectoryExists(path))
				{
					return $"{FileSystem.GetDirectoryInfo(path).LastAccessTime.ToShortDateString()} {FileSystem.GetDirectoryInfo(path).LastAccessTime.ToShortTimeString()}";
				}
				return $"{FileSystem.GetFileInfo(path).LastAccessTime.ToShortDateString()} {FileSystem.GetFileInfo(path).LastAccessTime.ToShortTimeString()}";
			}
			catch (UnauthorizedAccessException)
			{
				return String.Empty;
			}
			catch (FileNotFoundException)
			{
				return String.Empty;
			}
			catch (DirectoryNotFoundException)
			{
				return String.Empty;
			}
		}

		internal void ShowProperties()
		{
			if (NavigatedFolderFiles.Count(file => file.IsSelected) == 1)
			{
				var f = NavigatedFolderFiles.Where(file => file.IsSelected).ToArray();

				new PropertiesDialog()
				{
					FileName = f[0].Name,
					Icon = f[0].FileIcon,
					FileExtension = f[0].FileExtension,
					FullPath = f[0].Path,
					FileSize = CalculateSize(GetDirectorySize(f[0].Path)),
					CreatedOn = GetCreatedOn(f[0].Path),
					DateModified = GetDateModified(f[0].Path),
					AccessedOn = GetLastAccessedOn(f[0].Path),
					IsReadOnly = f[0].IsReadOnly,
					IsHidden = f[0].IsHidden,
					Owner = Application.Current.MainWindow,
					ShowInTaskbar = false,
					Topmost = true
				}.ShowDialog();

			}
		}

		protected ICommand _unpinFavoriteFolderCommand;
		public ICommand UnPinFavoriteFolderCommand => _unpinFavoriteFolderCommand ??
			(_unpinFavoriteFolderCommand = new RelayCommand((parameter) =>
			{
				var folder = parameter as FileDetailsModel;
				if (folder == null) return;

				folder.IsPinned = false;
				FavoriteFolders.Remove(folder);
				OnPropertyChanged(nameof(FavoriteFolders));
			}));

		protected ICommand _subMenuFileOperationCommand;
		public ICommand SubMenuFileOperationCommand => _subMenuFileOperationCommand ??
			(_subMenuFileOperationCommand = new RelayCommand((parameter) =>
			{
				var subMenuItem = parameter as SubMenuItemDetails;
				if (subMenuItem == null) return;

				try
				{
					switch (subMenuItem.Name)
					{
						case "Pin":
							PinFolder();
							break;
						case "Copy":
							CopyFolder();
							break;
						case "Cut":
							CutFolder();
							break;
						case "Paste":
							Paste(IsMoveOperation);
							break;
						case "Delete":
							Delete(IsMoveOperation);
							break;
						case "Rename":
							RenameFolder();
							break;
						case "New Folder":
							CreateNewFolder();
							break;
						case "Properties":
							ShowProperties();
							break;
						case "List":
							IsListView = true;
							OnPropertyChanged(nameof(IsListView));
							break;
						case "Tile":
							break;
						default:
							return;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}));




		//protected ICommand _createNewFolderCommand;
		//public ICommand CreateNewFolderCommand => _createNewFolderCommand ??
		//	(_createNewFolderCommand = new Command(() =>
		//	{
		//		try
		//		{
		//			// Deselect previously selected folders
		//			foreach (var folder in NavigatedFolderFiles.Where(f => f.IsSelected))
		//			{
		//				folder.IsSelected = false;
		//			}

		//			OnPropertyChanged(nameof(NavigatedFolderFiles));

		//			// Count existing "New Folder" directories to create a unique name
		//			var i = Directory.GetDirectories(CurrentDirectory)
		//				.Count(x => x.Contains("New Folder"));

		//			// Construct new folder path
		//			var path = i == 0
		//				? Path.Combine(CurrentDirectory, "New Folder")
		//				: Path.Combine(CurrentDirectory, $"New Folder{i}");

		//			// Create the directory
		//			Directory.CreateDirectory(path);

		//			// Create a new FileDetailsModel for the new folder
		//			var file = new FileDetailsModel();
		//			file.Name = Path.GetFileName(path);  // Get the folder name, not the directory part
		//			file.Path = path;
		//			file.IsDirectory = true;
		//			file.FileExtension = string.Empty;
		//			file.IsImage = false;
		//			file.IsVideo = false;
		//			file.FileIcon = GetImageForExtension(file);  // Assuming this method gets the icon
		//			file.IsSelected = true;

		//			// Add the new folder to the collection
		//			NavigatedFolderFiles.Add(file);
		//			OnPropertyChanged(nameof(NavigatedFolderFiles));

		//			// Optionally call RenameFolder if needed
		//			// RenameFolder();
		//		}
		//		catch (Exception ex)
		//		{
		//			// Show a detailed error message
		//			MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		//		}

		//	}));

		protected ICommand _createNewFolderCommand;
		public ICommand CreateNewFolderCommand => _createNewFolderCommand ??
			(_createNewFolderCommand = new Command(() =>
			{
				try
				{
					// De-select previously selected folders
					foreach (var folder in NavigatedFolderFiles.Where(f => f.IsSelected))
					{
						folder.IsSelected = false;
					}

					// Defer PropertyChanged using Dispatcher
					Application.Current.Dispatcher.BeginInvoke(
						new Action(() =>
						{
							// Notify UI after the list changes
							OnPropertyChanged(nameof(NavigatedFolderFiles));
						}),
						DispatcherPriority.Background);  // Background priority for the change

					// Count existing "New Folder" directories to create a unique name
					var i = Directory.GetDirectories(CurrentDirectory)
						.Count(x => x.Contains("New Folder"));

					// Construct new folder path
					var path = i == 0
						? Path.Combine(CurrentDirectory, "New Folder")
						: Path.Combine(CurrentDirectory, $"New Folder{i}");

					// Create the directory
					Directory.CreateDirectory(path);

					// Create a new FileDetailsModel for the new folder
					var file = new FileDetailsModel();
					file.Name = Path.GetFileName(path);
					file.Path = path;
					file.IsDirectory = true;
					file.FileExtension = string.Empty;
					file.IsImage = false;
					file.IsVideo = false;
					file.FileIcon = GetImageForExtension(file);
					file.IsSelected = true;


					// Add the new folder to the collection
					Application.Current.Dispatcher.BeginInvoke(
						new Action(() =>
						{
							NavigatedFolderFiles.Add(file);
							OnPropertyChanged(nameof(NavigatedFolderFiles));  // Notify UI once
						}),
						DispatcherPriority.Background);

					RenameFolder();
				}
				catch (Exception ex)
				{
					// Show a detailed error message
					MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}));

		public ICommand _SortFilesCommand;
		private bool SortedByAcending { get; set; }
		public string SortedBy { get; set; }
		public ICommand SortFilesCommand => _SortFilesCommand ??
			(_SortFilesCommand = new RelayCommand((parameter) =>
			{
				var header = parameter as GridViewColumnHeader;
				if (header == null || string.IsNullOrWhiteSpace(header.Content.ToString())) return;

				SortedByAcending = !SortedByAcending;
				OnPropertyChanged(nameof(SortedByAcending));

				CollectionViewSource.GetDefaultView(NavigatedFolderFiles).SortDescriptions.Clear();

				if (SortedByAcending)
				{
					CollectionViewSource.GetDefaultView(NavigatedFolderFiles)
					.SortDescriptions.Add(new SortDescription(header.Content.ToString().Replace(" ", ""), ListSortDirection.Descending));

				}
				else
				{
					CollectionViewSource.GetDefaultView(NavigatedFolderFiles)
					.SortDescriptions
					.Add(new SortDescription(header.Content.ToString().Replace(" ", ""),
					ListSortDirection.Ascending));
				}
				SortedBy = (string)header.Content;
				OnPropertyChanged(nameof(SortedBy));
			}));

		
		internal static IEnumerable<string> EnumerateDirectories(string parentDirectory, string searchPattern, System.IO.SearchOption searchOption)
		{
			
			try
			{
				var directories = new List<string>();
				if (searchOption == SearchOption.AllDirectories)
					directories = (List<string>)Directory.EnumerateDirectories(parentDirectory)
						.SelectMany(x => EnumerateDirectories(x, searchPattern, searchOption));

				return directories.Concat(Directory.EnumerateDirectories(parentDirectory, searchPattern));

			}
			catch (UnauthorizedAccessException)
			{
				return Enumerable.Empty<string>();
			}
			catch (DirectoryNotFoundException)
			{
				return Enumerable.Empty<string>();
			}
			catch(FileNotFoundException)
			{
				return Enumerable.Empty<string>();
			}
			
		}
		internal static IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.SearchOption searchOption)
		{

			try
			{
				var dirFiles = Enumerable.Empty<string>();
				if (searchOption == SearchOption.AllDirectories)
					dirFiles = Directory.EnumerateFiles(path)
						.SelectMany(x => EnumerateFiles(x, searchPattern, searchOption));


				return dirFiles.Concat(Directory.EnumerateDirectories(path, searchPattern));

			}
			catch (UnauthorizedAccessException)
			{
				return Enumerable.Empty<string>();
			}
			catch (DirectoryNotFoundException)
			{
				return Enumerable.Empty<string>();
			}
			catch (FileNotFoundException)
			{
				return Enumerable.Empty<string>();
			}

		}
		protected ICommand _searchFileFolderCommands;
		public ICommand SearchFileOrFolderCommand => _searchFileFolderCommands ??
			(_searchFileFolderCommands = new RelayCommand((parameter) =>
			{
				var searchQuery = parameter as string;
				if (string.IsNullOrWhiteSpace(searchQuery)) return;

				NavigatedFolderFiles.Clear();

				if (bgGetFilesBackgroundWorker != null && bgGetFoundFilesWorker.IsBusy)
					bgGetFoundFilesWorker.CancelAsync();


				bgGetFoundFilesWorker.DoWork += (o, args) =>
				{
					try
					{
						IsInSearchMode = false;
						OnPropertyChanged(nameof(IsInSearchMode));
						var directories = EnumerateDirectories(CurrentDirectory, searchQuery, SearchOption.AllDirectories);

						foreach (var directory in directories)
						{
							bgGetFoundFilesWorker.ReportProgress(1, directory);
						}

						var files = EnumerateFiles(CurrentDirectory, searchQuery, SearchOption.AllDirectories);

						foreach(var file in files)
						{
							bgGetFoundFilesWorker.ReportProgress(1, file);
						}
					}
					catch (UnauthorizedAccessException)
					{

					}
				};

				bgGetFoundFilesWorker.ProgressChanged += BgGetFilesBackgroundWorker_ProgressChanged;
				bgGetFoundFilesWorker.RunWorkerCompleted += BgGetFilesBackgroundWorker_RunWorkerCompleted;

				if (!bgGetFoundFilesWorker.IsBusy)
					bgGetFoundFilesWorker.RunWorkerAsync();
			}));

		protected ICommand _cancelSearchFileOrFolderCommand;
		public ICommand CancelSearchFileOrFolderCommand => _cancelSearchFileOrFolderCommand ??
			(_cancelSearchFileOrFolderCommand = new Command(() =>
			{
				if (bgGetFilesBackgroundWorker.IsBusy)
					bgGetFilesBackgroundWorker.CancelAsync();

				if (bgGetFoundFilesWorker.CancellationPending)
					bgGetFoundFilesWorker.Dispose();

				IsInSearchMode = false;
				OnPropertyChanged(nameof(IsInSearchMode));
			}));
			

		#endregion
	}
}
