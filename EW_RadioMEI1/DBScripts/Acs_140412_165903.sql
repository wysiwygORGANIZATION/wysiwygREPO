-- Cart Item [pkg1#ent7]
create table `cart_item` (
   `oid`  integer  not null,
   `musicname`  varchar(255),
   `duration`  varchar(255),
   `genre`  varchar(255),
   `album`  varchar(255),
   `artistname`  varchar(255),
  primary key (`oid`)
);


-- Cart [pkg1#ent5]
alter table `cart`  add column  `date`  datetime;


-- Cart_CartItem [rel1]
alter table `cart_item`  add column  `cart_oid`  integer;
alter table `cart_item`   add index fk_cart_item_cart (`cart_oid`), add constraint fk_cart_item_cart foreign key (`cart_oid`) references `cart` (`oid`);


