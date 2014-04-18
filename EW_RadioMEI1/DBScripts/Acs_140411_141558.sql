-- Playlist_Music [rel7]
create table `playlist_music` (
   `playlist_oid`  integer not null,
   `music_oid`  integer not null,
  primary key (`playlist_oid`, `music_oid`)
);
alter table `playlist_music`   add index fk_playlist_music_playlist (`playlist_oid`), add constraint fk_playlist_music_playlist foreign key (`playlist_oid`) references `playlist` (`oid`);
alter table `playlist_music`   add index fk_playlist_music_music (`music_oid`), add constraint fk_playlist_music_music foreign key (`music_oid`) references `music` (`oid`);


