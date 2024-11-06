using Chat_App.Commands;
using Chat_App.CustomControls;
using Chat_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
		
		# region Search Chats
		protected string LastSearchText { get; set; }
		protected string mSearchText { get; set; }
		public string SearchText
		{
			get => mSearchText;
			set
			{
				if (mSearchText == value)
					return;
				mSearchText = value;

				//if(string.IsNullOrEmpty(mSearchText))
				//{
				//	FilteredChats = new ObservableCollection<ChatListData>(Chats);
				//	FilteredPinnedChats = new ObservableCollection<ChatListData>(PinnedChats);
				//}
				//else
				//{
				//	FilteredChats = new ObservableCollection<ChatListData>(Chats.Where(x => x.ContactName.ToLower().Contains(mSearchText.ToLower())));
				//	FilteredPinnedChats = new ObservableCollection<ChatListData>(PinnedChats.Where(x => x.ContactName.ToLower().Contains(mSearchText.ToLower())));
				//}

				if (string.IsNullOrEmpty(SearchText))
					Search();
			}
		}

		#endregion

		#endregion

		#region Logics
		public void Search()
		{
			if (string.IsNullOrEmpty(LastSearchText) && string.IsNullOrEmpty(SearchText) || string.Equals(LastSearchText, SearchText))
				return;
			
			if(string.IsNullOrEmpty(SearchText) || Chats == null || Chats.Count <= 0)
			{
				FilteredChats = new ObservableCollection<ChatListData>(Chats ?? Enumerable.Empty<ChatListData>());
				OnPropertyChanged("FilteredChats");
				
				FilteredPinnedChats = new ObservableCollection<ChatListData>(PinnedChats ?? Enumerable.Empty<ChatListData>());
				OnPropertyChanged("FilteredPinnedChats");
				//update last search textx
				LastSearchText = SearchText;
				return;
			}

			FilteredChats = new ObservableCollection<ChatListData>(
				Chats.Where(
					chat => chat.ContactName.ToLower().Contains(SearchText)
					|| chat.Message != null && chat.Message.ToLower().Contains(SearchText)
					));
			OnPropertyChanged("FilteredChats");


			FilteredPinnedChats = new ObservableCollection<ChatListData>(
				PinnedChats.Where(
					pinnedchat => pinnedchat.ContactName.ToLower().Contains(SearchText)
					|| pinnedchat.Message != null && pinnedchat.Message.ToLower().Contains(SearchText)
					));
			OnPropertyChanged("FilteredPinnedChats");
			LastSearchText = SearchText;

			//FilteredChats = new ObservableCollection<ChatListData>(Chats.Where(chat => chat.ContactName.ToLower(SearchText) || ));
		}
		#endregion

		#region Commands
		/// <summary>
		/// Search command
		/// </summary>
		protected ICommand _searchCommand;
		public ICommand SearchCommand
		{
			get
			{
				if (_searchCommand == null)
					_searchCommand = new CommandViewModel(Search);
				return _searchCommand;
			}

			set
			{
				_searchCommand = value;
			}
		}
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
		public ObservableCollection<ChatListData> mChats;
		public ObservableCollection<ChatListData> mPinnedChats;
		public ObservableCollection<ChatListData> Chats
		{
			get => mChats;
			set
			{
				//change the list
				if (mChats == value)
					return;

				//Update the list
				mChats = value;

				//updating filtered chats to match
				FilteredChats = new ObservableCollection<ChatListData>(mChats);
				//OnPropertyChanged("Chats");
				//OnPropertyChanged("FilteredChats");
				OnPropertyChanged("Chats");
				OnPropertyChanged("FilteredChats");

			}

			
		}

		public ObservableCollection<ChatListData> PinnedChats
		{
			get => mPinnedChats;
			set
			{
				//change the list
				if (mPinnedChats == value)
					return;

				//Update the list
				mPinnedChats = value;

				//updating filtered chats to match
				FilteredPinnedChats = new ObservableCollection<ChatListData>(mPinnedChats);
				//OnPropertyChanged("PinnedChats");
				//OnPropertyChanged("FilteredPinnedChats");
				OnPropertyChanged("PinnedChats");
				OnPropertyChanged("FilteredPinnedChats");
			}

		}

		//Filtering Chat, pinned chat
		public ObservableCollection<ChatListData> FilteredChats { get; set; }
		public ObservableCollection<ChatListData> FilteredPinnedChats { get; set; }
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
			OnPropertyChanged();
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
			if (parameter is ChatListData v)
			{
				ContactName = v.ContactName;
				OnPropertyChanged("ContactName");
				ContactPhoto = v.ContactPhoto;
				OnPropertyChanged("ContactPhoto");
			}
		});


		//pin chat
		protected ICommand _pinChatCommand;
		public ICommand PinChatCommand => _pinChatCommand ??= new RelayCommand(parameter =>
		{
			
			if(parameter is ChatListData v)
			{
				if(!FilteredPinnedChats.Contains(v))
				{
					//add selected chat to pinned chat
					PinnedChats.Add(v);
					FilteredPinnedChats.Add(v);
					OnPropertyChanged("PinnedChats");
					OnPropertyChanged("FilteredPinnedChats");
					v.ChatIsPinned = false;

					//remove selected chat from all chats / unpinned chats
					Chats.Remove(v);
					FilteredChats.Remove(v);
					OnPropertyChanged("Chats");
					OnPropertyChanged("FilteredChats");

				}

			}
		});


		//pin chat
		protected ICommand _unPinChatCommand;
		public ICommand UnPinChatCommand => _unPinChatCommand ??= new RelayCommand(parameter =>
		{

			if (parameter is ChatListData v)
			{
				//if (PinnedChats == null)
				//{
				//	PinnedChats = new ObservableCollection<ChatListData>();
				//	FilteredPinnedChats = new ObservableCollection<ChatListData>();
				//}

				if (!FilteredChats.Contains(v))
				{
					//add selected chat to normal unpinned chat list
					Chats.Add(v);
					FilteredChats.Add(v);
					OnPropertyChanged("Chats");
					OnPropertyChanged("FilteredChats");

					//PinnedChats.Add(v);
					//FilteredPinnedChats.Add(v);

					//remove selected unpinned chats
					//Chats.Remove(v);
					//FilteredChats.Remove(v);
					PinnedChats.Remove(v);
					FilteredPinnedChats.Remove(v);
					OnPropertyChanged("PinnedChats");
					OnPropertyChanged("FilteredPinnedChats");
					v.ChatIsPinned = false;
				}
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
			PinnedChats = new ObservableCollection<ChatListData>();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	#endregion
}
