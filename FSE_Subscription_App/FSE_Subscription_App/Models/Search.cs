using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSE_Subscription_App.Models
{
	public class SubHubSearch
	{
		public List<Subscription> SubscriptionResults { get; set; }
		public List<Provider> ProviderResults { get; set; }

		public SubHubSearch()
		{
			SubscriptionResults = new List<Subscription>();
			ProviderResults = new List<Provider>();
		}

		public void query(List<Subscription> subs, List<Provider> provs, string query)
		{
			SubscriptionResults.Clear();
			ProviderResults.Clear();

			query = query.ToLower();

			SubscriptionResults.AddRange(subs.Where(s => s.SubscriptionName.ToLower().Contains(query)).ToList());
			SubscriptionResults.AddRange(subs.Where(s => s.Description.ToLower().Contains(query)).ToList());

			ProviderResults.AddRange(provs.Where(p => p.CompanyName.ToLower().Contains(query)).ToList());

			SubscriptionResults = SubscriptionResults.Distinct().ToList();
			ProviderResults = ProviderResults.Distinct().ToList();
		}
	}
}