-- HighlightGenre [ent11]
create table `highlightgenre` (
   `oid`  integer  not null,
  primary key (`oid`)
);


-- HighlightGenre_Genre [rel12]
alter table `highlightgenre`  add column  `genre_2_oid`  integer;
alter table `highlightgenre`   add index fk_highlightgenre_genre_2 (`genre_2_oid`), add constraint fk_highlightgenre_genre_2 foreign key (`genre_2_oid`) references `genre_2` (`oid`);


-- User_HighlightGenre [rel13]
alter table `highlightgenre`  add column  `user_oid`  integer;
alter table `highlightgenre`   add index fk_highlightgenre_user (`user_oid`), add constraint fk_highlightgenre_user foreign key (`user_oid`) references `user` (`oid`);


