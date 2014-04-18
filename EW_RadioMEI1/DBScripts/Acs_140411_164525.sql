-- Group_DefaultModule [Group2DefaultModule_DefaultModule2Group]
alter table `group`  add column  `module_oid`  integer;


-- User_DefaultGroup [User2DefaultGroup_DefaultGroup2User]
alter table `user`  add column  `group_oid`  integer;


-- Album_Music [rel10]
alter table `music`  add column  `album_oid`  integer;


-- Music_Playlist [rel11]
alter table `music`  add column  `playlist_oid`  integer;


-- Artist_Music [rel14]
alter table `music`  add column  `artist_oid`  integer;


-- Genre_Music [rel18]
alter table `music`  add column  `genre_genre_id`  integer;


-- User_Playlist [rel2]
alter table `playlist`  add column  `user_oid`  integer;


