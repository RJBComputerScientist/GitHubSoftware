DROP TABLE IF EXISTS OLYMPICS_HISTORY;
CREATE TABLE IF NOT EXISTS OLYMPICS_HISTORY (
    id BIGINT UNSIGNED,
    name VARCHAR(100),
    sex         VARCHAR(50),
    age         VARCHAR(20),
    height      VARCHAR(20),
    weight      VARCHAR(40),
    team        VARCHAR(50),
    noc         VARCHAR(100),
    games       VARCHAR(150),
    year        INT(75),
    season      VARCHAR(150),
    city        VARCHAR(150),
    sport       VARCHAR(100),
    event       VARCHAR(175),
    medal       VARCHAR(50)
    );
    
DROP TABLE IF EXISTS OLYMPICS_HISTORY_NOC_REGIONS;
CREATE TABLE IF NOT EXISTS OLYMPICS_HISTORY_NOC_REGIONS (
    noc VARCHAR(100),
    region VARCHAR(125),
    notes VARCHAR(255)
    )