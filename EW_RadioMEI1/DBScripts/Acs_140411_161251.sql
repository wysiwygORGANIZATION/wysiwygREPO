-- Group [Group]
create table `group` (
   `oid`  integer  not null,
   `groupname`  varchar(255),
  primary key (`oid`)
);


-- Module [Module]
create table `module` (
   `oid`  integer  not null,
   `moduleid`  varchar(255),
   `modulename`  varchar(255),
  primary key (`oid`)
);


-- User [User]
create table `user` (
   `oid`  integer  not null,
   `username`  varchar(255),
   `password`  varchar(255),
   `email`  varchar(255),
  primary key (`oid`)
);


-- Playlist [ent1]
create table `playlist` (
   `oid`  integer  not null,
   `nameplaylist`  varchar(255),
  primary key (`oid`)
);


-- Genre [ent3]
create table `genre` (
   `oid`  integer  not null,
   `genre`  varchar(255),
  primary key (`oid`)
);


-- Livros [ent4]
create table `livros` (
   `oid`  integer  not null,
   `titulo`  varchar(255),
   `numpages`  integer,
   `description`  varchar(255),
  primary key (`oid`)
);


-- Music [pkg2#ent11]
create table `music` (
   `oid`  integer  not null,
   `duration`  varchar(255),
   `name`  varchar(255),
  primary key (`oid`)
);


-- Artist [pkg2#ent2]
create table `artist` (
   `oid`  integer  not null,
   `name`  varchar(255),
  primary key (`oid`)
);


-- GenreMusic [pkg2#ent5]
create table `genre_2` (
   `oid`  integer  not null,
   `genremusic`  varchar(255),
  primary key (`oid`)
);


-- Album [pkg2#ent6]
create table `album` (
   `oid`  integer  not null,
   `name`  varchar(255),
  primary key (`oid`)
);


-- Group_DefaultModule [Group2DefaultModule_DefaultModule2Group]
alter table `group`  add column  `module_oid`  integer;
alter table `group`   add index fk_group_module (`module_oid`), add constraint fk_group_module foreign key (`module_oid`) references `module` (`oid`);


-- Group_Module [Group2Module_Module2Group]
create table `group_module` (
   `group_oid`  integer not null,
   `module_oid`  integer not null,
  primary key (`group_oid`, `module_oid`)
);
alter table `group_module`   add index fk_group_module_group (`group_oid`), add constraint fk_group_module_group foreign key (`group_oid`) references `group` (`oid`);
alter table `group_module`   add index fk_group_module_module (`module_oid`), add constraint fk_group_module_module foreign key (`module_oid`) references `module` (`oid`);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;
alter table `user`   add index fk_user_group (`group_oid`), add constraint fk_user_group foreign key (`group_oid`) references `group` (`oid`);


-- User_Group [User2Group_Group2User]
create table `user_group` (
   `user_oid`  integer not null,
   `group_oid`  integer not null,
  primary key (`user_oid`, `group_oid`)
);
alter table `user_group`   add index fk_user_group_user (`user_oid`), add constraint fk_user_group_user foreign key (`user_oid`) references `user` (`oid`);
alter table `user_group`   add index fk_user_group_group (`group_oid`), add constraint fk_user_group_group foreign key (`group_oid`) references `group` (`oid`);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album (`album_oid`), add constraint fk_music_album foreign key (`album_oid`) references `album` (`oid`);


-- MusicPlaylist [rel11]
alter table `music`  add column  `playlist_oid`  integer;
alter table `music`   add index fk_music_playlist (`playlist_oid`), add constraint fk_music_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist (`artist_oid`), add constraint fk_music_artist foreign key (`artist_oid`) references `artist` (`oid`);


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;
alter table `playlist`   add index fk_playlist_user (`user_oid`), add constraint fk_playlist_user foreign key (`user_oid`) references `user` (`oid`);


-- User_Livros [rel3]
create table `user_livros` (
   `user_oid`  integer not null,
   `livros_oid`  integer not null,
  primary key (`user_oid`, `livros_oid`)
);
alter table `user_livros`   add index fk_user_livros_user (`user_oid`), add constraint fk_user_livros_user foreign key (`user_oid`) references `user` (`oid`);
alter table `user_livros`   add index fk_user_livros_livros (`livros_oid`), add constraint fk_user_livros_livros foreign key (`livros_oid`) references `livros` (`oid`);


-- Livros_Genre [rel4]
alter table `livros`  add column  `genre_oid`  integer;
alter table `livros`   add index fk_livros_genre (`genre_oid`), add constraint fk_livros_genre foreign key (`genre_oid`) references `genre` (`oid`);


-- MusicGenremusic [rel6]
alter table `music`  add column  `genre_2_oid`  integer;
alter table `music`   add index fk_music_genre_2 (`genre_2_oid`), add constraint fk_music_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);


