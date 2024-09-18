
/*1. Implement the following requirements in SQL Server
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		a. Create a database :    ShoppingCartDb
				
		b.  Create a table :   Users
				Columns :  UserId , UserName, Password, ContactNumber, City
 		
		
		c. Create a table :   Products
				Columns and Constraints: 
						ProductId ---  Primary Key,
						Name   --   Not Null, 
						QuantityInStock ----   Not Null, Greater than Zero
						UnitPrice,   ----  Not null, Greater than Zero
						Category    ---  Not null
				
				
		d.  Create a table :  Cart
				Columns and  Constraints:  
						Id	---		Primary Key,  
						CartId  ----  NOT NULL, 
						ProductId  ---   Foreign Key with Products(ProductId), 
						Quantity   ---    Not Null,  Greater than zero 
				
 
				
	Hints :   	
			i.  Insert min. 5 records in each of the above table.
			ii. Try to verify the constraint functionality by inserting invalid data. */
CREATE DATABASE ShoppingCartDb

USE ShoppingCartDb;

DROP TABLE USERS

CREATE TABLE ShoppingCartDb.dbo.Users(
	UserId INT IDENTITY,
	UserName  VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL,
	ContactNumber BIGINT,
	City VARCHAR(50)
)

INSERT INTO Users Values('Sai','Sai123',1234567890,'Vuyyuru');
INSERT INTO Users Values('Varun','Varun321',6789012345,'Hyderabad');
INSERT INTO Users Values('Hari','Avvaru@507',8901234567,'Vijayawada');
INSERT INTO Users Values('Veera','Dasari123',7891234560,'Prakasam');
INSERT INTO Users Values('Viswa','Viswa456',1234567890,'Tadepalli');

--insert invalid data
INSERT INTO Users Values('Viswa',NULL,1234567890,'Tadepalli');
INSERT INTO Users Values(1,'Viswa',NULL,1234567890);

SELECT * FROM USERS;

CREATE TABLE ShoppingCartDb.dbo.Products(
	ProductId INT PRIMARY KEY,
	ProductName  VARCHAR(50) NOT NULL,
	QuantityInStock INT NOT NULL,CHECK(QuantityInStock > 0),
	UnitPrice FLOAT NOT NULL,CHECK(UnitPrice > 0),
	Category VARCHAR(50) NOT NULL
);


INSERT INTO Products Values(3245, 'Watch',5,5000,'Accessories');
INSERT INTO Products Values(2435, 'Diamond rings',10, 100000,'Ornaments');
INSERT INTO Products Values(8970, 'Chair',15,3000,'Furniture');
INSERT INTO Products Values(6578, 'Table',10,10000,'Furniture');
INSERT INTO Products Values(2178, 'TV',5,45000,'Electronic gadgets');

--inserting invalid data
INSERT INTO Products Values(NULL, 'TV',5,45000,'Electronic gadgets');
INSERT INTO Products Values(2678, 'TV',5,-11,'Electronic gadgets');


CREATE TABLE ShoppingCartDb.dbo.Cart(
	Id INT PRIMARY KEY,
	CartId INT NOT NULL,
	ProductId INT,
	Quantity INT NOT NULL,CHECK(Quantity > 0),
	CONSTRAINT Fk_Cart_Products FOREIGN KEY(ProductId)
	REFERENCES	Products(ProductId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
INSERT INTO Cart VALUES(1,2987,2178,2);
INSERT INTO Cart VALUES(2,8907,2178,1);
INSERT INTO Cart VALUES(3,1678,6578,5);
INSERT INTO Cart VALUES(4,2654,8970,7);
INSERT INTO Cart VALUES(5,3987,2435,2);
INSERT INTO Cart VALUES(6,5687,3245,3);

SELECT * FROM CART;
--inserting invalid data
INSERT INTO Cart VALUES(1,2987,1000,2);
INSERT INTO Cart VALUES(9,2987,2178,-1);



--2.  Write the select queries on the above tables for the following requirements:

--	 i.  On Product Table  
--			a.   Display all Products
			SELECT * FROM Products;

--			b.   Display Products belongs to particular category
			SELECT * FROM Products WHERE Category='Furniture';
--			c.   Display out of stock products (means quantity is zero)
			SELECT * FROM Products WHERE QuantityInStock=0;
--			d.  Display the products which price between 1000 to 10000 
			SELECT * FROM Products WHERE UnitPrice>1000 AND UnitPrice<10000;
--			e.  Display the product details based on the ProductId
			SELECT * FROM Products ORDER BY ProductId

 --   ii.   On Cart Table:
	--		a.  Display data based on the given CartId
			select * from Cart where CardId=1678;
	--		b.  Check is there any products added in Cart based on the ProductId
			SELECT P.ProductId,P.ProductName FROM Products P,Cart C 
			WHERE P.ProductId=C.ProductId;
			
	--iii.   On Users Table
	--		a. Display All users 
			SELECT * FROM Users;
	--		b. Display user details based on ContactNumber
			SELECT * FROM Users ORDER BY ContactNumber;
	--		c. Display user details based on UserId
			SELECT * FROM Users ORDER BY UserId;
						