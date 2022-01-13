-- The asterisk is used to reference all columns
select * from lamas;

--We can specify columns if we do not need all data
select lama_id, lama_name from examples.lamas;


/* WHERE STATEMENT */
select * from lamas where lama_salary > 70000;
select lama_name, lama_type from lamas where lama_id = 1000;

/* GROUP BY */
select sum(lama_salary), lama_type from examples.lamas group by lama_type;
select lama_type from lamas  group by lama_type;
select lama_type from lamas;

/* HAVING */
select sum(lama_salary), lama_type from examples.lamas 
group by lama_type having sum(lama_salary) > 175000;

/* ORDER BY */
select * from lamas;
--ORDER BY uses an ascending or descending order
select * from lamas order by lama_salary desc;
--We can include multiple columns to order by using a comma to separate
select * from lamas order by lama_type desc, lama_salary asc;
--Upper case letters have a 'higher' value, so they are first when we descend the ordering

/* ALL TOGETHER */
select avg(lama_salary), lama_type
from examples.lamas
where lama_salary < 100000
group by lama_type
having avg (lama_salary) < 75000
order by lama_type;

--AS is used to specify an 'alias' for data we retrieve from our db
--Use double-quotes when we do not insert the string into a table
select lama_salary as "Money" from lamas;

/* LIKE */
-- for strings the % is used for a wildcard for any number of characters
select * from lamas where lower(lama_name) like '%a%';


--lama_name = 'Dan' <-- WILL WORK
--lama_name = 'Hal' <-- WILL WORK
--lama_name = 'Aaron' <-- WILL WORK
--lama_name = 'Heather' <-- NOT WORK
SELECT * FROM lamas WHERE lower(lama_name) LIKE '___a%';

-- for strings the _ is used for a wildcard for a single character
select * from lamas where lower(lama_name) like 's_%a%';

/* BETWEEN */
--Use the 'AND' keyword to specify upper and lower limits of a BETWEEN operation
select * from lamas where lama_salary between 45000 and 75000;
SELECT lama_name, lama_salary FROM lamas WHERE lama_salary BETWEEN 50000 AND 70000;


/* IN */
select * from lamas where lower(lama_type) in ('lamas', 'wind');
SELECT lama_name, lama_type FROM examples.lamas WHERE lower(lama_type) IN ('water');