-- PlayList [ent3]
create table `playlist` (
   `oid`  integer  not null,
   `votes`  integer,
   `name`  varchar(255),
   `active`  integer,
  primary key (`oid`)
);


-- PlayList_CartItem [rel3]
create table `playlist` (
   `playlist_oid`  integer not null,
   `oid`  integer not null,
  primary key (`playlist_oid`, `oid`)
);
alter table `playlist`   add index fk_playlist_playlist (`playlist_oid`), add constraint fk_playlist_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);
alter table `playlist`   add index fk_playlist_music (`oid`), add constraint fk_playlist_music foreign key (`oid`) references `music` ();


