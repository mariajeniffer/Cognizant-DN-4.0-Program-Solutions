CREATE PROCEDURE sp_CountEmployeesByDepartmentWithName
    @DepartmentID INT
AS
BEGIN
    SELECT 
        d.DepartmentName,
        COUNT(e.EmployeeID) AS TotalEmployees
    FROM Departments d
    LEFT JOIN Employees e ON d.DepartmentID = e.DepartmentID
    WHERE d.DepartmentID = @DepartmentID
    GROUP BY d.DepartmentName;
END;
GO


EXEC sp_CountEmployeesByDepartmentWithName 2;