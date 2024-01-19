using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryService.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    RoomNumber = table.Column<string>(type: "text", nullable: true),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    StreetNumber = table.Column<string>(type: "text", nullable: true),
                    StreetName = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CountryProvince = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    HomePhone = table.Column<string>(type: "text", nullable: true),
                    WorkPhone = table.Column<string>(type: "text", nullable: true),
                    OfficePhone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    OfficeEmail = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractType = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    WorkPhone = table.Column<string>(type: "text", nullable: true),
                    Skype = table.Column<string>(type: "text", nullable: true),
                    ICQ = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReplacementMode = table.Column<int>(type: "integer", nullable: false),
                    AuthProviderType = table.Column<int>(type: "integer", nullable: false),
                    Locale = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: false),
                    TitleText = table.Column<string>(type: "text", nullable: true),
                    BodyText = table.Column<string>(type: "text", nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReceivedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    PictureDescription = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlanItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ProjectPlanItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlanItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlanItem_ProjectPlanItem_ProjectPlanItemId",
                        column: x => x.ProjectPlanItemId,
                        principalTable: "ProjectPlanItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    VatNumber = table.Column<string>(type: "text", nullable: true),
                    CRMRoleType = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    ShippingAddressId = table.Column<long>(type: "bigint", nullable: true),
                    HasVatRegistration = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractEmployee",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    OurEmployeesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmployee", x => new { x.ContractsId, x.OurEmployeesId });
                    table.ForeignKey(
                        name: "FK_ContractEmployee_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEmployee_Employees_OurEmployeesId",
                        column: x => x.OurEmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    PictureDescription = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyContract",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerCompaniesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContract", x => new { x.ContractsId, x.CustomerCompaniesId });
                    table.ForeignKey(
                        name: "FK_CompanyContract_Companies_CustomerCompaniesId",
                        column: x => x.CustomerCompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContract_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    CompaniesId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => new { x.CompaniesId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Instruction = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WHProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    MinQuantity = table.Column<int>(type: "integer", nullable: false),
                    MaxQuantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WHProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientProductId = table.Column<long>(type: "bigint", nullable: true),
                    FinalProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    RecipeId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_FinalProductId",
                        column: x => x.FinalProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_IngredientProductId",
                        column: x => x.IngredientProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractCustomer",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    CustomersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCustomer", x => new { x.ContractsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_ContractCustomer_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractOrganization",
                columns: table => new
                {
                    ContractsId = table.Column<long>(type: "bigint", nullable: false),
                    OurOrganizationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractOrganization", x => new { x.ContractsId, x.OurOrganizationsId });
                    table.ForeignKey(
                        name: "FK_ContractOrganization_Contract_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    CRMRoleType = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GuaranteePeriodInMonths = table.Column<int>(type: "integer", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: true),
                    CompletePercent = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Addresses_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectPlanItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPhase_ProjectPlanItem_ProjectPlanItemId",
                        column: x => x.ProjectPlanItemId,
                        principalTable: "ProjectPlanItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: true),
                    OpenOrderDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CloseOrderDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ParentOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerUid = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    OrderCustomerType = table.Column<int>(type: "integer", nullable: true),
                    ExecutorUid = table.Column<string>(type: "text", nullable: true),
                    ExecutorName = table.Column<string>(type: "text", nullable: true),
                    OrderExecutorType = table.Column<int>(type: "integer", nullable: true),
                    ProductsPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    AdditonalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CouldBeCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ParentDeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    OriginId = table.Column<long>(type: "bigint", nullable: true),
                    DestinationId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Orders_ParentDeliveryOrderId",
                        column: x => x.ParentDeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Orders_ParentOrderId",
                        column: x => x.ParentOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payer = table.Column<string>(type: "text", nullable: true),
                    Receiver = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductTransfers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WHProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessOperationId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OldQuantity = table.Column<double>(type: "double precision", nullable: true),
                    NewQuantity = table.Column<double>(type: "double precision", nullable: false),
                    QuantityDelta = table.Column<double>(type: "double precision", nullable: false),
                    OldStatus = table.Column<string>(type: "text", nullable: true),
                    NewStatus = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTransfers_DeliveryOrderProducts_DeliveryOrderProduct~",
                        column: x => x.DeliveryOrderProductId,
                        principalTable: "DeliveryOrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_ProductTransfers_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductTransfers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTransfers_WHProducts_WHProductId",
                        column: x => x.WHProductId,
                        principalTable: "WHProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTaskDeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTaskDeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTaskDeliveryOrders_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: true),
                    ActualExecutionTimeId = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedExecutionTimeId = table.Column<long>(type: "bigint", nullable: true),
                    ExecutorId = table.Column<long>(type: "bigint", nullable: true),
                    ExecutorIsEmulationId = table.Column<long>(type: "bigint", nullable: true),
                    ExecutorReplacedId = table.Column<long>(type: "bigint", nullable: true),
                    ExpiredNotificationSent = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmulation = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    OrderNumber = table.Column<string>(type: "text", nullable: true),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: true),
                    OriginId = table.Column<long>(type: "bigint", nullable: true),
                    DestinationId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    GeneratedOrderQrCode = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Addresses_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Addresses_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_BusinessTasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_ExecutionTime_ActualExecutionTimeId",
                        column: x => x.ActualExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_ExecutionTime_EstimatedExecutionTimeId",
                        column: x => x.EstimatedExecutionTimeId,
                        principalTable: "ExecutionTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTasks_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserUid = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryKitchen2WhId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_DeliveryKitchen2WhId",
                        column: x => x.DeliveryKitchen2WhId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrders_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrders_Orders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    ResolvingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResolvingAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    ResolvingComment = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risk_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employees_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employees_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Employees_ResolvingAuthorId",
                        column: x => x.ResolvingAuthorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialOrderProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryKitchen2WhId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_DeliveryKitchen2WhId",
                        column: x => x.DeliveryKitchen2WhId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InitialOrderIngredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderId = table.Column<long>(type: "bigint", nullable: true),
                    InitialOrderProductId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CookingOperationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryWh2KitchenId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialOrderIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_BusinessTasks_CookingOperationId",
                        column: x => x.CookingOperationId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_BusinessTasks_DeliveryWh2KitchenId",
                        column: x => x.DeliveryWh2KitchenId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_InitialOrderProducts_InitialOrderPr~",
                        column: x => x.InitialOrderProductId,
                        principalTable: "InitialOrderProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InitialOrderIngredients_InitialOrders_InitialOrderId",
                        column: x => x.InitialOrderId,
                        principalTable: "InitialOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessTaskId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemType = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    HardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ParentItemId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationItems_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationItems_OrganizationItems_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    HeadItemId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationItems_HeadItemId",
                        column: x => x.HeadItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastSeenDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationItemId = table.Column<long>(type: "bigint", nullable: true),
                    UserGroupId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                        column: x => x.OrganizationItemId,
                        principalTable: "OrganizationItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsGroupByDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystem = table.Column<bool>(type: "boolean", nullable: false),
                    CreationAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeAuthorId = table.Column<long>(type: "bigint", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BusinessEntityStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                        column: x => x.ChangeAuthorId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                        column: x => x.CreationAuthorId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_BusinessTaskId",
                table: "BusinessTaskDeliveryOrders",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTaskDeliveryOrders_DeliveryOrderId",
                table: "BusinessTaskDeliveryOrders",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ActualExecutionTimeId",
                table: "BusinessTasks",
                column: "ActualExecutionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ContactId",
                table: "BusinessTasks",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DeliveryMethodId",
                table: "BusinessTasks",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DeliveryOrderId",
                table: "BusinessTasks",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_DestinationId",
                table: "BusinessTasks",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_EstimatedExecutionTimeId",
                table: "BusinessTasks",
                column: "EstimatedExecutionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ExecutorId",
                table: "BusinessTasks",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ExecutorIsEmulationId",
                table: "BusinessTasks",
                column: "ExecutorIsEmulationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ExecutorReplacedId",
                table: "BusinessTasks",
                column: "ExecutorReplacedId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_OriginId",
                table: "BusinessTasks",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTasks_ParentTaskId",
                table: "BusinessTasks",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BusinessTaskId",
                table: "Comments",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ContactId",
                table: "Companies",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ShippingAddressId",
                table: "Companies",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContract_CustomerCompaniesId",
                table: "CompanyContract",
                column: "CustomerCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeesId",
                table: "CompanyEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCustomer_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEmployee_OurEmployeesId",
                table: "ContractEmployee",
                column: "OurEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractOrganization_OurOrganizationsId",
                table: "ContractOrganization",
                column: "OurOrganizationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserAccountId",
                table: "Customers",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderProducts_ProductId",
                table: "DeliveryOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FinalProductId",
                table: "Ingredients",
                column: "FinalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientProductId",
                table: "Ingredients",
                column: "IngredientProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_CookingOperationId",
                table: "InitialOrderIngredients",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_DeliveryWh2KitchenId",
                table: "InitialOrderIngredients",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_IngredientId",
                table: "InitialOrderIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_InitialOrderId",
                table: "InitialOrderIngredients",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderIngredients_InitialOrderProductId",
                table: "InitialOrderIngredients",
                column: "InitialOrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_CookingOperationId",
                table: "InitialOrderProducts",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryKitchen2WhId",
                table: "InitialOrderProducts",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_DeliveryWh2KitchenId",
                table: "InitialOrderProducts",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_InitialOrderId",
                table: "InitialOrderProducts",
                column: "InitialOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrderProducts_ProductId",
                table: "InitialOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_CookingOperationId",
                table: "InitialOrders",
                column: "CookingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryKitchen2WhId",
                table: "InitialOrders",
                column: "DeliveryKitchen2WhId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryOrderId",
                table: "InitialOrders",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialOrders_DeliveryWh2KitchenId",
                table: "InitialOrders",
                column: "DeliveryWh2KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryOperationId",
                table: "Orders",
                column: "DeliveryOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DestinationId",
                table: "Orders",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OriginId",
                table: "Orders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentDeliveryOrderId",
                table: "Orders",
                column: "ParentDeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentOrderId",
                table: "Orders",
                column: "ParentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_AddressId",
                table: "OrganizationItems",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_ParentItemId",
                table: "OrganizationItems",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationItems_UserId",
                table: "OrganizationItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_HeadItemId",
                table: "Organizations",
                column: "HeadItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_DeliveryOrderId",
                table: "ProductTransfers",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_DeliveryOrderProductId",
                table: "ProductTransfers",
                column: "DeliveryOrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_OrderId",
                table: "ProductTransfers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_OrderProductId",
                table: "ProductTransfers",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_ParentId",
                table: "ProductTransfers",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_WHProductId",
                table: "ProductTransfers",
                column: "WHProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ContractId",
                table: "Project",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LocationId",
                table: "Project",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ProjectId",
                table: "ProjectPhase",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ProjectPlanItemId",
                table: "ProjectPhase",
                column: "ProjectPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlanItem_ProjectPlanItemId",
                table: "ProjectPlanItem",
                column: "ProjectPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProductId",
                table: "Recipes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_BusinessTaskId",
                table: "Risk",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ChangeAuthorId",
                table: "Risk",
                column: "ChangeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_CreationAuthorId",
                table: "Risk",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ProjectId",
                table: "Risk",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ResolvingAuthorId",
                table: "Risk",
                column: "ResolvingAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_EmployeeId",
                table: "Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_EmployeeId",
                table: "UserAccounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_OrganizationItemId",
                table: "UserAccounts",
                column: "OrganizationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_ChangeAuthorId",
                table: "UserGroups",
                column: "ChangeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_CreationAuthorId",
                table: "UserGroups",
                column: "CreationAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WHProducts_ProductId",
                table: "WHProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCustomer_Customers_CustomersId",
                table: "ContractCustomer",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractOrganization_Organizations_OurOrganizationsId",
                table: "ContractOrganization",
                column: "OurOrganizationsId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserAccounts_UserAccountId",
                table: "Customers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrderProducts_Orders_DeliveryOrderId",
                table: "DeliveryOrderProducts",
                column: "DeliveryOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BusinessTasks_DeliveryOperationId",
                table: "Orders",
                column: "DeliveryOperationId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTaskDeliveryOrders_BusinessTasks_BusinessTaskId",
                table: "BusinessTaskDeliveryOrders",
                column: "BusinessTaskId",
                principalTable: "BusinessTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorId",
                table: "BusinessTasks",
                column: "ExecutorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorIsEmulationId",
                table: "BusinessTasks",
                column: "ExecutorIsEmulationId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTasks_UserAccounts_ExecutorReplacedId",
                table: "BusinessTasks",
                column: "ExecutorReplacedId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserAccounts_CreationAuthorId",
                table: "Comments",
                column: "CreationAuthorId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationItems_UserAccounts_UserId",
                table: "OrganizationItems",
                column: "UserId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserGroups_UserGroupId",
                table: "UserAccounts",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BusinessTasks_DeliveryOperationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationItems_Addresses_AddressId",
                table: "OrganizationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Employees_EmployeeId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_OrganizationItems_OrganizationItemId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_ChangeAuthorId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_UserAccounts_CreationAuthorId",
                table: "UserGroups");

            migrationBuilder.DropTable(
                name: "BusinessTaskDeliveryOrders");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CompanyContract");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "ContractCustomer");

            migrationBuilder.DropTable(
                name: "ContractEmployee");

            migrationBuilder.DropTable(
                name: "ContractOrganization");

            migrationBuilder.DropTable(
                name: "InitialOrderIngredients");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductTransfers");

            migrationBuilder.DropTable(
                name: "ProjectPhase");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "InitialOrderProducts");

            migrationBuilder.DropTable(
                name: "DeliveryOrderProducts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "WHProducts");

            migrationBuilder.DropTable(
                name: "ProjectPlanItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "InitialOrders");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ExecutionTime");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrganizationItems");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
