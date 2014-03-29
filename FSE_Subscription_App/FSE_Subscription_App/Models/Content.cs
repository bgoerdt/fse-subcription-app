using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FSE_Subscription_App.Models;

namespace FSE_Subscription_App.Models
{
	public class Content
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		private string _path { get; set; }

		[ForeignKey("Provider")]
		public int ProviderID { get; set; }
		public virtual Provider Provider { get; set; }

	}
}