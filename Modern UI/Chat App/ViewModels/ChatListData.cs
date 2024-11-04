using System;

namespace Chat_App.Models
{
	public class ChatListData
	{
		public string ContactName { get; set; }
		public Uri ContactPhoto { get; set; }
		public string Message { get; set; }
		public string LatestMessageTime { get; set; }
		public bool ChatIsSelected { get; set; }
		protected bool _chatIsPinned { get; set; }
		//public bool ChatIsPinned { get=>_chatIsPinned; set {
		//		_chatIsPinned = value;
		//} }
		public bool ChatIsPinned { get; set; }
	}
}