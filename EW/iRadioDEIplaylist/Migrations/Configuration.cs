namespace iRadioDEIplaylist.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	//namespace added so the "iRadioDEIplaylist.Models." prefix on UsersContext is not needed
	using iRadioDEIplaylist.Models;
	//needed for WebSecurity
	using WebMatrix.WebData;
	//needed for Roles
	using System.Web.Security;
	using System.Collections.Generic;

	internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true; //default was false
			//AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(UsersContext context)
		{
			WebSecurity.InitializeDatabaseConnection(
				"DefaultConnection",
				"UserProfile",
				"UserId",
				"UserName", autoCreateTables: true);

			//roles

			if (!Roles.RoleExists("Administrator"))
				Roles.CreateRole("Administrator");

			if (!Roles.RoleExists("Manager"))
				Roles.CreateRole("Manager");


			//users and roles

            if (!WebSecurity.UserExists("anonymous"))
                WebSecurity.CreateUserAndAccount(
                    "anonymous",
                    "anonymous",
                    new { UserEmail = "lcnsvng@hotmail.com", UserBirthDate = "2000-01-01", UserAddress = "Nowhere" });

            // -------------------------------------------------------------------

			if (!WebSecurity.UserExists("luis"))
				WebSecurity.CreateUserAndAccount(
					"luis",
					"Pa$$w0rd",
					new { UserEmail = "1100627@isep.ipp.pt", UserBirthDate = "1988-07-19", UserAddress = "Gaia" });

			if (!Roles.GetRolesForUser("luis").Contains("Administrator"))
				Roles.AddUsersToRoles(new[] { "luis" }, new[] { "Administrator" });

			if (!Roles.GetRolesForUser("luis").Contains("Manager"))
				Roles.AddUsersToRoles(new[] { "luis" }, new[] { "Manager" });

            // -------------------------------------------------------------------

			if (!WebSecurity.UserExists("samuel"))
				WebSecurity.CreateUserAndAccount(
					"samuel",
					"Pa$$w0rd",
					new { UserEmail = "1090669@isep.ipp.pt", UserBirthDate = "1990-11-27", UserAddress = "Melgaço" });

			if (!Roles.GetRolesForUser("samuel").Contains("Administrator"))
				Roles.AddUsersToRoles(new[] { "samuel" }, new[] { "Administrator" });

			if (!Roles.GetRolesForUser("samuel").Contains("Manager"))
				Roles.AddUsersToRoles(new[] { "samuel" }, new[] { "Manager" });

			// -------------------------------------------------------------------

			if (!WebSecurity.UserExists("manager1"))
				WebSecurity.CreateUserAndAccount(
					"manager1",
					"passwordmanager1",
					new { UserEmail = "luiscnsousa@gmail.com", UserBirthDate = "1989-12-15", UserAddress = "Braga" });

			if (!Roles.GetRolesForUser("manager1").Contains("Manager"))
				Roles.AddUsersToRoles(new[] { "manager1" }, new[] { "Manager" });

			// ------------------------------------------------------------------

			if (!WebSecurity.UserExists("user1"))
				WebSecurity.CreateUserAndAccount(
					"user1",
					"passworduser1",
					new { UserEmail = "lcnsvng@hotmail.com", UserBirthDate = "1990-11-05", UserAddress = "Porto" });


			// genres

			context.Genres.Add(new Genre { GenreName = "metal" });
			context.Genres.Add(new Genre { GenreName = "electronic" });
			context.Genres.Add(new Genre { GenreName = "pop" });
			context.Genres.Add(new Genre { GenreName = "jazz" });
			context.Genres.Add(new Genre { GenreName = "punk" });
			context.Genres.Add(new Genre { GenreName = "ambient" });
			context.Genres.Add(new Genre { GenreName = "80s" });
			context.Genres.Add(new Genre { GenreName = "hip-hop" });
			context.Genres.Add(new Genre { GenreName = "classical" });
			context.SaveChanges();


			// artists

			var artists = new List<Artist>
			{
				new Artist { ArtistName = "Arch Enemy" },
				new Artist { ArtistName = "Nightwish" },
				new Artist { ArtistName = "Helloween" },
				new Artist { ArtistName = "Slipknot" },
				new Artist { ArtistName = "System of a Down" },
				new Artist { ArtistName = "Crystal Castles" },
				new Artist { ArtistName = "M83" },
				new Artist { ArtistName = "Rihanna" },
				new Artist { ArtistName = "Ellie Goulding" },
				new Artist { ArtistName = "Miles Davis" },
				new Artist { ArtistName = "The Clash" },
				new Artist { ArtistName = "Ramones" },
				new Artist { ArtistName = "Radiohead" },
				new Artist { ArtistName = "Tycho" },
				new Artist { ArtistName = "a-ha" },
				new Artist { ArtistName = "The Smiths" },
				new Artist { ArtistName = "Flo Rida" },
				new Artist { ArtistName = "Claude Debussy" }
			};
			artists.ForEach(a => context.Artists.Add(a));
			context.SaveChanges();


			// musics

			var musics = new List<Music>
			{
				new Music{ MusicName = "Silent Wars" , MusicDuration = 254 , Album = new Album{ AlbumName = "Anthems of Rebellion", ArtistId = 1 }, GenreId = 1 },
				new Music{ MusicName = "Nemesis" , MusicDuration = 254 , Album = new Album{ AlbumName = "Doomsday Machine", ArtistId = 1 }, GenreId = 1 },
				new Music{ MusicName = "Crownless" , MusicDuration = 266 , Album = new Album{ AlbumName = "Wishmaster", ArtistId = 2 }, GenreId = 1 },
				new Music{ MusicName = "End of All Hope" , MusicDuration = 235 , Album = new Album{ AlbumName = "Century Child", ArtistId = 2 }, GenreId = 1 },
				new Music{ MusicName = "Just A Little Sign" , MusicDuration = 268 , Album = new Album{ AlbumName = "Rabbit Don't Come Easy", ArtistId = 3 }, GenreId = 1 },
				new Music{ MusicName = "Long Live the King" , MusicDuration = 253 , Album = new Album{ AlbumName = "7 Sinners", ArtistId = 3 }, GenreId = 1 },
				new Music{ MusicName = "Disasterpiece" , MusicDuration = 308 , Album = new Album{ AlbumName = "Iowa", ArtistId = 4 }, GenreId = 1 },
				new Music{ MusicName = "Dead Memories" , MusicDuration = 268 , Album = new Album{ AlbumName = "All Hope Is Gone", ArtistId = 4 }, GenreId = 1 },
				new Music{ MusicName = "Chop Suey!" , MusicDuration = 210 , Album = new Album{ AlbumName = "Toxicity", ArtistId = 5 }, GenreId = 1 },
				new Music{ MusicName = "B.Y.O.B" , MusicDuration = 255 , Album = new Album{ AlbumName = "Mezmerize", ArtistId = 5 }, GenreId = 1 },
				new Music{ MusicName = "Wrath of God" , MusicDuration = 187 , Album = new Album{ AlbumName = "(III)", ArtistId = 6 }, GenreId = 2 },
				new Music{ MusicName = "Midnight City" , MusicDuration = 244 , Album = new Album{ AlbumName = "Hurry Up We're Dreaming", ArtistId = 7 }, GenreId = 2 },
				new Music{ MusicName = "Diamonds" , MusicDuration = 225 , Album = new Album{ AlbumName = "Unapologetic", ArtistId = 8 }, GenreId = 3 },
				new Music{ MusicName = "Lights" , MusicDuration = 212 , Album = new Album{ AlbumName = "Bright Lights", ArtistId = 9 }, GenreId = 3 },
				new Music{ MusicName = "So What" , MusicDuration = 563 , Album = new Album{ AlbumName = "Kind of Blue", ArtistId = 10 }, GenreId = 4 },
				new Music{ MusicName = "London Calling" , MusicDuration = 199 , Album = new Album{ AlbumName = "London Calling", ArtistId = 11 }, GenreId = 5 },
				new Music{ MusicName = "Blitzkrieg Bop" , MusicDuration = 135 , Album = new Album{ AlbumName = "Ramones", ArtistId = 12 }, GenreId = 5 },
				new Music{ MusicName = "Treefingers" , MusicDuration = 223 , Album = new Album{ AlbumName = "Kid A", ArtistId = 13 }, GenreId = 6 },
				new Music{ MusicName = "Hours" , MusicDuration = 344 , Album = new Album{ AlbumName = "Hours-Single", ArtistId = 14 }, GenreId = 6 },
				new Music{ MusicName = "Take On Me" , MusicDuration = 224 , Album = new Album{ AlbumName = "Minor Earth | Major Sky", ArtistId = 15 }, GenreId = 7 },
				new Music{ MusicName = "There Is A Light That Never Goes Out" , MusicDuration = 246 , Album = new Album{ AlbumName = "The Queen Is Dead", ArtistId = 16 }, GenreId = 7 },
				new Music{ MusicName = "Whistle" , MusicDuration = 222 , Album = new Album{ AlbumName = "Wild Ones", ArtistId = 17 }, GenreId = 8 },
				new Music{ MusicName = "Clair de Lune" , MusicDuration = 280 , Album = new Album{ AlbumName = "Klavierwerke: Clair de Lune", ArtistId = 18 }, GenreId = 9 }
			};
			musics.ForEach(m => context.Musics.Add(m));
			context.SaveChanges();

		}
	}
}
