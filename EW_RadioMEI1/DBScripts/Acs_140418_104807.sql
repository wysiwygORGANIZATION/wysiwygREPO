-- PlayList [ent3]
create table `playlist` (
   `oid`  integer  not null,
   `votes`  integer,
   `name`  varchar(255),
   `active`  integer,
  primary key (`oid`)
);


-- PlayList_CartItem [rel3]
alter table `cartitem`  add column  `playlist_oid`  integer;
alter table `cartitem`   add index fk_cartitem_playlist (`playlist_oid`), add constraint fk_cartitem_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);


