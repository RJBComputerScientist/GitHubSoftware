CREATE TABLE Pokemon (
    ID INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Height VARCHAR(50) NOT NULL,
    Weight VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID, AUTO_INCREMENT)
);

CREATE TABLE Type (
    ID INT NOT NULL,
    Name VARCHAR(100) UNIQUE NOT NULL,
    PRIMARY KEY (ID, AUTO_INCREMENT)
);

CREATE TABLE PokemonType (
    ID INT NOT NULL, 
    PokemonID INT NOT NULL,
    TypeID INT NOT NULL
    PRIMARY KEY (ID, AUTO_INCREMENT)
    FOREIGN KEY (PokemonID) REFERENCES Pokemon(ID),
    FOREIGN KEY (TypeID) REFERENCES Type(ID),
);
--AUTO-INCREMENT
--Auto-increment allows a unique number to be generated automatically when a new record is inserted into a table

INSERT Pokemon (Name, Height, Weight)
VALUES (Bulbasuar, 7, 70), (Ditto, 3, 40)

INSERT Type (Name)
VALUES (Grass), (Normal)

-- SELECT Name from Pokemon WHERE Name=Bulbasuar AND sel INNER JOIN Type(Name) 
-- SELECT Pokemon.Name, Type.Name from Pokemon, Type WHERE Pokemon.Name = Bulbasuar
SELECT Pokemon.ID, Type.ID FROM Pokemon, Type WHERE PokemonID = TypeID

--So Bulbasuar Name should link to Grass Type
--So Ditto Name should link to Normal Type