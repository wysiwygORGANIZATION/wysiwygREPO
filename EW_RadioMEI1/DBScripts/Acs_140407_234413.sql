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


-- Genre [ent10]
create table `genre_2` (
   `oid`  integer  not null,
   `genreid`  varchar(255),
  primary key (`oid`)
);


-- HighlightGenre [ent11]
create table `highlightgenre` (
   `oid`  integer  not null,
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


-- Cart [ent7]
create table `cart` (
   `oid`  integer  not null,
   `cartname`  varchar(255),
  primary key (`oid`)
);


-- Music [ent8]
create table `music` (
   `oid`  integer  not null,
   `duration`  varchar(255),
   `name`  varchar(255),
  primary key (`oid`)
);


-- Album [ent9]
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


-- Album_Genre [rel11]
create table `album_genre` (
   `album_oid`  integer not null,
   `genre_2_oid`  integer not null,
  primary key (`album_oid`, `genre_2_oid`)
);
alter table `album_genre`   add index fk_album_genre_album (`album_oid`), add constraint fk_album_genre_album foreign key (`album_oid`) references `album` (`oid`);
alter table `album_genre`   add index fk_album_genre_genre_2 (`genre_2_oid`), add constraint fk_album_genre_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);


-- HighlightGenre_Genre [rel12]
alter table `highlightgenre`  add column  `genre_2_oid`  integer;
alter table `highlightgenre`   add index fk_highlightgenre_genre_2 (`genre_2_oid`), add constraint fk_highlightgenre_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);


-- User_HighlightGenre [rel13]
alter table `highlightgenre`  add column  `user_oid`  integer;
alter table `highlightgenre`   add index fk_highlightgenre_user (`user_oid`), add constraint fk_highlightgenre_user foreign key (`user_oid`) references `user` (`oid`);


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


-- Cart_User [rel8]
create table `cart_user` (
   `cart_oid`  integer not null,
   `user_oid`  integer not null,
  primary key (`cart_oid`, `user_oid`)
);
alter table `cart_user`   add index fk_cart_user_cart (`cart_oid`), add constraint fk_cart_user_cart foreign key (`cart_oid`) references `cart` (`oid`);
alter table `cart_user`   add index fk_cart_user_user (`user_oid`), add constraint fk_cart_user_user foreign key (`user_oid`) references `user` (`oid`);


-- Cart_Music [rel9]
alter table `music`  add column  `cart_oid`  integer;
alter table `music`   add index fk_music_cart (`cart_oid`), add constraint fk_music_cart foreign key (`cart_oid`) references `cart` (`oid`);


