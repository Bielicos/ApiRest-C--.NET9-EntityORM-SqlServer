IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'student')
BEGIN
    CREATE DATABASE student;
END
GO