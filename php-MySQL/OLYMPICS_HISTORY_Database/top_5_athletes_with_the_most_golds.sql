/*
	rank() - This function will assign rank to each row within a partition with gaps. Here, ranks are assigned in a
     non-consecutive manner i.e if there is a tie between values then they will be assigned same rank, and next rank 
     value will be previous rank + no of peers(duplicates).
    
    dense_rank() - This function will assign rank to each row within a partition without gaps. Basically, 
    the ranks are assigned in a consecutive manner i.e if there is a tie between values then they will be assigned 
    the same rank, and next rank value will be one greater than the previous rank assigned.
*/
with t1 as
	(select name, count(1) from OLYMPICS_HISTORY
	WHERE medal = 'Gold'
	GROUP BY name
	ORDER BY COUNT(1) desc),
t2 as (
    SELECT *, dense_rank() over(order by total_medals desc) as rnk
    from t1)
   SELECT * FROM t2
   where tnk <= 5;