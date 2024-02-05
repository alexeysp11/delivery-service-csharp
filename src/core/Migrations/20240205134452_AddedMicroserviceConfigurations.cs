using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryService.Core.Migrations
{
    public partial class AddedMicroserviceConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    NetworkAddress = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetworkInteractionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ApiMethodName = table.Column<string>(type: "text", nullable: true),
                    MessageBrokerType = table.Column<int>(type: "integer", nullable: true),
                    QueueName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkInteractionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MicroserviceCommunicationConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EndpointFromId = table.Column<int>(type: "integer", nullable: true),
                    EndpointToId = table.Column<int>(type: "integer", nullable: true),
                    NetworkInteractionDetailsId = table.Column<int>(type: "integer", nullable: true),
                    TimeoutLimit = table.Column<int>(type: "integer", nullable: true),
                    AttemptsLimit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroserviceCommunicationConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MicroserviceCommunicationConfigurations_Endpoints_EndpointF~",
                        column: x => x.EndpointFromId,
                        principalTable: "Endpoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MicroserviceCommunicationConfigurations_Endpoints_EndpointT~",
                        column: x => x.EndpointToId,
                        principalTable: "Endpoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MicroserviceCommunicationConfigurations_NetworkInteractionD~",
                        column: x => x.NetworkInteractionDetailsId,
                        principalTable: "NetworkInteractionDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MicroserviceCommunicationConfigurations_EndpointFromId",
                table: "MicroserviceCommunicationConfigurations",
                column: "EndpointFromId");

            migrationBuilder.CreateIndex(
                name: "IX_MicroserviceCommunicationConfigurations_EndpointToId",
                table: "MicroserviceCommunicationConfigurations",
                column: "EndpointToId");

            migrationBuilder.CreateIndex(
                name: "IX_MicroserviceCommunicationConfigurations_NetworkInteractionD~",
                table: "MicroserviceCommunicationConfigurations",
                column: "NetworkInteractionDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MicroserviceCommunicationConfigurations");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "NetworkInteractionDetails");
        }
    }
}
