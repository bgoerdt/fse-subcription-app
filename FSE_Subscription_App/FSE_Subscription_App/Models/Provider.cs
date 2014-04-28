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
	public class Provider
	{
		public int ID { get; set; }
		[Display(Name = "Company Name")]
		public string CompanyName { get; set; }
		[Display(Name = "Website")]
		public string SiteLink { get; set; }

		public virtual ICollection<Content> Content { get; set; }
	}
}