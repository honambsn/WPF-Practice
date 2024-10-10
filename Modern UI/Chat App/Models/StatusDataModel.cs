using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.Models
{
	public class StatusDataModel
	{
		public string ContactName { get; set; }
		public Uri ContactPhoto { get; set; }
		public Uri StatusImage { get; set; }
		public bool IsMeAddStatus { get; set; }
	}
}
