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


-- Cart [ent3]
create table `cart` (
   `oid`  integer  not null,
   `name`  varchar(255),
  primary key (`oid`)
);


-- Music [pkg2#ent11]
create table `music` (
   `oid`  integer  not null,
   `duration`  varchar(255),
   `name`  varchar(255),
  primary key (`oid`)
);


-- Genre [pkg2#ent15]
create table `genre` (
   `oid`  integer  not null,
   `name`  varchar(255),
  primary key (`oid`)
);


-- Artist [pkg2#ent2]
create table `artist` (
   `oid`  integer  not null,
   `name`  varchar(255),
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


-- Group_Module [Group2Module_Module2Group]
create table `group_module` (
   `group_oid`  integer not null,
   `module_oid`  integer not null,
  primary key (`group_oid`, `module_oid`)
);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;


-- User_Group [User2Group_Group2User]
create table `user_group` (
   `user_oid`  integer not null,
   `group_oid`  integer not null,
  primary key (`user_oid`, `group_oid`)
);


-- Cart_Music [rel1]
alter table `music`  add column  `cart_oid`  integer;


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;


-- MusicPlaylist [rel11]
alter table `music`  add column  `playlist_oid`  integer;


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;


-- Music_Genre [rel19]
alter table `music`  add column  `genre_oid`  integer;


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;


