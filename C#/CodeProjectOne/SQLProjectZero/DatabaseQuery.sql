CREATE DATABASE TheBlock;

CREATE TABLE FoodStore (
    ID INT IDENTITY(1,1) NOT NULL,
    Name VARCHAR(250) NOT NUll,
    CustomerID VARCHAR(250) NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE ShoeStore (
    ID INT IDENTITY(1,1) NOT NULL,
    Name VARCHAR(250) NOT NUll,
    CustomerID VARCHAR(250) NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE InventoryType (
    ID INT IDENTITY(1,1) NOT NULL,
    FoodStoreID INT NOT NULL,
    ShoeStoreID INT NOT NULL,
);
CREATE TABLE Product (
    ID INT NOT NULL,
    Quantity INT,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Price DECIMAL NOT NULL,
    FoodStoreID INT NOT NULL,
    ShoeStoreID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (FoodStoreID) REFERENCES FoodStore(ID),
    FOREIGN KEY (ShoeStoreID) REFERENCES ShoeStore(ID),
);
CREATE TABLE FoodStoreInventory (
    ID INT NOT NULL,
    Quantity INT,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Price DECIMAL NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ID) REFERENCES Product(FoodStoreID),
    FOREIGN KEY (Quantity) REFERENCES Product(Quantity),
    FOREIGN KEY (Name) REFERENCES Product(Name),
    FOREIGN KEY (Type) REFERENCES Product(Type),
    FOREIGN KEY (Price) REFERENCES Product(Price),
);
CREATE TABLE ShoeStoreInventory (
    ID INT NOT NULL,
    Quantity INT,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Price DECIMAL NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ID) REFERENCES Product(ShoeStoreID),
    FOREIGN KEY (Quantity) REFERENCES Product(Quantity),
    FOREIGN KEY (Name) REFERENCES Product(Name),
    FOREIGN KEY (Type) REFERENCES Product(Type),
    FOREIGN KEY (Price) REFERENCES Product(Price),
);

DROP TABLE Product;
DROP TABLE FoodStoreInventory;
DROP TABLE ShoeStoreInventory;
DROP TABLE FoodStore;
DROP TABLE ShoeStore;
DROP TABLE InventoryType;