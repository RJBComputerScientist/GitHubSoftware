/*
	GROUP_CONCAT() concats values from multiple rows into a single row
*/

with cte_country as(
	SELECT country, count(1), rank() over(order by count(1) desc) as rank
    from museum
	group by country
),
 cte_city as (
	SELECT city, count(1), rank() over(order by count(1) desc) as rank
    from museum
	group by city
	order by count(1) DESC
    )
select 
concat_WS(', ', GROUP_CONCAT(DISTINCT country order by country SEPARATOR ', ')) as country, 
concat_WS(', ', GROUP_CONCAT(city order by city SEPARATOR ', ')) as city
from cte_country
cross join cte_city
WHERE cte_country.rank = 1
and cte_city.rank = 1