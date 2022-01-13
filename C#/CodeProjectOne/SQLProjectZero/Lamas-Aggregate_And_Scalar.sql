--AGGREGATE FUNCTION : Performed across an entire COLUMN, AND RETURN a single RESULT
SELECT MIN(lama_pounds) FROM examples.LAMAS;
SELECT AVG(lama_pounds) FROM examples.LAMAS;

--WINDOW FUNCTIONS: 
SELECT lama_name, lama_style, FIRST_VALUE(lama_pounds) OVER() FROM lamas;
SELECT lama_name, lama_style, FIRST_VALUE(lama_pounds) OVER(ORDER BY lama_name desc) FROM lamas;
SELECT lama_name, lama_style, FIRST_VALUE(lama_pounds) OVER(PARTITION BY lama_style ORDER BY lama_name desc) FROM lamas;
SELECT lama_name, lama_style, FIRST_VALUE(lama_pounds) OVER(PARTITION BY lama_style ORDER BY lama_name ASC) FROM lamas;

--SCALAR FUNCTIONS: 
--STRING FUNCTIONS:
SELECT UPPER(lama_name) FROM LAMAS;
SELECT CHAR_LENGTH(lama_name) FROM LAMAS;
SELECT ('Hello ' || 'World!'); -- String concatenation in SQL is performed with two pipes '||'

--MATHEMATICAL FUNCTIONS:
SELECT ABS(lama_pounds) FROM LAMAS;
SELECT ABS(-175);

SELECT * FROM lamas WHERE lama_name IN ('Matt', 'Phil', 'Bob');
SELECT * FROM lamas WHERE lama_name LIKE '%i%';