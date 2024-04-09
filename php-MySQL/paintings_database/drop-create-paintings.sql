DROP TABLE IF EXISTS artist;
CREATE TABLE if not exists artist (
    artist_id INT(5),
    full_name varchar(85),
    first_name varchar(25),
    middle_names varchar(30),
    last_name varchar(35),
    nationality varchar(25),
    style varchar(40),
    birth int(15),
    death int(15)
    );
DROP TABLE IF EXISTS canvas_size;
CREATE TABLE if not EXISTS canvas_size (
	size_id int(4),
    width int(2),
    height int(2) null,
    label varchar(15)
    );
DROP TABLE IF EXISTS museum_hours;
CREATE TABLE if not EXISTS museum_hours (
    museum_id int(2),
    day varchar(9),
    open varchar(8), 
    close varchar(8)
    );
DROP TABLE IF EXISTS museum;
CREATE TABLE if not EXISTS museum (
	museum_id int(2),
    name varchar(25),
    address varchar(50),
    city varchar(25),
    state varchar(2),
    postal varchar(15),
    country varchar(4),
    phone varchar(15),
    url varchar(25)
    );
DROP TABLE IF EXISTS subject;
CREATE TABLE IF NOT EXISTS subject (
    work_id int(6),
    subject varchar(50)
    );
DROP TABLE IF EXISTS work;
CREATE TABLE IF NOT EXISTS work ( 
	work_id int(6),
    name varchar(25),
    artist_id INT(5),
    style varchar(40),
    museum_id int(2)
    );