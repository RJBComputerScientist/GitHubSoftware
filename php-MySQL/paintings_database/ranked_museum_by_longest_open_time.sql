/*
	The 'STR_TO_DATE()' function interprets the input string based on the specified format and converts
    it into a 'TIME' value. 
    * '%h:%i %p' - '%h:%i': matches the hour and minutes format,
    * '%p': matches the AM?PM indicator
*/
select * from (
select m.name as museum_name, m.state, mh.day, STR_TO_DATE(open, '%h:%i:%p') as open_time, STR_TO_DATE(CLOSE, '%h:%i:%p') AS close_time,
Time(STR_TO_DATE(CLOSE, '%h:%i:%p') - STR_TO_DATE(open, '%h:%i:%p')) as duration,
rank() over(ORDER BY (Time(STR_TO_DATE(CLOSE, '%h:%i:%p') - STR_TO_DATE(open, '%h:%i:%p'))) DESC) as rnk
from museum_hours mh
join museum m on m.museum_id = mh.museum_id) ranked_museums
where ranked_museums.rnk = 1;