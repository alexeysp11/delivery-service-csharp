using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Cooking;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.SocialCommunication;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Models.Network.MicroserviceConfigurations;

namespace DeliveryService.Core.Contexts
{
    /// <summary>
    /// Database context that allows you to work with entities from the database and store them as regular collections.
    /// </summary>
    public class DeliveringContext : DbContext
    {
        public DeliveringContext(DbContextOptions<DeliveringContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationItem> OrganizationItems { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<BusinessTask> BusinessTasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<InitialOrder> InitialOrders { get; set; }
        public DbSet<InitialOrderProduct> InitialOrderProducts { get; set; }
        public DbSet<InitialOrderIngredient> InitialOrderIngredients { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<DeliveryOrderProduct> DeliveryOrderProducts { get; set; }
        public DbSet<BusinessTaskDeliveryOrder> BusinessTaskDeliveryOrders { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WHProduct> WHProducts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ProductTransfer> ProductTransfers { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<DeliveryWh2Kitchen> DeliveriesWh2Kitchen { get; set; }
        public DbSet<DeliveryKitchen2Wh> DeliveriesKitchen2Wh { get; set; }
        public DbSet<DeliveryOperation> DeliveryOperations { get; set; }
        public DbSet<CookingOperation> CookingOperations { get; set; }

        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<MicroserviceCommunicationConfiguration> MicroserviceCommunicationConfigurations { get; set; }
        public DbSet<NetworkInteractionDetails> NetworkInteractionDetails { get; set; }
    }
}