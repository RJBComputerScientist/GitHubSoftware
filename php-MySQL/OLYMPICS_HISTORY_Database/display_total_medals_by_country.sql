/*
	Here I am making 'bronze', 'silver' & 'gold' into their own columns while recognizing that the
    medals cant equal NA and the regions are equal from 'OLYMPICS_HISTORY' & 'OLYMPICS_HISTORY_NOC_REGIONS' tables
    
    This is called pivoting columns!
*/
  SELECT 
    	nr.region as country, 
    	SUM(case when medal = 'bronze' then 1 else 0 end) as 'bronze', 
    	SUM(case when medal = 'gold' then 1 else 0 end) as 'gold', 
        SUM(case when medal = 'silver' then 1 else 0 end) as 'silver'

from OLYMPICS_HISTORY as oh
join OLYMPICS_HISTORY_NOC_REGIONS as nr on nr.noc = oh.noc
WHERE medal <> 'NA'
GROUP BY country
ORDER BY country


