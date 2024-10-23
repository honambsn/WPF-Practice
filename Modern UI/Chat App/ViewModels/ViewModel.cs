using Chat_App.Commands;
using Chat_App.CustomControls;
using Chat_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat_App.ViewModels
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region MainWindow
		#region Properties
		public string ContactName { get; set; }
		public Uri ContactPhoto { get; set; }
		public string LatestSeen { get; set; }
		#endregion

		#endregion

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

		#region Commands
		//protected ICommand _getSelectedChatCommand;
		//public ICommand GetSelectedChatCommand => _getSelectedChatCommand ??= new RelayCommand(parameter =>
		//{

		//});

		protected ICommand _getSelectedChatCommand;
		public ICommand GetSelectedChatCommand => _getSelectedChatCommand ??= new RelayCommand(parameter =>
		{
			if(parameter is ChatListData v)
			{
				ContactName = v.ContactName;
				OnPropertyChanged("ContactName");
				ContactPhoto = v.ContactPhoto;
				OnPropertyChanged("ContactPhoto");
			}
		});

		protected string messageText;
		public string MessageText
		{
			get => messageText;
			set
			{
				messageText = value;
				OnPropertyChanged("MessageText");
			}
		}
		#endregion
		#endregion

		#region Converations
		#region Properties
		protected ObservableCollection<ChatConversation> mConversations;
		public ObservableCollection<ChatConversation> Conversations 
		{
			get => mConversations;
			set
			{
				mConversations = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Logics
		void LoadChatConversation()
		{
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
			if(Conversations == null)
			{
				Conversations = new ObservableCollection<ChatConversation>();
			}
			using (SqlCommand com = new SqlCommand("select * from conversations where ContactName='Mike'", connection))
			{
				using (SqlDataReader reader = com.ExecuteReader())
				{
					Conversations = new ObservableCollection<ChatConversation>();
					while (reader.Read())
					{
						//Conversation.Add(new ChatConversation
						//{
						//	ContactName = reader["ContactName"].ToString(),
						//	ReceivedMessage = reader["ReceivedMessage"].ToString(),
						//	SentMessage = reader["SentMessage"].ToString(),
						//	MsgSentOn = reader["MsgSentOn"].ToString(),
						//	IsMessageReceived = Convert.ToBoolean(reader["IsMessageReceived"]),
						//	MessageContainsReply = Convert.ToBoolean(reader["MessageContainsReply"])
						//});
						string MsgReceivedOn = !string.IsNullOrEmpty(reader["MsgReceivedOn"].ToString()) ? Convert.ToDateTime(reader["MsgReceivedOn"].ToString()).ToString("MMM dd, hh:mm tt") : "";

						string MsgSentOn = !string.IsNullOrEmpty(reader["MsgSentOn"].ToString()) ? Convert.ToDateTime(reader["MsgSentOn"].ToString()).ToString("MMM dd, hh:mm tt") : "";

						var conversation = new ChatConversation()
						{
							ContactName = reader["ContactName"].ToString(),
							ReceivedMessage = reader["ReceivedMsgs"].ToString(),
							//MsgReceivedOn = reader["MsgReceivedOn"].ToString(),
							MsgReceivedOn = MsgReceivedOn,
							SentMessage = reader["SentMsgs"].ToString(),
							//MsgSentOn = reader["MsgSentOn"].ToString(),
							MsgSentOn = MsgSentOn,
							IsMessageReceived = string.IsNullOrEmpty(reader["ReceivedMsgs"].ToString()) ? false : true
						};
						Conversations.Add(conversation);
						OnPropertyChanged("Conversations");
					}
				}
			}
		}
		#endregion

		#endregion
		SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Ba Nam\Own project\Practice\c#\WPF Practice\Modern UI\Chat App\Database\chatdb.mdf"";Integrated Security=True;Connect Timeout=30");
		public ViewModel()
		{
			LoadStatusThumbs();
			LoadChats();
			LoadChatConversation();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
