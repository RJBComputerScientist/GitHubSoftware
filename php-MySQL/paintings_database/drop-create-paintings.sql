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
    height int(2),
    label varchar(30)
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
    name varchar(50),
    address varchar(75),
    city varchar(30),
    state varchar(25),
    postal varchar(15),
    country varchar(50),
    phone varchar(25),
    url varchar(150)
    );
DROP TABLE IF EXISTS subject;
CREATE TABLE IF NOT EXISTS subject (
    work_id int(6),
    subject varchar(50)
    );
