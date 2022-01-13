/*
 * This is for multi-line comments
 * all of this is in a comment
 */

--This is a single line comment

/*
 * DDL - Data Definition Language
 */
-- To create a Schema use the CREATE statement
CREATE SCHEMA examples;

--Use the DROP statement to remove Schemas
--CASCADE allows you to propagate changes across associated connections
--drop schema examples cascade;

--As its name implies, DROP IF EXISTS will drop an entity if it already exists in our DB
drop table if exists examples.lamas cascade;

--CREATE A TABLE:
create table examples.lamas (
--	<column_name> <column_type>,
	lama_id INTEGER, -- ID will be used to identify lamas
	lama_name VARCHAR(50), -- VARCHAR is typically used for string data
	lama_pounds DECIMAL,
	lama_style VARCHAR(20)
);

/*
 * DML - Data Manipulation Language
 */
--In SQL, String data within queries should use single quotes
insert into examples.lamas values (1000, 'Patty', 220, 'fire');
insert into examples.lamas values (1001, 'Matt', 200, 'earth');
insert into examples.lamas values (1002, 'Jill', 500, 'earth');
insert into examples.lamas values (1003, 'Phil', 300, 'wind');
insert into examples.lamas values (1004, 'Will', 500, 'earth');
insert into examples.lamas values (1005, 'Bob', 800, 'wind');
insert into examples.lamas values (1006, 'Sally', 200, 'earth');

--Values inserted into our tables are case-sensitive
insert into examples.lamas values (1007, 'Sarah', 50000, 'earth');
insert into examples.lamas values (1008, 'Bobby', 50000, 'earth');

--You do not need the schema qualifier if you have selected the schema in DBeaver specifically
update lamas set lama_name='Gill' where lama_id=1002;
UPDATE examples.lamas SET lama_POUNDS=1000 WHERE lama_id = 1000;

--Remove all records from lamas table
--delete from examples.lamas;

--Remove a specific record
--delete from examples.lamas where lama_style='fire';
delete from examples.lamas where lama_id=1000;

commit;