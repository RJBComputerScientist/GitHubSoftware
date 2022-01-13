--As its name implies, DROP IF EXISTS will drop an entity if it already exists in our DB
drop table if exists examples.lamas CASCADE;
DROP SEQUENCE IF EXISTS lama_id_seq;
DROP FUNCTION IF EXISTS lama_id_func;
--WHEN YOU DROP A TRIGGER, YOU MUST SPECIFY THE TABLE IT IS ASSOCIATED WITH
DROP TRIGGER IF EXISTS lama_id_trig ON examples.lamas;

--CREATE A TABLE:
create table examples.lamas (
--	<column_name> <column_type>,
	lama_id INTEGER PRIMARY KEY, -- ID will be used to identify lamas
	lama_name VARCHAR(50), -- VARCHAR is typically used for string data
	lama_salary DECIMAL,
	lama_style VARCHAR(20)
);

--SEQUENCES ARE USED TO MANAGE A COUNTER
CREATE SEQUENCE lama_id_seq START WITH 1000 INCREMENT BY 2;

--FUNCTIONS: PERFORM A SERIES OF OPERATIONS AS SPECIFIED WITHIN THE BODY OF THE FUNCTION
CREATE OR REPLACE FUNCTION lama_id_func() RETURNS TRIGGER AS
$$ 
BEGIN
	IF NEW.lama_id IS NULL THEN
		NEW.lama_id:=NEXTVAL('lama_id_seq');
		RETURN NEW;
	END IF;
END;
$$ LANGUAGE PLPGSQL;

--TRIGGERS ARE ENTITIES WHICH WAIT FOR A SPECIFIED EVENT TO PERFORM AN ACTION
CREATE TRIGGER lama_id_trig 
BEFORE INSERT ON examples.lamas
FOR EACH ROW
EXECUTE PROCEDURE lama_id_func();


insert into examples.lamas values (null, 'Patty', 120000, 'fire');
insert into examples.lamas values (null, 'Matt', 45000, 'earth');
insert into examples.lamas values (null, 'Jill', 50000, 'earth');
insert into examples.lamas values (null, 'Phil', 75000, 'wins');
insert into examples.lamas values (null, 'Will', 55000, 'earth');
insert into examples.lamas values (null, 'Bob', 80000, 'wind');
insert into examples.lamas values (null, 'Sally', 52000, 'earth');
insert into examples.lamas values (null, 'Sarah', 50000, 'earth');
insert into examples.lamas values (null, 'Bobby', 50000, 'earth');