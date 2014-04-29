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
	public class Provider : IComparable<Provider>
	{
		public int ID { get; set; }
		[Display(Name = "Company Name")]
		public string CompanyName { get; set; }
		[Display(Name = "Website")]
		public string SiteLink { get; set; }

		public virtual ICollection<Content> Content { get; set; }

		#region IComparable<Provider> Members

		public int CompareTo(Provider other)
		{
			if (this.ID < other.ID)
				return -1;
			else if (this.ID == other.ID)
				return 0;
			else
				return 1;
		}

		#endregion
	}
}