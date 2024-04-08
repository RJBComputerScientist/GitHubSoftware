DROP TABLE IF EXISTS OLYMPICS_HISTORY;
CREATE TABLE IF NOT EXISTS OLYMPICS_HISTORY (
    id INT(6),
    name VARCHAR(110),
    sex         VARCHAR(1),
    age         VARCHAR(2),
    height      VARCHAR(3),
    weight      VARCHAR(16),
    team        VARCHAR(47),
    noc         VARCHAR(3),
    games       VARCHAR(11),
    year        INT(4),
    season      VARCHAR(6),
    city        VARCHAR(22),
    sport       VARCHAR(25),
    event       VARCHAR(85),
    medal       VARCHAR(6)
    );
    
DROP TABLE IF EXISTS OLYMPICS_HISTORY_NOC_REGIONS;
CREATE TABLE IF NOT EXISTS OLYMPICS_HISTORY_NOC_REGIONS (
    noc VARCHAR(100),
    region VARCHAR(125),
    notes VARCHAR(255)
    )