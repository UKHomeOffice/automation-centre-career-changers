# Kata 8 - SQL Basics

## Objective

Learn the fundamentals of SQL by creating a simple database, defining tables, and performing basic queries. This kata will help you understand how to interact with relational databases using SQL inside VS Code

## Prerequisites

- Completion of **Kata 1 – Environment Setup**
- SQL Server installed and running (refer to the installation steps in Kata 1)

### Add SQLServer Into Docker

This is a one off step to set up a SQL Server instance using Docker. You will learn more about Docker in the future, but this is a minimal step to get you started.

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=DevPassword1" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

If you have already set up SQL Server and it is not running. You can start the container with:

```bash
docker start sqlserver
```

## Steps

### Step 1: Connect to SQL Server in VS Code

1. Open VS Code.
2. Install the "SQL Server (mssql)" extension if you haven't already.
3. Open "SQL Server" in the left menu (looks like a server icon).
4. Click on "Add Connection" (the +).
5. Fill in the connection details:
   - Server name: `localhost`
   - Authentication Type: `SQL Login`
   - User name: `sa`
   - Password: `DevPassword1`
6. Click "Connect".
7. You should now see your SQL Server instance in the SQL Server explorer.

### Step 2: Create a New Database and Table

1. In the SQL Server explorer, right-click on your server and select "New Query".
2. Enter the following SQL commands to create a new database and a table:

```sql
CREATE DATABASE MyFirstDB;
GO

USE MyFirstDB;
GO
```

3. Now create a table called `Employees`:

```sql
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    BirthDate DATE,
    HireDate DATE
);
GO
```

4. Execute the query by clicking the "Run" button (green play icon).

### Step 3: Insert Data into the Table

1. In the same query window, insert some sample data into the `Employees` table:

```sql
INSERT INTO Employees (EmployeeID, FirstName, LastName, BirthDate, HireDate)
VALUES
(1, 'John', 'Doe', '1980-01-15', '2020-06-01'),
(2, 'Jane', 'Smith', '1990-03-22', '2021-07-15'),
(3, 'Michael', 'Johnson', '1985-11-30', '2019-09-23');
GO
```

2. Execute the query.

### Step 4: Query the Data

1. Now, retrieve the data you just inserted by running a SELECT query:

```sql
SELECT * FROM Employees;
GO
```

2. Execute the query and observe the results in the output pane.

### Step 5: Filtering Data

1. Try filtering the data to find employees hired after January 1, 2020:

```sql
SELECT * FROM Employees
WHERE HireDate > '2020-01-01';
GO
```

2. Execute the query and observe the filtered results.

### Step 6: Update Data

1. Update an employee's last name:

```sql
UPDATE Employees
SET LastName = 'White'
WHERE EmployeeID = 2;
GO
```

2. Execute the query.

### Step 7: Delete Data

1. Delete an employee record:

```sql
DELETE FROM Employees
WHERE EmployeeID = 3;
GO
```

2. Execute the query.

### Step 8: Verify Changes

1. Run a SELECT query again to verify the updates and deletions:

```sql
SELECT * FROM Employees;
GO
```

2. Execute the query and observe the final results.

## Completion Criteria

- Successfully created a database and table in SQL Server.
- Inserted, queried, updated, and deleted data using SQL commands.
- Demonstrated understanding of basic SQL operations within VS Code.

## Resources

- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [SQL Tutorial](https://www.w3schools.com/sql/)
