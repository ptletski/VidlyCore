using System;
using Microsoft.EntityFrameworkCore.Migrations;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.Migrations
{
    public partial class PopulateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");

            migrationBuilder.Sql($"UPDATE MembershipTypes SET MembershipName=\"Pay As You Go\" WHERE MembershipTypeId={MembershipType.PayAsYouGo}");
            migrationBuilder.Sql($"UPDATE MembershipTypes SET MembershipName=\"Monthly\" WHERE MembershipTypeId={MembershipType.Monthly}");
            migrationBuilder.Sql($"UPDATE MembershipTypes SET MembershipName=\"Quarterly\" WHERE MembershipTypeId={MembershipType.Quarterly}");
            migrationBuilder.Sql($"UPDATE MembershipTypes SET MembershipName=\"Yearly\" WHERE MembershipTypeId={MembershipType.Yearly}");

            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"John Smith\", \"44 West Rock Rd.\", \"Newton\", \"Iowa\", 0, '1940-02-23', 100, {MembershipType.PayAsYouGo})");
            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"Mary Williams\", \"23193 Orange St.\", \"San Blismo\", \"California\", 1, NULL, 101, {MembershipType.Yearly})");
            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"Roy Buchanan\", \"743 Ralph Ave.\", \"San Antonio\", \"Texas\", 1, NULL, 102, {MembershipType.Quarterly})");
            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"Albert King\", \"4525 St. Clair St.\", \"Lake Placid\", \"New York\", 1, '1923-04-25', 103, {MembershipType.Yearly})");
            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"Freddie King\", \"11 Route 17.\", \"Cobb\", \"Georgia\", 1, NULL, 104, {MembershipType.Yearly})");
            migrationBuilder.Sql($"INSERT INTO Customers (Name, Address, City, State, IsSubscribedToNewsletter, BirthDate, CustomerId, MembershipTypeId) VALUES(\"Aretha Franklin\", \"441 Claymore Ave.\", \"Kansas City\", \"Missouri\", 0, '1942-03-25', 105, {MembershipType.Monthly})");

            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Comedy\", {MovieGenre.Comedy})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Action\", {MovieGenre.Action})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Family\", {MovieGenre.Family})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Romance\", {MovieGenre.Romance})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Suspense\", {MovieGenre.Suspense})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Documentary\", {MovieGenre.Documentary})");
            migrationBuilder.Sql($"INSERT INTO MovieGenres (MovieGenreName, MovieGenreId) VALUES(\"Drama\", {MovieGenre.Drama})");

            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Shrek\", 2001, {MovieGenre.Family}, {MpaRating.PG}, 0, 1, '2018-10-27', 1)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Wall-e\", 2008, {MovieGenre.Family}, {MpaRating.G}, 0, 2, '2018-10-27', 2)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Summer Rental\",1985, {MovieGenre.Comedy}, {MpaRating.PG}, 0, 3, '2018-10-27', 3)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Apollo 13\", 1995, {MovieGenre.Suspense}, {MpaRating.PG}, 0, 4, '2018-10-27', 4)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"The Hangover\", 2009, {MovieGenre.Comedy}, {MpaRating.R}, 0, 5, '2018-10-27', 5)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Die Hard\", 1988, {MovieGenre.Action}, {MpaRating.R}, 0, 6, '2018-10-27', 6)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Toy Story\", 1995, {MovieGenre.Family}, {MpaRating.PG}, 0, 7, '2018-10-27', 7)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Titanic\", 1997, {MovieGenre.Romance}, {MpaRating.PG13}, 0, 8, '2018-10-27', 8)");
            migrationBuilder.Sql($"INSERT INTO Movies (Title, Year, MovieGenreId, MpaRatingId, ActiveUseCount, InventoryControlId, DateAdded, MovieId) VALUES(\"Uncle Buck\", 1989, {MovieGenre.Comedy}, {MpaRating.PG}, 0, 9, '2018-10-27', 9)");

            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"Sony Motion Pictures\", \"http:test\", {ContentProvider.SonyMotionPictures})");
            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"United Artists\", \"http:test\", {ContentProvider.UnitedArtists})");
            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"20th Century Fox\", \"http:test\", {ContentProvider.TwentiethCenturyFox})");
            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"Columbia Pictures\", \"http:test\", {ContentProvider.ColumbiaPictures})");
            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"Disney Motion Pictures\", \"http:test\", {ContentProvider.DisneyMotionPictures})");
            migrationBuilder.Sql($"INSERT INTO ContentProviders (ContentProviderName, ContractReference, ContentProviderId) VALUES(\"Metro-Goldwin-Mayer\", \"http:test\", {ContentProvider.MetroGoldwinMayer})");

            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(1, {ContentProvider.TwentiethCenturyFox}, 200, 1)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(2, {ContentProvider.DisneyMotionPictures}, 220, 2)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(3, {ContentProvider.SonyMotionPictures}, 500, 3)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(4, {ContentProvider.DisneyMotionPictures}, 310, 4)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(5, {ContentProvider.TwentiethCenturyFox}, 200, 5)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(6, {ContentProvider.TwentiethCenturyFox}, 200, 6)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(7, {ContentProvider.DisneyMotionPictures}, 700, 7)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(8, {ContentProvider.UnitedArtists}, 200, 8)");
            migrationBuilder.Sql($"INSERT INTO InventoryControl (MovieId, ContentProviderId, PermittedUsageCount, InventoryControlId) VALUES(9, {ContentProvider.TwentiethCenturyFox}, 900, 9)");

            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"G\", {MpaRating.G})");
            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"PG\", {MpaRating.PG})");
            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"PG-13\", {MpaRating.PG13})");
            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"R\", {MpaRating.R})");
            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"X\", {MpaRating.X})");
            migrationBuilder.Sql($"INSERT INTO MpaRatings (MpaRatingName, MpaRatingId) VALUES(\"NR\", {MpaRating.NR})");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
