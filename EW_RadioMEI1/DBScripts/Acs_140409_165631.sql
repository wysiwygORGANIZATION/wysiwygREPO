-- Music.artistname [ent8#att7]
create view `music_artistname_view` as
select AL1.`oid` as `oid`, AL2.`name` as `der_attr`
from  `music` AL1 
               left outer join `artist` AL2 on AL1.`artist_oid`=AL2.`oid`;


