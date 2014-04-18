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


-- Cart [pkg1#ent5]
create table `cart` (
   `oid`  integer  not null,
   `name`  varchar(255),
   `date`  datetime,
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


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist (`artist_oid`), add constraint fk_music_artist foreign key (`artist_oid`) references `artist` (`oid`);


-- Music_Genre [rel19]
alter table `music`  add column  `genre_oid`  integer;
alter table `music`   add index fk_music_genre (`genre_oid`), add constraint fk_music_genre foreign key (`genre_oid`) references `genre` (`oid`);


-- Cart_Music [rel3]
create table `cart_music` (
   `cart_oid`  integer not null,
   `music_oid`  integer not null,
  primary key (`cart_oid`, `music_oid`)
);
alter table `cart_music`   add index fk_cart_music_cart (`cart_oid`), add constraint fk_cart_music_cart foreign key (`cart_oid`) references `cart` (`oid`);
alter table `cart_music`   add index fk_cart_music_music (`music_oid`), add constraint fk_cart_music_music foreign key (`music_oid`) references `music` (`oid`);


-- Cart_User [rel4]
alter table `user`  add column  `cart_oid`  integer;
alter table `user`   add index fk_user_cart (`cart_oid`), add constraint fk_user_cart foreign key (`cart_oid`) references `cart` (`oid`);


