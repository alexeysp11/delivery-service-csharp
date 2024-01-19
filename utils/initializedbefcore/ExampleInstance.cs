using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Utils.InitializeDbFfCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        
        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            DbContextOptions<DeliveringContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            ConfigureDbContext();
        }

        private void ConfigureDbContext()
        {
            ClearTables();
            AddUserAccounts();
            AddCustomers();
            AddCompanies();
            AddEmployees();
            AddContacts();
            AddWHProduct();
            AddIngredients();
            AddRecipes();
        }

        private void ClearTables()
        {
            using var context = new DeliveringContext(_contextOptions);

            // Do not clear the tables that are associated with UserAccounts here in code (e.g. Customers, Employees, UserGroups),
            // because it could lead to the circular dependency exception.
            // It is better to clear such tables directly using SQL queries.
            
            context.BusinessTasks.RemoveRange(context.BusinessTasks.ToList());
            context.Comments.RemoveRange(context.Comments.ToList());
            
            context.Orders.RemoveRange(context.Orders.ToList());
            context.OrderProducts.RemoveRange(context.OrderProducts.ToList());
            context.InitialOrders.RemoveRange(context.InitialOrders.ToList());
            context.InitialOrderProducts.RemoveRange(context.InitialOrderProducts.ToList());
            context.InitialOrderIngredients.RemoveRange(context.InitialOrderIngredients.ToList());
            context.DeliveryOrders.RemoveRange(context.DeliveryOrders.ToList());
            context.DeliveryOrderProducts.RemoveRange(context.DeliveryOrderProducts.ToList());
            context.BusinessTaskDeliveryOrders.RemoveRange(context.BusinessTaskDeliveryOrders.ToList());
            context.DeliveryMethods.RemoveRange(context.DeliveryMethods.ToList());
            context.Payments.RemoveRange(context.Payments.ToList());

            context.ProductCategories.RemoveRange(context.ProductCategories.ToList());
            context.Products.RemoveRange(context.Products.ToList());
            context.WHProducts.RemoveRange(context.WHProducts.ToList());
            context.Ingredients.RemoveRange(context.Ingredients.ToList());
            context.Recipes.RemoveRange(context.Recipes.ToList());
            context.ProductTransfers.RemoveRange(context.ProductTransfers.ToList());

            context.Notifications.RemoveRange(context.Notifications.ToList());
            
            context.DeliveriesWh2Kitchen.RemoveRange(context.DeliveriesWh2Kitchen.ToList());
            context.DeliveriesKitchen2Wh.RemoveRange(context.DeliveriesKitchen2Wh.ToList());
            context.DeliveryOperations.RemoveRange(context.DeliveryOperations.ToList());
            context.CookingOperations.RemoveRange(context.CookingOperations.ToList());

            context.SaveChanges();
        }

        private void AddUserAccounts()
        {
            using var context = new DeliveringContext(_contextOptions);
            if (context.UserAccounts.Count() != 0 || context.UserGroups.Count() != 0)
                return;
            
            for (int i = 1; i <= 30; i++)
            {
                context.UserAccounts.Add(new UserAccount
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Login = "login" + i,
                    Email = "user" + i + "@example.com",
                    PhoneNumber = "PhoneNumber" + i,
                    Password = "pswd" + i
                });
            }
            context.SaveChanges();

            // Establish associations between user accounts and user groups.
            // In order to evenly distribute the users across the groups, iteration through the names of user groups will be needed.
            // In the loop, get all the users that would be associated with the user group (pseudo randomly by indeces).
            var admin = context.UserAccounts.FirstOrDefault();
            var dtnow = System.DateTime.UtcNow;
            var userGroupNames = new List<string>
            {
                "tech support", 
                "customer", 
                "manager", 
                "courier",
                "warehouse employee",
                "kitchen employee"
            };
            var userGroupQty = userGroupNames.Count();
            for (int i = 0; i < userGroupQty; i++)
            {
                var users = context.UserAccounts.Where(x => x.Id % userGroupQty == i - 1).ToList();
                var userGroup = new UserGroup
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = userGroupNames[i],
                    Users = users,
                    CreationAuthor = admin,
                    CreationDate = dtnow,
                    ChangeAuthor = admin,
                    ChangeDate = dtnow
                };
                context.UserGroups.Add(userGroup);
            }
            context.SaveChanges();
        }

        private void AddCustomers()
        {
            using var context = new DeliveringContext(_contextOptions);
            if (context.Customers.Count() != 0)
                return;
            var usergroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "customer");
            foreach (var user in usergroup.Users)
            {
                var firstName = "FirstName" + user.Id;
                var middleName = "MiddleName" + user.Id;
                var lastName = "LastName" + user.Id;
                var fullName = $"{lastName}, {firstName} {middleName}";
                var customer = new Customer
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    FullName = fullName,
                    CRMRoleType = CRMRoleType.Client,
                    UserAccount = user
                };
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }

        private void AddCompanies()
        {
            using var context = new DeliveringContext(_contextOptions);
            if (context.Companies.Count() != 0 || context.Organizations.Count() != 0 || context.OrganizationItems.Count() != 0)
                return;
            
            // Companies.
            var address = new Address
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Address 1",
                Country = "Country1",
                CountryProvince = "CountryProvince1",
                City = "City1",
                PostalCode = "PostalCode1",
                StreetName = "StreetName1",
                StreetNumber = "StreetNumber1",
            };
            var company = new Company
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Our Company",
                RegistrationNumber = "RegistrationNumber",
                HasVatRegistration = true,
                VatNumber = "VatNumber", 
                CRMRoleType = CRMRoleType.Supplier,
                Address = address,
                ShippingAddress = address
            };
            context.Companies.Add(company);

            // Organization items.
            // Structure:
            // Level 1: head (job position)
            // Level 2: manager (job position)
            // Level 3: departments: couriers, tech support, kitchen employees (department)
            var managers = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "manager").Users;
            var lvl01 = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = $"Head of '{company.Name}'",
                ItemType = OrganizationItemType.JobPosition,
                User = managers.First(),
                Address = company.Address
            };
            context.OrganizationItems.Add(lvl01);
            var lvl02 = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = $"Manager of '{company.Name}'",
                ItemType = OrganizationItemType.JobPosition,
                User = managers.Last(),
                Address = company.Address,
                ParentItem = lvl01
            };
            context.OrganizationItems.Add(lvl02);
            var lvl03Couriers = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Couriers",
                ItemType = OrganizationItemType.Department,
                Users = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "courier").Users,
                Address = company.Address,
                ParentItem = lvl02
            };
            context.OrganizationItems.Add(lvl03Couriers);
            var lvl03TechSupport = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Tech support",
                ItemType = OrganizationItemType.Department,
                Users = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "tech support").Users,
                Address = company.Address,
                ParentItem = lvl02
            };
            context.OrganizationItems.Add(lvl03TechSupport);
            var lvl03Warehouse = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Warehouse employees",
                ItemType = OrganizationItemType.Department,
                Users = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "warehouse employee").Users,
                Address = company.Address,
                ParentItem = lvl02
            };
            context.OrganizationItems.Add(lvl03Warehouse);
            var lvl03Kitchen = new OrganizationItem
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Kitchen employees",
                ItemType = OrganizationItemType.Department,
                Users = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "kitchen employee").Users,
                Address = company.Address,
                ParentItem = lvl02
            };
            context.OrganizationItems.Add(lvl03Kitchen);

            // Organizations.
            var organization = new Organization
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = $"Organization '{company.Name}'",
                Company = company,
                HeadItem = lvl01
            };
            context.Organizations.Add(organization);

            context.SaveChanges();
        }

        private void AddEmployees()
        {
            using var context = new DeliveringContext(_contextOptions);
            if (context.Employees.Count() != 0)
                return;
            var rand = new System.Random();
            // Get all user groups that can be associated with a company.
            var usergroups = new List<UserGroup>();
            usergroups.Add(context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "manager"));
            usergroups.Add(context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "courier"));
            usergroups.Add(context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "tech support"));
            usergroups.Add(context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "warehouse employee"));
            usergroups.Add(context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "kitchen employee"));
            // In a loop for each user group, enumerate users.
            var company = context.Companies.FirstOrDefault();
            company.Employees = new List<Employee>();
            foreach (var ug in usergroups)
            {
                foreach (var user in ug.Users)
                {
                    // For each user initialize a company employee. 
                    var firstName = "FirstName" + user.Id;
                    var middleName = "MiddleName" + user.Id;
                    var lastName = "LastName" + user.Id;
                    var fullName = $"{firstName} {middleName} {lastName}";
                    var employee = new Employee
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName,
                        FullName = fullName,
                        MobilePhone = "MobilePhone" + user.Id,
                        WorkPhone = "WorkPhone" + user.Id,
                        BirthDate = System.DateTime.SpecifyKind(new System.DateTime(rand.Next(1980, 2004), rand.Next(1, 13), rand.Next(1, 28)), System.DateTimeKind.Utc),
                        EmployDate = System.DateTime.SpecifyKind(new System.DateTime(rand.Next(2018, 2023), rand.Next(1, 13), rand.Next(1, 28)), System.DateTimeKind.Utc),
                        UserAccounts = new List<UserAccount> { user },
                        Companies = new List<Company> { company },
                    };
                    context.Employees.Add(employee);
                }
            }
            context.SaveChanges();
        }

        private void AddContacts()
        {
            using var context = new DeliveringContext(_contextOptions);
            if (context.Contacts.Count() != 0)
                return;
            
            // Addresses would not be added now, because at this point we assume that they are associated only with companies.
            // All the necessary addresses are already added during initialization of organizations and companies.

            // Contacts.
            var customers = context.Customers.ToList();
            foreach (var customer in customers)
            {
                var contact = new Contact
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    MobilePhone = "MobilePhoneCustomer #" + customer.Id
                };
                customer.Contact = contact;
                context.Contacts.Add(contact);
            }
            var companies = context.Companies.ToList();
            foreach (var company in companies)
            {
                var contact = new Contact
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    WorkPhone = "WorkPhoneCompany #" + company.Id,
                    OfficePhone = "OfficePhoneCompany #" + company.Id,
                    Email = "EmailCompany #" + company.Id
                };
                company.Contact = contact;
                context.Contacts.Add(contact);
            }
            context.SaveChanges();
        }

        private void AddWHProduct()
        {
            using var context = new DeliveringContext(_contextOptions);
            var rand = new System.Random();

            var pcid = context.ProductCategories.Count() + 1;
            var productCategory = new ProductCategory
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product category " + pcid
            };
            context.ProductCategories.Add(productCategory);
            for (int i = 0; i < 3; i++)
                AddSingleWHProduct(context, rand, productCategory);
            context.SaveChanges();
        }

        private void AddSingleWHProduct(
            DeliveringContext context, 
            System.Random rand, 
            ProductCategory productCategory)
        {
            var pid = context.Products.Count() + 1;
            var whpid = context.WHProducts.Count() + 1;
            var product = new Product
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product " + pid,
                Price = rand.Next(12, 31),
                Quantity = 0,
                ProductCategory = productCategory
            };
            var whproduct = new WHProduct
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "WHProduct " + whpid,
                Product = product
            };
            context.Products.Add(product);
            context.WHProducts.Add(whproduct);
            context.SaveChanges();
        }

        private void AddIngredients()
        {
            using var context = new DeliveringContext(_contextOptions);
            var rand = new System.Random();

            var pcid = context.ProductCategories.Count() + 1;
            var productCategory = new ProductCategory
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product category " + pcid,
                Description = "Ingredients"
            };
            context.ProductCategories.Add(productCategory);
            var products = context.Products.Take(3).ToList();
            var finalProduct1 = products[0];
            var finalProduct2 = products[1];
            var finalProduct3 = products[2];
            if (finalProduct1 == null || finalProduct2 == null || finalProduct3 == null)
                throw new System.Exception("Final products is not initialized");
            AddSingleIngredient(context, rand, productCategory, finalProduct1);
            AddSingleIngredient(context, rand, productCategory, finalProduct1);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct3);
            context.SaveChanges();
        }

        private void AddSingleIngredient(
            DeliveringContext context, 
            System.Random rand, 
            ProductCategory productCategory, 
            Product finalProduct)
        {
            var pid = context.Products.Count() + 1;
            var whpid = context.WHProducts.Count() + 1;
            var product = new Product
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product " + pid,
                Price = rand.Next(2, 7),
                Quantity = 0,
                ProductCategory = productCategory
            };
            var ingredient = new Ingredient
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = product.Name,
                FinalProduct = finalProduct,
                IngredientProduct = product,
                Quantity = rand.Next(1, 4)
            };
            var whproduct = new WHProduct
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = "WHProduct " + whpid,
                Product = product,
                Quantity = rand.Next(1, 16),
                MinQuantity = rand.Next(3, 5),
                MaxQuantity = rand.Next(20, 46)
            };
            context.Ingredients.Add(ingredient);
            context.WHProducts.Add(whproduct);
            context.SaveChanges();
        }

        private void AddRecipes()
        {
            using var context = new DeliveringContext(_contextOptions);

            int recipeId = 1;
            var sbRecipeName = new StringBuilder();
            var sbInstruction = new StringBuilder();
            var ingredientIds = (from ingredient in context.Ingredients select ingredient.IngredientProduct.Id).ToList(); 
            foreach (var p in context.Products.Where(x => !ingredientIds.Any(i => i == x.Id)).ToList())
            {
                sbInstruction.Append("Instruction #").Append(recipeId.ToString());
                sbRecipeName.Append("Recipe of the product #").Append(p.Id.ToString()).Append(" ").Append(p.Name);
                var recipe = new Recipe
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = sbRecipeName.ToString(),
                    Product = p,
                    Ingredients = context.Ingredients.Where(x => x.FinalProduct != null && x.FinalProduct.Uid == p.Uid).ToList(),
                    Instruction = sbInstruction.ToString()
                };
                context.Recipes.Add(recipe);
                sbInstruction.Clear();
                sbRecipeName.Clear();
                recipeId += 1;
            }
            context.SaveChanges();
        }
    }
}