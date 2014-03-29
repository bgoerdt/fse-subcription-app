using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSE_Subscription_App.Models
{
	public class Subscription
	{
		public int ID { get; set; }
		public string SubscriptionName { get; set; }
		public string Description { get; set; }

		[ForeignKey("Provider")]
		public int ProviderID { get; set; }
		public virtual Provider Provider { get; set; }

		public virtual ICollection<Content> Content { get; set; }
	}
}