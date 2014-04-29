using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSE_Subscription_App.Models
{
	public class Subscription : IComparable<Subscription>
	{
		public int ID { get; set; }
		[Required]
		[Display(Name = "Name")]
		public string SubscriptionName { get; set; }
		public string Description { get; set; }

		[ForeignKey("Provider")]
		public int ProviderID { get; set; }
		public virtual Provider Provider { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public double Price { get; set; }

		[Required]
		public int TimeCount { get; set; }

		[Required]
		public string TimeUnits { get; set; }

		public virtual ICollection<Content> Contents { get; set; }

		public TimeSpan GetDuration()
		{
			if (TimeUnits.Equals("Minute(s)"))
				return new TimeSpan(0, TimeCount, 0);
			else if (TimeUnits.Equals("Week(s)"))
				return new TimeSpan(TimeCount * 7, 0, 0, 0);
			else if (TimeUnits.Equals("Year(s)"))
				return new TimeSpan(TimeCount * 365, 0, 0, 0);
			else
				return new TimeSpan(0);
		}

		#region IComparable<Subscription> Members

		public int CompareTo(Subscription other)
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