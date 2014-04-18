-- Group_DefaultModule [Group2DefaultModule_DefaultModule2Group]
alter table `group`  add column  `module_oid`  integer;
alter table `group`   add index fk_group_module_2 (`module_oid`), add constraint fk_group_module_2 foreign key (`module_oid`) references `module` (`oid`);


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;
alter table `user`   add index fk_user_group_2 (`group_oid`), add constraint fk_user_group_2 foreign key (`group_oid`) references `group` (`group_id`);


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;
alter table `music`   add index fk_music_album_2 (`album_oid`), add constraint fk_music_album_2 foreign key (`album_oid`) references `album` (`album_id`);


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;
alter table `music`   add index fk_music_artist_2 (`artist_oid`), add constraint fk_music_artist_2 foreign key (`artist_oid`) references `artist` (`artist_id`);


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;
alter table `playlist`   add index fk_playlist_user_2 (`user_oid`), add constraint fk_playlist_user_2 foreign key (`user_oid`) references `user` (`user_id`);


-- MusicGenremusic [rel6]
alter table `music`  add column  `genre_2_oid`  integer;
alter table `music`   add index fk_music_genre_2_2 (`genre_2_oid`), add constraint fk_music_genre_2_2 foreign key (`genre_2_oid`) references `genre_2` (`genre_id`);


