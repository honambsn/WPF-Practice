using Chat_App.CustomControls;
using Chat_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.ViewModels
{
	public class ViewModel
	{
		public ObservableCollection<StatusDataModel> statusThumbsCollection;
		public ViewModel()
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
					ContactPhoto=new Uri("/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/assets/img5.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
				new StatusDataModel
				{
					ContactName="Rosé",
					ContactPhoto=new Uri("/assets/img1.jpg", UriKind.RelativeOrAbsolute),
					StatusImage=new Uri("/assets/img5.jpg", UriKind.RelativeOrAbsolute),
					IsMeAddStatus=false
				},
			};
		}
	}
}
