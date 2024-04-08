/*
	1. Find total number of summer Olympic Games.
	2. Find how many games where each sport was played in
	3. compare 1. and 2,
*/
WITH t1 AS (
    SELECT COUNT(DISTINCT games) as total_summer_games from OLYMPICS_HISTORY
    WHERE season = 'Summer'
),
t2 as (
    SELECT distinct sport, games from OLYMPICS_HISTORY
    WHERE season = 'Summer' order by games
),
t3 as (
    select sport, count(games) as no_of_games from t2
    GROUP by sport
    )
SELECT * from t3
JOIN t1 on t1.total_summer_games = t3.no_of_games;