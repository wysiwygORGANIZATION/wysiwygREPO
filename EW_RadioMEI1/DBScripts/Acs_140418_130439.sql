-- PlayList_User [rel13]
alter table `playlist`  add column  `user_oid`  integer;
alter table `playlist`   add index fk_playlist_user (`user_oid`), add constraint fk_playlist_user foreign key (`user_oid`) references `user` (`oid`);


