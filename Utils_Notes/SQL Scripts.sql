CREATE TABLE Expenses (
	ExpenseID UUID  PRIMARY KEY,
	ExpenseDate TIMESTAMP NOT NULL,
	ExpenseName VARCHAR(100) NOT NULL,
	ExpenseType VARCHAR(50) NOT NULL
);

--DROP TABLE Expenses;
CREATE TABLE Expenses (
	ExpenseID UUID PRIMARY KEY,
	EffDate TIMESTAMP NOT NULL,
	ExpenseDate DATE NOT NULL,
	Description VARCHAR(200) NOT NULL,
	Amount NUMERIC(8, 2) NOT NULL,
	ExpenseCategoryID UUID NOT NULL
);

--DROP TABLE ExpenseCategories
CREATE TABLE ExpenseCategories (
	ExpenseCategoryID UUID NOT NULL PRIMARY KEY,
	EffDate TIMESTAMP NOT NULL DEFAULT NOW(),
	Name VARCHAR(100) NOT NULL,
	Description VARCHAR(200) NOT NULL
);


PREPARE formattedQuery(UUID, VARCHAR, VARCHAR) AS
INSERT INTO ExpenseCategories
(ExpenseCategoryID, Name, Description)
VALUES ($1, $2, $3);
EXECUTE formattedQuery('5b11292a-b75e-4782-a0f3-2364f015cee3', 'Rent', 'pls');