-- Genre [ent10]
create table `genre_2` (
   `oid`  integer  not null,
   `genreid`  varchar(255),
  primary key (`oid`)
);


-- Album [ent9]
create table `album` (
   `oid`  integer  not null,
   `name`  varchar(255),
  primary key (`oid`)
);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album (`album_oid`), add constraint fk_music_album foreign key (`album_oid`) references `album` (`oid`);


-- Album_Genre [rel11]
create table `album_genre` (
   `album_oid`  integer not null,
   `genre_2_oid`  integer not null,
  primary key (`album_oid`, `genre_2_oid`)
);
alter table `album_genre`   add index fk_album_genre_album (`album_oid`), add constraint fk_album_genre_album foreign key (`album_oid`) references `album` (`oid`);
alter table `album_genre`   add index fk_album_genre_genre_2 (`genre_2_oid`), add constraint fk_album_genre_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);


