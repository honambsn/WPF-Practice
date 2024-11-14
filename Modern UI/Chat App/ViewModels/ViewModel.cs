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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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

		#region Search Chats
		protected bool _isSearchConversationBoxOpen;
		public bool IsSearchConversationBoxOpen
		{
			get => _isSearchConversationBoxOpen;
			set
			{
				if (_isSearchConversationBoxOpen == value)
					return;

				_isSearchConversationBoxOpen = value;

				if(!_isSearchConversationBoxOpen)
				{
					SearchConversationText = string.Empty;
				}
				OnPropertyChanged("IsSearchConversationBoxOpen");
				OnPropertyChanged("SearchConversationText");
			}
		}
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
		
		public void OpenConversationSearchBox()
		{
			IsSearchConversationBoxOpen = true;
		}

		public void ClearConversationSearchBox()
		{
			if (!string.IsNullOrEmpty(SearchConversationText))
				SearchConversationText = string.Empty;
			else CloseConversationSearchBox();
		}

		public void CloseConversationSearchBox() => IsSearchConversationBoxOpen = false;

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
		/// open search command
		/// </summary>
		protected ICommand _openConversationSearchCommand;
		public ICommand OpenConversationSearchCommand
		{
			get
			{
				if (_openConversationSearchCommand == null)
					_openConversationSearchCommand = new CommandViewModel(OpenConversationSearchBox);
				return _openConversationSearchCommand;
			}
			set
			{
				_openConversationSearchCommand = value;
			}
		}

		/// <summary>
		/// clear search command
		/// </summary>
		protected ICommand _clearConversationSearchCommand;
		public ICommand ClearConversationSearchCommand
		{
			get
			{
				if (_clearConversationSearchCommand == null)
					_clearConversationSearchCommand = new CommandViewModel(ClearConversationSearchBox);
				return _clearConversationSearchCommand;
			}
			set
			{
				_clearConversationSearchCommand = value;
			}
		}

		protected ICommand _closeConversationSearchCommand;
		public ICommand CloseConversationSearchCommand
		{
			get
			{
				if (_closeConversationSearchCommand == null)
					_closeConversationSearchCommand = new CommandViewModel(CloseConversationSearchBox);
				return _closeConversationSearchCommand;
			}
			set
			{
				_closeConversationSearchCommand = value;
			}
		}

		/// <summary>
		/// Search command
		/// </summary>
		protected ICommand _searchConversationCommand;
		public ICommand SearchConversationCommand
		{
			get
			{
				if (_searchConversationCommand == null)
					_searchConversationCommand = new CommandViewModel(SearchInConversation);
				return _searchConversationCommand;
			}

			set
			{
				_searchConversationCommand = value;
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

		protected ObservableCollection<ChatListData> _archivedChats;
		public ObservableCollection<ChatListData> ArchiveChats { get=> _archivedChats; set{
				_archivedChats = value;
				OnPropertyChanged();
			} }


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
					ContactName="Billy",
					ContactPhoto=new Uri("/Assets/assets/img2.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LastMessageTime="12:00",
					ChatIsSelected=true,
				},
				new ChatListData
				{
					ContactName="Mike",		
					ContactPhoto=new Uri("/Assets/assets/img4.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LastMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="Steve",
					ContactPhoto=new Uri("/Assets/assets/img6.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LastMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="John",
					ContactPhoto=new Uri("/Assets/assets/img9.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LastMessageTime="12:00"
				},
				new ChatListData
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/Assets/assets/img10.jpg", UriKind.RelativeOrAbsolute),
					Message="Hello",
					LastMessageTime="12:00"
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

				LoadChatConversation(v);
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
					v.ChatIsPinned = true;

					//remove selected chat from all chats / unpinned chats
					Chats.Remove(v);
					FilteredChats.Remove(v);
					OnPropertyChanged("Chats");
					OnPropertyChanged("FilteredChats");


					if(ArchiveChats != null)
					{
						if (!ArchiveChats.Contains(v))
						{
							ArchiveChats.Remove(v);
							v.ChatIsArchived = false;
						}
					}
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

					

					//remove selected unpinned chats
					PinnedChats.Remove(v);
					FilteredPinnedChats.Remove(v);
					OnPropertyChanged("PinnedChats");
					OnPropertyChanged("FilteredPinnedChats");
					v.ChatIsPinned = false;
				}
			}
		});

		/// <summary>
		/// archive chat command
		/// </summary>
		protected ICommand _archiveChatCommand;
		public ICommand ArchiveChatCommand => _archiveChatCommand ??= new RelayCommand(parameter =>
		{
			if ( parameter is ChatListData v)
			{
				if (!ArchiveChats.Contains(v))
				{

					//remove chat from pinned & unpinned chat list
					//Chats.Remove(v);
					//FilteredChats.Remove(v);

					//PinnedChats.Remove(v);
					//FilteredPinnedChats.Remove(v);

					//add chat in archive list
					ArchiveChats.Add(v);
					v.ChatIsArchived = true;
					v.ChatIsPinned = false;

					//remove chat from pinned & unpinned chat list
					Chats.Remove(v);
					FilteredChats.Remove(v);

					PinnedChats.Remove(v);
					FilteredPinnedChats.Remove(v);

					//update lists
					OnPropertyChanged("Chats");
					OnPropertyChanged("FilteredChats");
					OnPropertyChanged("PinnedChats");
					OnPropertyChanged("FilteredPinnedChats");
					OnPropertyChanged("ArchiveChats");
				}
			}
		});


		/// <summary>
		/// unarchive chat command
		/// </summary>
		protected ICommand _UnArchiveChatCommand;
		public ICommand UnArchiveChatCommand => _UnArchiveChatCommand ??= new RelayCommand(parameter =>
		{
			if (parameter is ChatListData v)
			{
				//if (!FilteredChats.Contains(v) && !Chats.Contains(v))
				//{
				//	Chats.Add(v);
				//	FilteredChats.Add(v);
				//}
				////add chat in archive list
				//ArchiveChats.Remove(v);
				//v.ChatIsArchived = false;
				//v.ChatIsPinned = false;

				//OnPropertyChanged("Chats");
				//OnPropertyChanged("FilteredChats");
				//OnPropertyChanged("ArchivedChats");
				if (!FilteredChats.Contains(v))
				{
					//add selected chat to normal unpinned chat list
					Chats.Add(v);
					FilteredChats.Add(v);
					OnPropertyChanged("Chats");
					OnPropertyChanged("FilteredChats");

					//remove selected unpinned chats
					PinnedChats.Remove(v);
					FilteredPinnedChats.Remove(v);
					OnPropertyChanged("PinnedChats");
					OnPropertyChanged("FilteredPinnedChats");
					v.ChatIsPinned = false;
				}
			}
		});

		#endregion


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

		protected bool _isConversationSearchBoxOpen;
		public bool IsConversationSearchBoxOpen
		{
			get => _isConversationSearchBoxOpen;
			set
			{
				if (_isConversationSearchBoxOpen == value)
					return;

				_isConversationSearchBoxOpen = value;

				if (!_isConversationSearchBoxOpen)
				{
					//SearchConversationText = string.Empty;
					SearchConversationText = string.Empty;
				}
				OnPropertyChanged("IsConversationSearchBoxOpen");
				//OnPropertyChanged("SearchConversationText");
				OnPropertyChanged("SearchConversationText");
			}
		}

		protected ObservableCollection<ChatConversation> mConversations;
		
		public ObservableCollection<ChatConversation> Conversations
		{
			get => mConversations;
			set
			{
				if (mConversations == value)
					return;

				mConversations = value;

				FilteredConversations = new ObservableCollection<ChatConversation>(mConversations);
				OnPropertyChanged("Conversations");
				OnPropertyChanged("FilteredConversations");
			}
		}

		/// <summary>
		/// filterd conversation
		/// </summary>
		public ObservableCollection<ChatConversation> FilteredConversations { get; set; }

		protected string LastSearchConversationText;
		protected string mSearchConversationText;
		public string SearchConversationText
		{
			get => mSearchConversationText;

			set
			{
				if (mSearchConversationText == value)
					return;

				mSearchConversationText = value;

				if (string.IsNullOrEmpty(mSearchConversationText))
					SearchInConversation();
			}
		}

		#endregion

		#region Logics
		void LoadChatConversation(ChatListData chat)
		{
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
			if(Conversations == null)
			{
				Conversations = new ObservableCollection<ChatConversation>();
			}

			Conversations.Clear();
			FilteredConversations.Clear();

			using (SqlCommand com = new SqlCommand("select * from conversations where ContactName=@ContactName", connection))
			{
				com.Parameters.AddWithValue("@ContactName", chat.ContactName);
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

						FilteredConversations.Add(conversation);
						OnPropertyChanged("FilteredConversations");

					}
				}
			}
		}

		void SearchInConversation()
		{
			if (string.IsNullOrEmpty(LastSearchConversationText) && string.IsNullOrEmpty(SearchConversationText) || string.Equals(LastSearchConversationText, SearchConversationText))
				return;

			if (string.IsNullOrEmpty(SearchConversationText) || Conversations == null || Conversations.Count <= 0)
			{
				FilteredConversations = new ObservableCollection<ChatConversation>(Conversations ?? Enumerable.Empty<ChatConversation>());
				OnPropertyChanged("FilteredConversations");

				//update last search textx
				LastSearchConversationText = SearchConversationText;
				return;
			}

			FilteredConversations = new ObservableCollection<ChatConversation>(
				Conversations.Where(
					chat => chat.ReceivedMessage.ToLower().Contains(SearchConversationText)
					|| chat.SentMessage.ToLower().Contains(SearchConversationText)
					));
			OnPropertyChanged("FilteredConversations");


			
			LastSearchConversationText = SearchConversationText;
		}
		#endregion


		#endregion
		SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Ba Nam\Own project\Practice\c#\WPF Practice\Modern UI\Chat App\Database\chatdb.mdf"";Integrated Security=True;Connect Timeout=30");
		public ViewModel()
		{
			LoadStatusThumbs();
			LoadChats();
			//LoadChatConversation();
			PinnedChats = new ObservableCollection<ChatListData>();
			ArchiveChats = new ObservableCollection<ChatListData>();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	
}
