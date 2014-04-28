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
		[Required]
		public string Name { get; set; }
		[Required]
		public string Type { get; set; }
		public string Description { get; set; }
		[DisplayName("File")]
		public string ServerPath { get; set; }
		public string ContentType { get; set; }

		[ForeignKey("Provider")]
		public int ProviderID { get; set; }
		public virtual Provider Provider { get; set; }

		public virtual ICollection<Subscription> Subscriptions { get; set; }
	}
}