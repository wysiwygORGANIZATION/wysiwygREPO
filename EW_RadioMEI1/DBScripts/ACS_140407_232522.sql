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


