using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorPatientAPI.Migrations
{
    public partial class UserTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2021, 5, 17, 1, 28, 20, 223, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2021, 5, 17, 1, 28, 20, 225, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2021, 5, 17, 1, 28, 20, 225, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(1076), new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4355), new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4367), new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4372), new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 5,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4377), new DateTime(2021, 5, 17, 1, 28, 20, 253, DateTimeKind.Local).AddTicks(4378) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2021, 5, 4, 3, 23, 24, 881, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2021, 5, 4, 3, 23, 24, 881, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2021, 5, 4, 3, 23, 24, 881, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(1566), new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3637), new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3643), new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3645), new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 5,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3648), new DateTime(2021, 5, 4, 3, 23, 24, 896, DateTimeKind.Local).AddTicks(3649) });
        }
    }
}
