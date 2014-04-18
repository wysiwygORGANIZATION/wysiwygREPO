-- Cart_Music [rel13]
alter table `music`  add column  `cart_oid`  integer;
alter table `music`   add index fk_music_cart (`cart_oid`), add constraint fk_music_cart foreign key (`cart_oid`) references `cart` (`oid`);


