-- Week [pkg4#ent20]
create table `week` (
   `oid`  integer  not null,
   `week`  integer,
  primary key (`oid`)
);


-- NewSounds [pkg4#ent21]
create table `newsounds` (
   `oid`  integer  not null,
   `active`  bit,
  primary key (`oid`)
);


-- Month [pkg4#ent22]
create table `month` (
   `oid`  integer  not null,
   `month`  varchar(255),
  primary key (`oid`)
);


-- NewSoundsPlaylist [pkg4#ent23]
create table `newsoundsplaylist` (
   `oid`  integer  not null,
  primary key (`oid`)
);


-- Year [pkg4#ent24]
create table `year` (
   `oid`  integer  not null,
   `year`  varchar(255),
  primary key (`oid`)
);


-- NewSounds_Year [rel15]
alter table `newsounds`  add column  `year_oid`  integer;
alter table `newsounds`   add index fk_newsounds_year (`year_oid`), add constraint fk_newsounds_year foreign key (`year_oid`) references `year` (`oid`);


-- NewSounds_NewSoundsPlaylist [rel16]
alter table `newsoundsplaylist`  add column  `newsounds_oid`  integer;
alter table `newsoundsplaylist`   add index fk_newsoundsplaylist_newsounds (`newsounds_oid`), add constraint fk_newsoundsplaylist_newsounds foreign key (`newsounds_oid`) references `newsounds` (`oid`);


-- NewSounds_Month [rel17]
alter table `newsounds`  add column  `month_oid`  integer;
alter table `newsounds`   add index fk_newsounds_month (`month_oid`), add constraint fk_newsounds_month foreign key (`month_oid`) references `month` (`oid`);


-- NewSounds_Week [rel18]
alter table `newsounds`  add column  `week_oid`  integer;
alter table `newsounds`   add index fk_newsounds_week (`week_oid`), add constraint fk_newsounds_week foreign key (`week_oid`) references `week` (`oid`);


-- PlayList_NewSoundsPlaylist [rel20]
alter table `newsoundsplaylist`  add column  `playlist_oid`  integer;
alter table `newsoundsplaylist`   add index fk_newsoundsplaylist_playlist (`playlist_oid`), add constraint fk_newsoundsplaylist_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);


