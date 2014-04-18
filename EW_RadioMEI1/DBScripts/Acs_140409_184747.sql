-- GenreMusic_Music [rel5]
create table `genremusic_music` (
   `genre_2_oid`  integer not null,
   `music_oid`  integer not null,
  primary key (`genre_2_oid`, `music_oid`)
);
alter table `genremusic_music`   add index fk_genremusic_music_genre_2 (`genre_2_oid`), add constraint fk_genremusic_music_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);
alter table `genremusic_music`   add index fk_genremusic_music_music (`music_oid`), add constraint fk_genremusic_music_music foreign key (`music_oid`) references `music` (`oid`);


