using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSE_Subscription_App.Models;

namespace FSE_Subscription_App.Models
{
	public class Provider
	{
		public int ID { get; set; }
		public string CompanyName { get; set; }
		public string SiteLink { get; set; }

		public virtual ICollection<Content> Content { get; set; }
	}
}