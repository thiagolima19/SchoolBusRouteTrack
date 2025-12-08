-- 1️⃣ Create Database
CREATE DATABASE SchoolBusRouteTrackerDB;
GO
USE SchoolBusRouteTrackerDB;
GO

-- 2️⃣ Users Table
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO

INSERT INTO [User] (Username, Password, Role)
VALUES ('admin', 'admin123', 'Admin'),
       ('driver', 'driver123', 'Driver');
GO

-- 3️⃣ School Table
CREATE TABLE School (
    SchoolID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Board NVARCHAR(50) NULL
);
GO

INSERT INTO School (Name, Address, PhoneNumber, Board)
VALUES 
('Central School', '100 Central St', '555-1111', 'Public'),
('West School', '500 West Ave', '555-2222', 'Public'),
('East School', '800 East Blvd', '555-3333', 'Public');
GO

-- 4️⃣ Stop Table (NO RouteID here)
CREATE TABLE Stop (
    StopID INT IDENTITY(1,1) PRIMARY KEY,
    Address NVARCHAR(255) NOT NULL,
    Latitude FLOAT NOT NULL,
    Longitude FLOAT NOT NULL
);
GO

INSERT INTO Stop (Address, Latitude, Longitude)
VALUES
('Main Ave & 1st St', -23.5505, -46.6333),
('Central Park Entrance', -23.5512, -46.6301),
('Central School Gate', -23.5520, -46.6280),

('Maple St & 9th Ave', -23.5620, -46.6400),
('West Plaza', -23.5650, -46.6420),
('West School Gate', -23.5675, -46.6450),

('Riverside Bridge', -23.5590, -46.6200),
('Green Market', -23.5605, -46.6180),
('East School Gate', -23.5620, -46.6150);
GO

-- 5️⃣ Student Table
CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Latitude FLOAT NOT NULL,
    Longitude FLOAT NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Grade NVARCHAR(10) NOT NULL,
    GuardianName NVARCHAR(100) NOT NULL,
    GuardianRelationship NVARCHAR(50) NOT NULL,
    GuardianPhone NVARCHAR(20) NOT NULL,
    SchoolID INT NOT NULL,
    StopID INT NULL,
    SpecialCare NVARCHAR(255) NULL,
    CONSTRAINT FK_Student_School FOREIGN KEY (SchoolID) REFERENCES School(SchoolID),
    CONSTRAINT FK_Student_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID)
);
GO

-- Student CRUD Procedures
CREATE PROCEDURE sp_InsertStudent
    @FullName NVARCHAR(100),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Address NVARCHAR(255),
    @Grade NVARCHAR(10),
    @GuardianName NVARCHAR(100),
    @GuardianRelationship NVARCHAR(50),
    @GuardianPhone NVARCHAR(20),
    @SchoolID INT,
    @StopID INT = NULL,
    @SpecialCare NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO Student(
        FullName, Latitude, Longitude, Address, Grade,
        GuardianName, GuardianRelationship, GuardianPhone,
        SchoolID, StopID, SpecialCare)
    VALUES (
        @FullName, @Latitude, @Longitude, @Address, @Grade,
        @GuardianName, @GuardianRelationship, @GuardianPhone,
        @SchoolID, @StopID, @SpecialCare);
END;
GO

CREATE PROCEDURE sp_GetAllStudents AS
BEGIN
    SELECT S.*, SC.Name AS SchoolName
    FROM Student S
    JOIN School SC ON S.SchoolID = SC.SchoolID
    ORDER BY FullName;
END;
GO

CREATE PROCEDURE sp_DeleteStudent @StudentID INT AS
BEGIN
    DELETE FROM Student WHERE StudentID = @StudentID;
END;
GO

CREATE PROCEDURE sp_UpdateStudent
    @StudentID INT,
    @FullName NVARCHAR(100),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Address NVARCHAR(255),
    @Grade NVARCHAR(10),
    @GuardianName NVARCHAR(100),
    @GuardianRelationship NVARCHAR(50),
    @GuardianPhone NVARCHAR(20),
    @SchoolID INT,
    @StopID INT = NULL,
    @SpecialCare NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE Student SET
        FullName=@FullName, Latitude=@Latitude, Longitude=@Longitude,
        Address=@Address, Grade=@Grade, GuardianName=@GuardianName,
        GuardianRelationship=@GuardianRelationship, GuardianPhone=@GuardianPhone,
        SchoolID=@SchoolID, StopID=@StopID, SpecialCare=@SpecialCare
    WHERE StudentID=@StudentID;
END;
GO

-- 6️⃣ Vehicle Table
CREATE TABLE Vehicle (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Plate NVARCHAR(20) NOT NULL UNIQUE,
    Company NVARCHAR(100) NULL,
    Type NVARCHAR(20) NOT NULL,
    Available BIT NOT NULL DEFAULT 1,
    NumberOfSeats INT NOT NULL DEFAULT 30
);
GO

INSERT INTO Vehicle (Plate, Company, Type)
VALUES ('ABC1234','BusCo','Large'),
       ('XYZ5678','BusCo','Small');
GO

-- 7️⃣ Driver Table
CREATE TABLE Driver (
    DriverID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Inactive'
);
GO

INSERT INTO Driver (FullName, Phone)
VALUES ('John Driver','999-1000'),
       ('Jake Pilot','999-2000');
GO

-- Driver CRUD
CREATE PROCEDURE GetAllDrivers AS SELECT * FROM Driver ORDER BY FullName;
GO

-- 8️⃣ Route Table + Link to School
CREATE TABLE Route (
    RouteID INT IDENTITY(1,1) PRIMARY KEY,
    RouteNumber NVARCHAR(20) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    SchoolID INT NOT NULL,
    DriverID INT NULL,
    VehicleID INT NULL,
    CONSTRAINT FK_Route_School FOREIGN KEY (SchoolID) REFERENCES School(SchoolID),
    CONSTRAINT FK_Route_Driver FOREIGN KEY (DriverID) REFERENCES Driver(DriverID),
    CONSTRAINT FK_Route_Vehicle FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);
GO

INSERT INTO Route (RouteNumber, Description, SchoolID)
VALUES ('R001','To Central School',1),
       ('R002','To West School',2),
       ('R003','To East School',3);
GO

-- 9️⃣ RouteStop: Ordered Stop Sequence per Route
CREATE TABLE RouteStop (
    RouteStopID INT IDENTITY(1,1) PRIMARY KEY,
    RouteID INT NOT NULL,
    StopID INT NOT NULL,
    OrderNumber INT NOT NULL,
    CONSTRAINT FK_RouteStop_Route FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    CONSTRAINT FK_RouteStop_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID)
);
GO

-- Route → Stop mapping
INSERT INTO RouteStop (RouteID, StopID, OrderNumber)
VALUES
(1,1,1),(1,2,2),(1,3,3),
(2,4,1),(2,5,2),(2,6,3),
(3,7,1),(3,8,2),(3,9,3);
GO

select * from route
select * From stop
select * from routestop


-- 🔟 Trip Table
CREATE TABLE Trip (
    TripID INT IDENTITY(1,1) PRIMARY KEY,
    RouteID INT NOT NULL,
    DriverID INT NOT NULL,
    StartTime DATETIME NULL,
    EndTime DATETIME NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Scheduled',
    CONSTRAINT FK_Trip_Route FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    CONSTRAINT FK_Trip_Driver FOREIGN KEY (DriverID) REFERENCES Driver(DriverID)
);
GO

-- Trip Procedures
CREATE PROCEDURE GetTripsByRoute @RouteID INT AS
BEGIN SELECT * FROM Trip WHERE RouteID=@RouteID; END;
GO

-- 1️⃣1️⃣ Trip Attendance
CREATE TABLE TripAttendance (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    TripID INT NOT NULL,
    StudentID INT NOT NULL,
    StopID INT NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    Time DATETIME NULL,
    CONSTRAINT FK_Att_Trip FOREIGN KEY (TripID) REFERENCES Trip(TripID),
    CONSTRAINT FK_Att_Student FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    CONSTRAINT FK_Att_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID)
);
GO

CREATE PROCEDURE MarkAttendance
    @TripID INT,
    @StudentID INT,
    @StopID INT,
    @Status NVARCHAR(20),
    @Time DATETIME
AS
BEGIN
    INSERT INTO TripAttendance (TripID, StudentID, StopID, Status, Time)
    VALUES (@TripID, @StudentID, @StopID, @Status, @Time);
END;
GO

CREATE PROCEDURE GetAttendanceByTrip @TripID INT AS
BEGIN
    SELECT TA.*, S.FullName
    FROM TripAttendance TA
    JOIN Student S ON TA.StudentID = S.StudentID
    WHERE TA.TripID = @TripID;
END;
GO

-- 1️⃣2️⃣ Trip Reports
CREATE TABLE Report (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    TripID INT NOT NULL,
    ReportDate DATE NOT NULL DEFAULT GETDATE(),
    TotalStudents INT NOT NULL DEFAULT 0,
    TotalPresent INT NOT NULL DEFAULT 0,
    TotalAbsent INT NOT NULL DEFAULT 0,
    TotalDelays INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Report_Trip FOREIGN KEY (TripID) REFERENCES Trip(TripID)
);
GO
