SELECT m.name as museum_name, m.city from museum_hours mh1
join museum m on m.museum_id = mh1.museum_id
where day = 'Sunday' and EXISTS
(select 1 from museum_hours mh2 WHERE
 mh2.museum_id = mh1.museum_id AND
 mh2.day = 'Monday')