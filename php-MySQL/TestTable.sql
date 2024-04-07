CREATE TABLE TestTable (
    id int(11) not null AUTO_INCREMENT,
    username varchar(30) not null,
    pwd varchar(255) not null,
    email varchar(100) not null,
    created_at datetime not null DEFAULT CURRENT_TIME,
    PRIMARY KEY (id)
    );