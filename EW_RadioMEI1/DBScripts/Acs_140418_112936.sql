-- PlayList [ent3]
create table `playlist` (
   `oid`  integer  not null,
   `votes`  integer,
   `name`  varchar(255),
   `active`  integer,
  primary key (`oid`)
);


-- PlayList_CartItem [rel3]
alter table `playlist`  add column  `oid`  integer;
alter table `playlist`   add index fk_playlist_cartitem (`oid`), add constraint fk_playlist_cartitem foreign key (`oid`) references `cartitem` (`oid`);


