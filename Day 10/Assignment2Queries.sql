--New! Keyboard shortcuts … Drive keyboard shortcuts have been updated to give you first-letters navigation
--// Products :  ProductId, Name, QuantityInStock, UnitPrice, Category
--// Cart   :  Id,  CartId, ProductId, Quantity
 
--2.1. Write the sql queries for the following requirements  by using joins concept:

--	a. Consider the Products table and Cart table 
--	b. Write a Query to display the results from the above two tables:
--			CartId,  ProductName, Quantity, UnitPrice
			
--		Hint :  Quantity should takes from Cart table
			
--	c.  Try to appy inner join,  right outer join , left outer join and full outer join on the above tables.
	SELECT CartId,ProductName,Quantity,UnitPrice FROM Products 
	INNER JOIN Cart 
	ON Products.ProductId=Cart.ProductId;

	SELECT CartId,ProductName,Quantity,UnitPrice FROM Products 
	LEFT OUTER JOIN Cart 
	ON Products.ProductId=Cart.ProductId;

	SELECT CartId,ProductName,Quantity,UnitPrice FROM Products 
	RIGHT OUTER JOIN Cart 
	ON Products.ProductId=Cart.ProductId;

	SELECT CartId,ProductName,Quantity,UnitPrice FROM Products 
	FULL OUTER JOIN Cart 
	ON Products.ProductId=Cart.ProductId;
 
--2.2. Write the sql queries for the following requirements  by using Group By concept:

--	Hint :   -->   Create a table Called "Student"  table with the following columns:
--							StudentId,  StudentName,  CourseName,  City Name, ContactNumber
					CREATE TABLE Student(
						StudentId INT PRIMARY KEY,
						StudentName VARCHAR(30) NOT NULL,
						CourseName VARCHAR(30) NOT NULL,
						CityName VARCHAR(50) NOT NULL,
						ContactNumber BIGINT NOT NULL
					)
--					-->   Insert some 10 rows in the above table.

INSERT INTO Student VALUES(1,'Sai','Angular','Hyderabad',1234567890);
INSERT INTO Student VALUES(2,'Hari','Angular','Chennai',7890123456);
INSERT INTO Student VALUES(3,'Prasanth','SQL','Pune',1567823490);
INSERT INTO Student VALUES(4,'Pavan Kalyan','Angular','Hyderabad',3451267890);
INSERT INTO Student VALUES(5,'Ramcharan','ASP.NET','Chennai',4567812390);
INSERT INTO Student VALUES(6,'Allu arjun','TypeScript','Pune',1456723890);
INSERT INTO Student VALUES(7,'Hema','Angular','Mumbai',1234567890);
INSERT INTO Student VALUES(8,'Veera','ASP.NET','Hyderabad',4567812390);
INSERT INTO Student VALUES(9,'Varun','Java','Vizag',7890123456);
INSERT INTO Student VALUES(10,'Akhila','Angular','Hyderabad',5678901234);
--	a.   Find out how many Students are joined for "Angular"  Course
	SELECT COUNT(*) AS STUDENTS_JOINED_IN_ANGULAR FROM Student WHERE CourseName='Angular';
--	b.   Find out how many Students are joined from  "Hyderabad"  City
	SELECT COUNT(*) AS STUDENTS_JOINED_IN_HYDERABAD FROM Student WHERE CityName='Hyderabad';
--	c.    Display No. of Students are join from each  City based 
	SELECT CityName, COUNT(*) AS STUDENTS_JOINED FROM Student GROUP BY CityName;
--			Sample Output:
--						Hyderabad    10
--						Mumbai   20
--						Pune   5
--						.....
	
--	d.    Display No. of Students are join from each  Course  based 
--			Sample Outupt:
--					Angular    10
--					React       20
--					.NET        30
--					....... 
	SELECT CourseName, COUNT(*) AS STUDENTS_JOINED FROM Student GROUP BY CourseName;				
--	e.     Display the counts  by grouping based on  city, course 
	SELECT CityName,CourseName, COUNT(*) AS STUDENTS_JOINED FROM Student GROUP BY CityName,CourseName;
 
	
--2.3.  Prepare the sql queries for the following requirements (use subqueries):
			
--			a.   Display the products if any items exists in the cart table
			SELECT ProductId,ProductName FROM Products
			WHERE ProductId IN
			(SELECT ProductId FROM Cart );
--			b.   Display the cart items whoe product price greater than 5000 
			SELECT * FROM Products
			WHERE ProductId IN
			(SELECT ProductId FROM Cart ) AND UnitPrice>5000;
	
			