-- Group [Group]
create table `group` (
   `group_id`  integer  not null,
   `groupname`  varchar(255),
  primary key (`group_id`)
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
   `user_id`  integer  not null,
   `username`  varchar(255),
   `password`  varchar(255),
   `email`  varchar(255),
  primary key (`user_id`)
);


-- Playlist [ent1]
create table `playlist` (
   `laylist_id`  integer  not null,
   `playlist_name`  varchar(255),
  primary key (`laylist_id`)
);


-- Music [pkg2#ent11]
create table `music` (
   `music_oid`  integer  not null,
   `duration`  varchar(255),
   `name`  varchar(255),
  primary key (`music_oid`)
);


-- Genre [pkg2#ent14]
create table `genre` (
   `genre_id`  integer  not null,
   `genre_name`  varchar(255),
  primary key (`genre_id`)
);


-- Artist [pkg2#ent2]
create table `artist` (
   `artist_id`  integer  not null,
   `artist_name`  varchar(255),
  primary key (`artist_id`)
);


-- Album [pkg2#ent6]
create table `album` (
   `album_id`  integer  not null,
   `album_name`  varchar(255),
  primary key (`album_id`)
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
alter table `group_module`   add index fk_group_module_group (`group_oid`), add constraint fk_group_module_group foreign key (`group_oid`) references `group` (`group_id`);
alter table `group_module`   add index fk_group_module_module (`module_oid`), add constraint fk_group_module_module foreign key (`module_oid`) references `module` (`oid`);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;
alter table `user`   add index fk_user_group (`group_oid`), add constraint fk_user_group foreign key (`group_oid`) references `group` (`group_id`);


-- User_Group [User2Group_Group2User]
create table `user_group` (
   `user_oid`  integer not null,
   `group_oid`  integer not null,
  primary key (`user_oid`, `group_oid`)
);
alter table `user_group`   add index fk_user_group_user (`user_oid`), add constraint fk_user_group_user foreign key (`user_oid`) references `user` (`user_id`);
alter table `user_group`   add index fk_user_group_group (`group_oid`), add constraint fk_user_group_group foreign key (`group_oid`) references `group` (`group_id`);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album (`album_oid`), add constraint fk_music_album foreign key (`album_oid`) references `album` (`album_id`);


-- Music_Playlist [rel11]
alter table `music`  add column  `playlist_oid`  integer;
alter table `music`   add index fk_music_playlist (`playlist_oid`), add constraint fk_music_playlist foreign key (`playlist_oid`) references `playlist` (`laylist_id`);


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist (`artist_oid`), add constraint fk_music_artist foreign key (`artist_oid`) references `artist` (`artist_id`);


-- Genre_Music [rel18]
alter table `music`  add column  `genre_genre_id`  integer;
alter table `music`   add index fk_music_genre (`genre_genre_id`), add constraint fk_music_genre foreign key (`genre_genre_id`) references `genre` (`genre_id`);


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;
alter table `playlist`   add index fk_playlist_user (`user_oid`), add constraint fk_playlist_user foreign key (`user_oid`) references `user` (`user_id`);


