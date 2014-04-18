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
   `email`  varchar(255),
   `password`  varchar(255),
   `username`  varchar(255),
  primary key (`oid`)
);


-- MusicGenre [ent10]
create table `genre_2` (
   `oid`  integer  not null,
   `genreid`  varchar(255),
  primary key (`oid`)
);


-- Artist [ent12]
create table `artist` (
   `oid`  integer  not null,
   `name`  varchar(255),
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
create index `idx_group_module` on `group`(`module_oid`);


-- Group_Module [Group2Module_Module2Group]
create table `group_module` (
   `group_oid`  integer not null,
   `module_oid`  integer not null,
  primary key (`group_oid`, `module_oid`)
);
alter table `group_module`   add index fk_group_module_group (`group_oid`), add constraint fk_group_module_group foreign key (`group_oid`) references `group` (`oid`);
alter table `group_module`   add index fk_group_module_module (`module_oid`), add constraint fk_group_module_module foreign key (`module_oid`) references `module` (`oid`);
create index `idx_group_module_group` on `group_module`(`group_oid`);
create index `idx_group_module_module` on `group_module`(`module_oid`);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;
alter table `user`   add index fk_user_group (`group_oid`), add constraint fk_user_group foreign key (`group_oid`) references `group` (`oid`);
create index `idx_user_group` on `user`(`group_oid`);


-- User_Group [User2Group_Group2User]
create table `user_group` (
   `user_oid`  integer not null,
   `group_oid`  integer not null,
  primary key (`user_oid`, `group_oid`)
);
alter table `user_group`   add index fk_user_group_user (`user_oid`), add constraint fk_user_group_user foreign key (`user_oid`) references `user` (`oid`);
alter table `user_group`   add index fk_user_group_group (`group_oid`), add constraint fk_user_group_group foreign key (`group_oid`) references `group` (`oid`);
create index `idx_user_group_user` on `user_group`(`user_oid`);
create index `idx_user_group_group` on `user_group`(`group_oid`);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album (`album_oid`), add constraint fk_music_album foreign key (`album_oid`) references `album` (`oid`);
create index `idx_music_album` on `music`(`album_oid`);


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist (`artist_oid`), add constraint fk_music_artist foreign key (`artist_oid`) references `artist` (`oid`);
create index `idx_music_artist` on `music`(`artist_oid`);


-- User_Livros [rel3]
create table `user_livros` (
   `user_oid`  integer not null,
   `livros_oid`  integer not null,
  primary key (`user_oid`, `livros_oid`)
);
alter table `user_livros`   add index fk_user_livros_user (`user_oid`), add constraint fk_user_livros_user foreign key (`user_oid`) references `user` (`oid`);
alter table `user_livros`   add index fk_user_livros_livros (`livros_oid`), add constraint fk_user_livros_livros foreign key (`livros_oid`) references `livros` (`oid`);
create index `idx_user_livros_user` on `user_livros`(`user_oid`);
create index `idx_user_livros_livros` on `user_livros`(`livros_oid`);


-- Livros_Genre [rel4]
alter table `livros`  add column  `genre_oid`  integer;
alter table `livros`   add index fk_livros_genre (`genre_oid`), add constraint fk_livros_genre foreign key (`genre_oid`) references `genre` (`oid`);
create index `idx_livros_genre` on `livros`(`genre_oid`);


-- Cart_User [rel8]
create table `cart_user` (
   `cart_oid`  integer not null,
   `user_oid`  integer not null,
  primary key (`cart_oid`, `user_oid`)
);
alter table `cart_user`   add index fk_cart_user_cart (`cart_oid`), add constraint fk_cart_user_cart foreign key (`cart_oid`) references `cart` (`oid`);
alter table `cart_user`   add index fk_cart_user_user (`user_oid`), add constraint fk_cart_user_user foreign key (`user_oid`) references `user` (`oid`);
create index `idx_cart_user_cart` on `cart_user`(`cart_oid`);
create index `idx_cart_user_user` on `cart_user`(`user_oid`);


-- Cart_Music [rel9]
alter table `music`  add column  `cart_oid`  integer;
alter table `music`   add index fk_music_cart (`cart_oid`), add constraint fk_music_cart foreign key (`cart_oid`) references `cart` (`oid`);
create index `idx_music_cart` on `music`(`cart_oid`);


