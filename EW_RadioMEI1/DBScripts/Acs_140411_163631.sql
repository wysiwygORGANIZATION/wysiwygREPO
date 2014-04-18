-- Group_DefaultModule [Group2DefaultModule_DefaultModule2Group]
alter table `group`  add column  `module_oid`  integer;
alter table `group`   add index fk_group_module_2 (`module_oid`), add constraint fk_group_module_2 foreign key (`module_oid`) references `module` (`module_id`);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;
alter table `user`   add index fk_user_group_2 (`group_oid`), add constraint fk_user_group_2 foreign key (`group_oid`) references `group` (`group_id`);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album_2 (`album_oid`), add constraint fk_music_album_2 foreign key (`album_oid`) references `album` (`album_id`);


-- Music_Playlist [rel11]
alter table `music`  add column  `playlist_oid`  integer;
alter table `music`   add index fk_music_playlist_2 (`playlist_oid`), add constraint fk_music_playlist_2 foreign key (`playlist_oid`) references `playlist` (`laylist_id`);


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist_2 (`artist_oid`), add constraint fk_music_artist_2 foreign key (`artist_oid`) references `artist` (`artist_id`);


-- Genre_Music [rel18]
alter table `music`  add column  `genre_genre_id`  integer;
alter table `music`   add index fk_music_genre_2 (`genre_genre_id`), add constraint fk_music_genre_2 foreign key (`genre_genre_id`) references `genre` (`genre_id`);


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;
alter table `playlist`   add index fk_playlist_user_2 (`user_oid`), add constraint fk_playlist_user_2 foreign key (`user_oid`) references `user` (`user_id`);


