// A program for performing database migrations for all services specified in the configuration file.

using System.IO;
using System.Reflection;
using System.Text;
using Cims.WorkflowLib.Extensions;
using DeliveryService.Utils.Common;

// Get the address to the following directories:
// 1) directory of this project,
// 2) the directory in which the configuration file is located,
// 2) the root directory of the entire delivery service project.
var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectPath = Path.Combine(assemblyPath, @"..\..\..");
var configPath = Path.Combine(projectPath, @"..");
var deliveryServicePath = Path.Combine(configPath, @"..");

// Ask the user what they would like to name the migration.
System.Console.WriteLine("Please enter the name of the migration: ");
var migrationName = System.Console.ReadLine();
if (String.IsNullOrEmpty(migrationName))
    throw new ArgumentException("Migration name could not be null or empty");

// Read the configuration file.
var projects = new JsonConfigExtensions().GetConfigSettings<Projects>(Path.Combine(configPath, "appconfig.json"), "projects");
var sb = new StringBuilder();

// Update migrations for all client projects.
foreach (var relativePath in projects.frontend)
{
    ExecuteCommand(sb, relativePath);
}

// Update migrations for all backend projects.
foreach (var relativePath in projects.backend)
{
    ExecuteCommand(sb, relativePath);
}

void ExecuteCommand(StringBuilder sb, string relativePath)
{
    sb.Clear();
    var path = Path.Combine(deliveryServicePath, relativePath);
    sb.Append("cd ").Append(path).Append(" && dotnet build && dotnet ef migrations add ").Append(migrationName);
    System.Console.WriteLine("- " + path);
    System.Console.WriteLine("  - " + sb.ToString());
}
