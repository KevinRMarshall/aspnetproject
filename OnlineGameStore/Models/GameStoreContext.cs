using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineGameStore.Models
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountGame> AccountGame { get; set; }
        public virtual DbSet<BillingCountry> BillingCountry { get; set; }
        public virtual DbSet<BillingProvinceState> BillingProvinceState { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartGame> CartGame { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAttendee> EventAttendee { get; set; }
        public virtual DbSet<FriendList> FriendList { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameGenre> GameGenre { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
        public virtual DbSet<WishListItem> WishListItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=GameStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.AspuserId)
                    .IsRequired()
                    .HasColumnName("ASPuserId")
                    .HasMaxLength(50);

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('U')");
            });

            modelBuilder.Entity<AccountGame>(entity =>
            {
                entity.ToTable("accountGame");

                entity.Property(e => e.AccountGameId)
                    .HasColumnName("accountGameId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountGame)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_game");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.AccountGame)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_accountGame_game");
            });

            modelBuilder.Entity<BillingCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("billingCountry");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxModifier)
                    .HasColumnName("taxModifier")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<BillingProvinceState>(entity =>
            {
                entity.HasKey(e => e.ProvinceStateId)
                    .HasName("PK_billingProvince");

                entity.ToTable("billingProvinceState");

                entity.Property(e => e.ProvinceStateId).HasColumnName("provinceStateId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.TaxModifier)
                    .HasColumnName("taxModifier")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.BillingProvinceState)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_billingProvinceState_billingCountry");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.ToTable("cardType");

                entity.Property(e => e.CardTypeId).HasColumnName("cardTypeId");

                entity.Property(e => e.CardType1)
                    .IsRequired()
                    .HasColumnName("cardType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cart_account");
            });

            modelBuilder.Entity<CartGame>(entity =>
            {
                entity.ToTable("cartGame");

                entity.Property(e => e.CartGameId).HasColumnName("cartGameId");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartGame)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cartGame_cart");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CartGame)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cartGame_game");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.CreditId);

                entity.ToTable("creditCard");

                entity.Property(e => e.CreditId).HasColumnName("creditId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillingPhone)
                    .IsRequired()
                    .HasColumnName("billingPhone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardCode)
                    .HasColumnName("cardCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CardHolder)
                    .IsRequired()
                    .HasColumnName("cardHolder")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasColumnName("cardNumber")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CardTypeId).HasColumnName("cardTypeId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("expireDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProvinceStateId).HasColumnName("provinceStateId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_creditCard_account");

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.CardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_creditCard_cardType");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_creditCard_billingCountry");

                entity.HasOne(d => d.ProvinceState)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.ProvinceStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_creditCard_billingProvinceState");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasColumnName("eventDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTitle)
                    .IsRequired()
                    .HasColumnName("eventTitle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_event_game");
            });

            modelBuilder.Entity<EventAttendee>(entity =>
            {
                entity.ToTable("eventAttendee");

                entity.Property(e => e.EventAttendeeId).HasColumnName("eventAttendeeId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.EventAttendee)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eventAttendee_account");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendee)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eventAttendee_event");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("friendList");

                entity.Property(e => e.FriendListId).HasColumnName("friendListId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.FriendId).HasColumnName("friendId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FriendListAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_friendList_account");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_friendList_account2");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasColumnName("gameDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GameDiscount)
                    .IsRequired()
                    .HasColumnName("gameDiscount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GameDownloadLink)
                    .HasColumnName("gameDownloadLink")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GameGenreId).HasColumnName("gameGenreId");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasColumnName("gameName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GamePrice)
                    .HasColumnName("gamePrice")
                    .HasColumnType("money");

                entity.HasOne(d => d.GameGenre)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_gameGenre");
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.ToTable("gameGenre");

                entity.Property(e => e.GameGenreId).HasColumnName("gameGenreId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IsProcessed).HasColumnName("isProcessed");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_account");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderItem");

                entity.Property(e => e.OrderItemId).HasColumnName("orderItemId");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderItem_game");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderItem_order");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.Property(e => e.ProfileId).HasColumnName("profileId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FavouriteGameCategory)
                    .HasColumnName("favouriteGameCategory")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FavouritePlatform)
                    .HasColumnName("favouritePlatform")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaidOrFree).HasColumnName("paidOrFree");

                entity.Property(e => e.ParentalCode)
                    .HasColumnName("parentalCode")
                    .HasMaxLength(15);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.ProfileDescription)
                    .IsRequired()
                    .HasColumnName("profileDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasColumnName("profileName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profile_account");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.IsRecommended).HasColumnName("isRecommended");

                entity.Property(e => e.ProfileId).HasColumnName("profileId");

                entity.Property(e => e.ReviewText)
                    .IsRequired()
                    .HasColumnName("reviewText")
                    .HasColumnType("text");

                entity.Property(e => e.ReviewTitle)
                    .IsRequired()
                    .HasColumnName("reviewTitle")
                    .HasColumnType("text");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_review_game");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("wishList");

                entity.Property(e => e.WishListId).HasColumnName("wishListId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.WishList)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishList_account");
            });

            modelBuilder.Entity<WishListItem>(entity =>
            {
                entity.ToTable("wishListItem");

                entity.Property(e => e.WishListItemId).HasColumnName("wishListItemId");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.WishListId).HasColumnName("wishListId");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.WishListItem)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishListItem_game");

                entity.HasOne(d => d.WishList)
                    .WithMany(p => p.WishListItem)
                    .HasForeignKey(d => d.WishListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_wishListItem_wishList");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
