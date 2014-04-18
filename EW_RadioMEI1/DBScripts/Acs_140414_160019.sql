-- Cart Item_Music [rel2]
alter table `cart_item`  add column  `music_oid`  integer;
alter table `cart_item`   add index fk_cart_item_music_2 (`music_oid`), add constraint fk_cart_item_music_2 foreign key (`music_oid`) references `music` (`oid`);


