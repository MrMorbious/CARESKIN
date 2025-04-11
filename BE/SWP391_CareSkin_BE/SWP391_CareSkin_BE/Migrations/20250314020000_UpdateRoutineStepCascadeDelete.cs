using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_CareSkin_BE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoutineStepCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop existing foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineProduct_RoutineStep_RoutineStepId",
                table: "RoutineProduct");
                
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineStep_Routine_RoutineId",
                table: "RoutineStep");

            // Add the new foreign key with restrict delete
            migrationBuilder.AddForeignKey(
                name: "FK_RoutineProduct_RoutineStep_RoutineStepId",
                table: "RoutineProduct",
                column: "RoutineStepId",
                principalTable: "RoutineStep",
                principalColumn: "RoutineStepId",
                onDelete: ReferentialAction.Restrict);
                
            migrationBuilder.AddForeignKey(
                name: "FK_RoutineStep_Routine_RoutineId",
                table: "RoutineStep",
                column: "RoutineId",
                principalTable: "Routine",
                principalColumn: "RoutineId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the restrict delete foreign keys
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineProduct_RoutineStep_RoutineStepId",
                table: "RoutineProduct");
                
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineStep_Routine_RoutineId",
                table: "RoutineStep");

            // Add back the original foreign keys
            migrationBuilder.AddForeignKey(
                name: "FK_RoutineProduct_RoutineStep_RoutineStepId",
                table: "RoutineProduct",
                column: "RoutineStepId",
                principalTable: "RoutineStep",
                principalColumn: "RoutineStepId");
                
            migrationBuilder.AddForeignKey(
                name: "FK_RoutineStep_Routine_RoutineId",
                table: "RoutineStep",
                column: "RoutineId",
                principalTable: "Routine",
                principalColumn: "RoutineId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}