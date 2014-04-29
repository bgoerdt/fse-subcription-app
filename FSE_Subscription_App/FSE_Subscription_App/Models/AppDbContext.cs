using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FSE_Subscription_App.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FSE_Subscription_App.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Provider> Providers { get; set; }
		public DbSet<Content> Content { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<UserSubscription> UserSubscriptions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}