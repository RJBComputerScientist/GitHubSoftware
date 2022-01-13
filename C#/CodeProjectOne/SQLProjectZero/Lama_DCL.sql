/*
 * Before dropping a user, we must remove privileges 
 * because our DB will recognize that this user has certain
 * power to manipulate data within a specific table/tables 
 */
REVOKE ALL PRIVILEGES ON examples.employees FROM lama1;
REVOKE ALL PRIVILEGES ON SCHEMA examples FROM lama1;
REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA examples FROM lama1;
REVOKE ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA examples FROM lama1;

-- we can use 'if exists' to check that the user exists before 
-- dropping users as well
DROP USER IF EXISTS lama1;

--Use the create statement to create users as well
CREATE USER lama1 WITH PASSWORD 'password';

--GRANT <permission> ON <ENTITY> TO <USER_NAME>
GRANT INSERT ON examples.lamas TO lama1;
GRANT SELECT, UPDATE, DELETE ON examples.lamas TO lama1;
GRANT USAGE ON SCHEMA examples TO lama1;

--Allows lama1 to use all Sequences
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO lama1;

--Allow lama1 to execute all functions
GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO lama1;

GRANT CREATE ON SCHEMA examples TO lama1;
--REVOKE <permission> ON <ENTITY> FROM <USER_NAME>
REVOKE CREATE ON SCHEMA examples FROM lama1;
