-- Cart Item_Music [rel2]
alter table `music`  add column  `cart_item_oid`  integer;
alter table `music`   add index fk_music_cart_item (`cart_item_oid`), add constraint fk_music_cart_item foreign key (`cart_item_oid`) references `cart_item` (`oid`);


