using System.Data.Entity;

namespace FSE_Subscription_App.Models
{
    public class FSE_Subscription_AppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<FSE_Subscription_App.Models.FSE_Subscription_AppContext>());

        public FSE_Subscription_AppContext() : base("name=FSE_Subscription_AppContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
