using Chat_App.CustomControls;
using Chat_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.ViewModels
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region status thumbs
		#region Properties
		public ObservableCollection<StatusDataModel> statusThumbsCollection { get; set; }
		#endregion


		#region Logics
		void LoadStatusThumbs()
		{
			statusThumbsCollection = new ObservableCollection<StatusDataModel>()
			{
				new StatusDataModel
				{
					IsMeAddStatus=true
				},
				new StatusDataModel
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/Assets/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
				new StatusDataModel
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/Assets/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
				new StatusDataModel
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/Assets/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
				new StatusDataModel
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/Assets/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
			};
			OnPropertyChanged("statusThumbsCollection");
		}
		#endregion

		#endregion

		#region Chats List
		#region Properties
		public ObservableCollection<ChatListData> Chats { get; set; }
		#endregion

		#region Logics
		void LoadChats()
		{
			Chats = new ObservableCollection<ChatListData>()
			{
				new ChatListData
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/Assets/assets/img2.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LatestMessageTime="12:00",
					ChatIsSelected=true,
				},
				new ChatListData
				{
					ContactName="Rosé",		
					ContactPhoto=new Uri("/Assets/assets/img4.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LatestMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/Assets/assets/img6.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LatestMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/Assets/assets/img9.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LatestMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/Assets/assets/img10.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LatestMessageTime="12:00"
				},
			};
			OnPropertyChanged("Chats");
		}
		#endregion
		#endregion
		public ViewModel()
		{
			LoadStatusThumbs();
			LoadChats();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
