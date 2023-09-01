using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BASITWEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewRoomModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_roomId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "roomName",
                table: "Rooms",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Messages",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_roomId",
                table: "Messages",
                newName: "IX_Messages_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Rooms",
                newName: "roomName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Messages",
                newName: "roomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RoomId",
                table: "Messages",
                newName: "IX_Messages_roomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_roomId",
                table: "Messages",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "roomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
