using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGameStore.Migrations
{
    public partial class CorrectedGenderDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    accountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASPuserId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.accountId);
                });

            migrationBuilder.CreateTable(
                name: "billingCountry",
                columns: table => new
                {
                    countryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    taxModifier = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billingCountry", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "cardType",
                columns: table => new
                {
                    cardTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardType = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardType", x => x.cardTypeId);
                });

            migrationBuilder.CreateTable(
                name: "friend",
                columns: table => new
                {
                    friendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    friendProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friend", x => x.friendId);
                });

            migrationBuilder.CreateTable(
                name: "gameGenre",
                columns: table => new
                {
                    gameGenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameGenre", x => x.gameGenreId);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    cartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.cartId);
                    table.ForeignKey(
                        name: "FK_cart_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false),
                    subTotal = table.Column<decimal>(type: "money", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    isProcessed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_order_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    profileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false),
                    profileName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    profileDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gender = table.Column<bool>(nullable: true),
                    favouriteGameCategory = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    favouritePlatform = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    paidOrFree = table.Column<bool>(nullable: true),
                    country = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    parentalCode = table.Column<string>(maxLength: 15, nullable: true),
                    phoneNumber = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.profileId);
                    table.ForeignKey(
                        name: "FK_profile_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wishList",
                columns: table => new
                {
                    wishListId = table.Column<int>(nullable: false),
                    isPublic = table.Column<bool>(nullable: false),
                    accountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishList", x => x.wishListId);
                    table.ForeignKey(
                        name: "FK_wishList_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "billingProvinceState",
                columns: table => new
                {
                    provinceStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "text", nullable: false),
                    taxModifier = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    countryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billingProvince", x => x.provinceStateId);
                    table.ForeignKey(
                        name: "FK_billingProvinceState_billingCountry",
                        column: x => x.countryId,
                        principalTable: "billingCountry",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "friendList",
                columns: table => new
                {
                    friendListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(nullable: false),
                    friendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendList", x => x.friendListId);
                    table.ForeignKey(
                        name: "FK_friendList_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friendList_friend",
                        column: x => x.friendId,
                        principalTable: "friend",
                        principalColumn: "friendId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    gameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gameDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gameDownloadLink = table.Column<string>(type: "xml", nullable: false),
                    gamePrice = table.Column<decimal>(type: "money", nullable: false),
                    gameDiscount = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gameGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.gameId);
                    table.ForeignKey(
                        name: "FK_game_gameGenre",
                        column: x => x.gameGenreId,
                        principalTable: "gameGenre",
                        principalColumn: "gameGenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "creditCard",
                columns: table => new
                {
                    creditId = table.Column<int>(nullable: false),
                    accountId = table.Column<int>(nullable: false),
                    cardTypeId = table.Column<int>(nullable: false),
                    cardNumber = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    cardCode = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    cardHolder = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    billingAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    billingPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    countryId = table.Column<int>(nullable: false),
                    provinceStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditCard", x => x.creditId);
                    table.ForeignKey(
                        name: "FK_creditCard_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_creditCard_cardType",
                        column: x => x.cardTypeId,
                        principalTable: "cardType",
                        principalColumn: "cardTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_creditCard_billingCountry",
                        column: x => x.countryId,
                        principalTable: "billingCountry",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_creditCard_billingProvinceState",
                        column: x => x.provinceStateId,
                        principalTable: "billingProvinceState",
                        principalColumn: "provinceStateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cartGame",
                columns: table => new
                {
                    cartGameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<int>(nullable: false),
                    gameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartGame", x => x.cartGameId);
                    table.ForeignKey(
                        name: "FK_cartGame_cart",
                        column: x => x.cartId,
                        principalTable: "cart",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cartGame_game",
                        column: x => x.gameId,
                        principalTable: "game",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    eventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(nullable: false),
                    eventTitle = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    eventDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.eventId);
                    table.ForeignKey(
                        name: "FK_event_game",
                        column: x => x.gameId,
                        principalTable: "game",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderItem",
                columns: table => new
                {
                    orderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(nullable: false),
                    orderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItem", x => x.orderItemId);
                    table.ForeignKey(
                        name: "FK_orderItem_game",
                        column: x => x.gameId,
                        principalTable: "game",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderItem_order",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    reviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(nullable: false),
                    profileId = table.Column<int>(nullable: false),
                    reviewTitle = table.Column<string>(type: "text", nullable: false),
                    reviewText = table.Column<string>(type: "text", nullable: false),
                    isRecommended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_review_game",
                        column: x => x.gameId,
                        principalTable: "game",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wishListItem",
                columns: table => new
                {
                    wishListItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wishListId = table.Column<int>(nullable: false),
                    gameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishListItem", x => x.wishListItemId);
                    table.ForeignKey(
                        name: "FK_wishListItem_game",
                        column: x => x.gameId,
                        principalTable: "game",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_wishListItem_wishList",
                        column: x => x.wishListId,
                        principalTable: "wishList",
                        principalColumn: "wishListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eventAttendee",
                columns: table => new
                {
                    eventAttendeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventId = table.Column<int>(nullable: false),
                    accountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventAttendee", x => x.eventAttendeeId);
                    table.ForeignKey(
                        name: "FK_eventAttendee_account",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_eventAttendee_event",
                        column: x => x.eventId,
                        principalTable: "event",
                        principalColumn: "eventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billingProvinceState_countryId",
                table: "billingProvinceState",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_cart_accountId",
                table: "cart",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_cartGame_cartId",
                table: "cartGame",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartGame_gameId",
                table: "cartGame",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_creditCard_accountId",
                table: "creditCard",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_creditCard_cardTypeId",
                table: "creditCard",
                column: "cardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_creditCard_countryId",
                table: "creditCard",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_creditCard_provinceStateId",
                table: "creditCard",
                column: "provinceStateId");

            migrationBuilder.CreateIndex(
                name: "IX_event_gameId",
                table: "event",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_eventAttendee_accountId",
                table: "eventAttendee",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_eventAttendee_eventId",
                table: "eventAttendee",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_friendList_accountId",
                table: "friendList",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_friendList_friendId",
                table: "friendList",
                column: "friendId");

            migrationBuilder.CreateIndex(
                name: "IX_game_gameGenreId",
                table: "game",
                column: "gameGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_order_accountId",
                table: "order",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_gameId",
                table: "orderItem",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_profile_accountId",
                table: "profile",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_review_gameId",
                table: "review",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_wishList_accountId",
                table: "wishList",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_wishListItem_gameId",
                table: "wishListItem",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_wishListItem_wishListId",
                table: "wishListItem",
                column: "wishListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartGame");

            migrationBuilder.DropTable(
                name: "creditCard");

            migrationBuilder.DropTable(
                name: "eventAttendee");

            migrationBuilder.DropTable(
                name: "friendList");

            migrationBuilder.DropTable(
                name: "orderItem");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "wishListItem");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "cardType");

            migrationBuilder.DropTable(
                name: "billingProvinceState");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "friend");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "wishList");

            migrationBuilder.DropTable(
                name: "billingCountry");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "gameGenre");
        }
    }
}
