-- Music [ent5]
create table `music` (
   `oid`  integer  not null,
   `duration`  varchar(255),
   `musicname`  varchar(255),
  primary key (`oid`)
);


-- MusicArtist [rel1]
alter table `cart`  add column  `oid`  integer;
alter table `cart`   add index fk_cart_music (`oid`), add constraint fk_cart_music foreign key (`oid`) references `music` (`oid`);


-- User_Cart [rel7]
create table `user_cart` (
   `user_oid`  integer not null,
   `cart_oid`  integer not null,
  primary key (`user_oid`, `cart_oid`)
);
alter table `user_cart`   add index fk_user_cart_user (`user_oid`), add constraint fk_user_cart_user foreign key (`user_oid`) references `user` (`oid`);
alter table `user_cart`   add index fk_user_cart_cart (`cart_oid`), add constraint fk_user_cart_cart foreign key (`cart_oid`) references `cart` (`oid`);


