--TCL - Transaction Control Language
select * from lamas; -- 1
delete from lamas where lama_id=2000;
delete from lamas where lama_id=2001;
delete from lamas where lama_id=2002;

drop table lamas;

/*
 * WITHOUT 'begin' and 'commit' you are not rolling multiple operations
 * into a single transaction, you are instead performing isolated transactions
 * on your database, and as such, do not have the room to utilize TCL commands
 */
begin;
	-- you can create multiple savepoints
	savepoint my_save_1;
	insert into examples.lamas values (2000, 'Sal', 500, 'earth');
	savepoint my_save_2;
select * from lamas; -- 2
	insert into examples.lamas values (2001, 'Pal', 670, 'earth');
	savepoint my_save_3;

--select * from lamas; -- 3

	rollback to savepoint my_save_1;
select * from lamas; -- 4

	insert into examples.lamas values (2002, 'Hal', 790, 'wind');
	release savepoint my_save;
select * from lamas; -- 5

commit;