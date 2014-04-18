-- Cart Item [pkg1#ent1]
create table `cart_item` (
   `oid`  integer  not null,
  primary key (`oid`)
);


-- Cart_Cart Item [rel3]
create table `cart_cart_item` (
   `cart_oid`  integer not null,
   `cart_item_oid`  integer not null,
  primary key (`cart_oid`, `cart_item_oid`)
);
alter table `cart_cart_item`   add index fk_cart_cart_item_cart (`cart_oid`), add constraint fk_cart_cart_item_cart foreign key (`cart_oid`) references `cart` (`oid`);
alter table `cart_cart_item`   add index fk_cart_cart_item_cart_item (`cart_item_oid`), add constraint fk_cart_cart_item_cart_item foreign key (`cart_item_oid`) references `cart_item` (`oid`);


-- Cart Item_Music [rel5]
alter table `music`  add column  `cart_item_oid`  integer;
alter table `music`   add index fk_music_cart_item (`cart_item_oid`), add constraint fk_music_cart_item foreign key (`cart_item_oid`) references `cart_item` (`oid`);


