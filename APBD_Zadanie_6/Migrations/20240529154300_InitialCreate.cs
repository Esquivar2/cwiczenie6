﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_Zadanie_6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdMedicament_PK", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPatient_PK", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPrescription_PK", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Doctor_Prescription_FK",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "Patient_Prescription_FK",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescriptionMedicamend_PK", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Medicament_Prescription_FK",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament");
                    table.ForeignKey(
                        name: "Prescription_Medicament_FK",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription");
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "SampleDoctor@gmail.com", "Sample", "Doctor" },
                    { 2, "JakubBiologist@gmail.com", "Jakub", "Biologist" },
                    { 3, "MichalPediatrician@gmail.com", "Michal", "Pediatrician" },
                    { 4, "SergioPsychiatrist@gmail.com", "Sergio", "Psychiatrist" },
                    { 5, "PabloAnesthesiologist@gmail.com", "Pablo", "Anesthesiologist" },
                    { 6, "AzucarDiabetes@gmail.com", "Azucar", "Diabetes" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Painkiller, 200mg 3 times a day.", "Ibuprofène", "Anti inflamatory pills" },
                    { 2, "From 10 to 1000 times a day.", "Happyness", "Anti sadness pills" },
                    { 3, "CAN HARM YOUR HEALTH.", "Sadness", "Anti happyness pills" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6517), "Jakub", "Nowak" },
                    { 2, new DateTime(2003, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6575), "Michal", "Kowalski" },
                    { 3, new DateTime(1997, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6579), "Patient", "Patientowich" },
                    { 4, new DateTime(2002, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6584), "Sergio", "Kotowich" },
                    { 5, new DateTime(1974, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6588), "Ala", "Peronska" },
                    { 6, new DateTime(1995, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6593), "Kot", "Zygmund" },
                    { 7, new DateTime(1970, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6596), "Natiel", "Patient" },
                    { 8, new DateTime(1957, 5, 29, 17, 43, 0, 816, DateTimeKind.Local).AddTicks(6600), "Jas", "Profase" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 29, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7742), new DateTime(2024, 6, 25, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7762), 1, 1 },
                    { 2, new DateTime(2024, 5, 29, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7770), new DateTime(2024, 7, 5, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7773), 2, 2 },
                    { 3, new DateTime(2024, 5, 29, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7776), new DateTime(2024, 6, 19, 17, 43, 0, 817, DateTimeKind.Local).AddTicks(7778), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "2 pills in am and pm", 200 },
                    { 2, 1, "2 pills in am and pm", 250 },
                    { 2, 2, "2 pills in am and pm", 250 },
                    { 3, 3, "2 pills in am and pm", 250 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
