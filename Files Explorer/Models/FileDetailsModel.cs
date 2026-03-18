using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Files_Explorer.Models
{
	public class FileDetailsModel : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public PathGeometry FileIcon { get; set; }
		public string FileExtension { get; set; }
		public string FileSize { get; set; }
		public string CreateOn { get; set; }
		public string DateModified { get; set; }
		public string AccessedOn { get; set; }
		public bool IsDirectory { get; set; }
		public bool IsReadOnly { get; set; }
		public bool IsHidden { get; set; }
		public bool IsImage { get; set; }
		public bool IsVideo { get; set; }
		public bool IsSelected { get; set; }
		private bool _isPinned;
		internal string CreatedOn;

		public bool IsPinned
		{
			get => _isPinned;
			set
			{
				if (_isPinned != value)
				{
					_isPinned = value;
					OnPropertyChanged(nameof(IsPinned));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		internal string _Type { get; set; }
		public string Type => _Type = IsDirectory ? "Folder" : "File";
		
	}
}
