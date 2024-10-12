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

	}
}