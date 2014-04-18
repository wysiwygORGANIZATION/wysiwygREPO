-- REL FK: defaultGroups [DefaultModule2Group]
alter table `group`   add index fk_group_module (`module_oid`), add constraint fk_group_module foreign key (`module_oid`) references `module` (`oid`);


-- REL FK: modules [Group2Module]
alter table `group_module`   add index fk_group_module_group (`group_oid`), add constraint fk_group_module_group foreign key (`group_oid`) references `group` (`oid`);


-- REL FK: groups [Module2Group]
alter table `group_module`   add index fk_group_module_module (`module_oid`), add constraint fk_group_module_module foreign key (`module_oid`) references `module` (`oid`);


-- REL FK: defaultUsers [DefaultGroup2User]
alter table `user`   add index fk_user_group (`group_oid`), add constraint fk_user_group foreign key (`group_oid`) references `group` (`oid`);


-- REL FK: groups [User2Group]
alter table `user_group`   add index fk_user_group_user (`user_oid`), add constraint fk_user_group_user foreign key (`user_oid`) references `user` (`oid`);


-- REL FK: users [Group2User]
alter table `user_group`   add index fk_user_group_group (`group_oid`), add constraint fk_user_group_group foreign key (`group_oid`) references `group` (`oid`);


-- REL FK: CartToMusic [rel1#role1]
alter table `music`   add index fk_music_cart (`cart_oid`), add constraint fk_music_cart foreign key (`cart_oid`) references `cart` (`oid`);


-- REL FK: AlbumToMusic [rel10#role19]
alter table `music`   add index fk_music_album (`album_oid`), add constraint fk_music_album foreign key (`album_oid`) references `album` (`oid`);


-- REL FK: PlaylistToMusic [rel11#role22]
alter table `music`   add index fk_music_playlist (`playlist_oid`), add constraint fk_music_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);


-- REL FK: ArtistToMusic [rel14#role27]
alter table `music`   add index fk_music_artist (`artist_oid`), add constraint fk_music_artist foreign key (`artist_oid`) references `artist` (`oid`);


-- REL FK: GenreToMusic [rel19#role38]
alter table `music`   add index fk_music_genre (`genre_oid`), add constraint fk_music_genre foreign key (`genre_oid`) references `genre` (`oid`);


-- REL FK: UserToPlaylist [rel2#role7]
alter table `playlist`   add index fk_playlist_user (`user_oid`), add constraint fk_playlist_user foreign key (`user_oid`) references `user` (`oid`);


