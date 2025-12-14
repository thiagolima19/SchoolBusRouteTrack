USE master;
GO

-- Check if database exists before dropping
IF DB_ID('SchoolBusRouteTrackerDB') IS NOT NULL
BEGIN
    -- Close existing connections
    ALTER DATABASE SchoolBusRouteTrackerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SchoolBusRouteTrackerDB;
END
GO

-- Create Database
CREATE DATABASE SchoolBusRouteTrackerDB;
GO

USE SchoolBusRouteTrackerDB;
GO

-- Create School table first (needed for foreign keys)
CREATE TABLE School (
    SchoolID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Address NVARCHAR(255) NOT NULL,
    PostalCode NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Board NVARCHAR(50),
    Latitude FLOAT,
    Longitude FLOAT
);
GO

-- Insert Schools with Calgary coordinates
INSERT INTO School (Name, Address, PostalCode, PhoneNumber, Board, Latitude, Longitude)
VALUES
('Central School', '4804 6 St SW, Calgary, AB', 'T2S 2N3', '403-265-4500', 'Public', 51.01335243282962, -114.07815940532772),
('West School', '8706 Elbow Dr SW, Calgary, AB', 'T2V 1L2', '403-777-8901', 'Public', 50.97790271515156, -114.08469600307373),
('East School', '395 Canterbury Dr SW, Calgary, AB', 'T2W 1J1', '403-456-7890', 'Public', 50.94872024382864, -114.07852672230477),
('North Academy', '5505 4a St SW, Calgary, AB', 'T2V 0E9', '403-234-5678', 'Private', 51.00675851718779, -114.0733525254393),
('South Academy', '7112 7 St SW, Calgary, AB', 'T2V 1E9', '403-345-6789', 'Private', 50.993249477792524, -114.08074295687986),
('Hillside School', '910 75 Ave SW, Calgary, AB', 'T2V 0S6', '403-890-1234', 'Public', 50.98762964879637, -114.08332017856239),
('Riverside School', '10203 Maplemont Rd SE, Calgary, AB', 'T2J 1W3', '403-987-6543', 'Public', 50.96502913946982, -114.04162382927782),
('Valley Prep', '8706 Elbow Dr SW, Calgary, AB', 'T2V 1L2', '403-876-5432', 'Private', 50.977254582227815, -114.08933081918482),
('Sunrise School', '416 83 Ave SE, Calgary, AB', 'T2H 1N3', '403-765-4321', 'Public', 50.97984070807073, -114.05242221853402),
('Sunset School', '7239 Flint Rd SE, Calgary, AB', 'T2H 1G2', '403-654-3210', 'Public', 50.99032884538001, -114.06700753978585);
GO

-- Create Stop table
CREATE TABLE Stop (
    StopID INT IDENTITY(1,1) PRIMARY KEY,
    Address NVARCHAR(255) NOT NULL,
    Latitude FLOAT NOT NULL,
    Longitude FLOAT NOT NULL
);
GO

-- Insert Stops with Calgary coordinates
INSERT INTO Stop (Address, Latitude, Longitude)
VALUES
('Main Ave & 1st St', 51.0447, -114.0719),
('Central Park Entrance', 51.0455, -114.0725),
('Central School Gate', 51.0463, -114.0740),
('Maple St & 9th Ave', 51.0420, -114.0850),
('West Plaza', 51.0400, -114.0880),
('West School Gate', 51.0385, -114.0900),
('Riverside Bridge', 51.0480, -114.0550),
('Green Market', 51.0475, -114.0530),
('East School Gate', 51.0470, -114.0510),
('Sunset Blvd & 4th', 51.0350, -114.0950);
GO

-- Create Vehicle table
CREATE TABLE Vehicle (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Plate NVARCHAR(20) NOT NULL UNIQUE,
    Company NVARCHAR(100),
    Type NVARCHAR(20) NOT NULL,
    Available BIT NOT NULL DEFAULT 1,
    NumberOfSeats INT NOT NULL DEFAULT 30
);
GO

-- Insert Vehicles
INSERT INTO Vehicle (Plate, Company, Type, NumberOfSeats)
VALUES
('ABC1234', 'BusCo', 'Large', 50),
('XYZ5678', 'BusCo', 'Small', 24),
('BUS9087', 'TransCo', 'Large', 50),
('TRANS111', 'TransCo', 'Mini', 16),
('RIDE555', 'RideLine', 'Small', 24),
('ABC1235', 'BusCo', 'Large', 50),
('XYZ56XS', 'BusCo', 'Small', 24),
('BUS9GGF', 'TransCo', 'Large', 50),
('TRANS555', 'TransCo', 'Mini', 16),
('RIDE000', 'RideLine', 'Small', 24);
GO

-- Create Driver table
CREATE TABLE Driver (
    DriverID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Active',
	Latitude FLOAT NULL,
    Longitude FLOAT NULL,
    Address NVARCHAR(200) NULL,
	VehicleID INT NULL,
CONSTRAINT FK_Driver_Vehicle FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);
GO

-- Insert Drivers
INSERT INTO Driver (FullName, Phone, Status)
VALUES
('Thiago Lima', '403-999-1000', 'Active'),
('Bruno Martins', '403-999-2000', 'Active'),
('Patricia Diniz', '403-999-3000', 'Active'),
('Marianna Rangel', '403-999-4000', 'Active'),
('Daniela Freire', '403-999-5000', 'Active');
GO

-- Create Route table
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

-- Insert Routes
INSERT INTO Route (RouteNumber, Description, SchoolID, DriverID, VehicleID)
VALUES
('R001', 'Central School Morning Route', 1, 1, 1),
('R002', 'West School Morning Route', 2, 2, 2),
('R003', 'East School Morning Route', 3, 3, 3),
('R004', 'North Academy Morning Route', 4, 4, 4),
('R005', 'South Academy Morning Route', 5, 5, 5),
('R006', 'Central School Afternoon Route', 1, 1, 1),
('R007', 'West School Afternoon Route', 2, 2, 2),
('R008', 'East School Afternoon Route', 3, 3, 3),
('R009', 'North Academy Afternoon Route', 4, 4, 4),
('R010', 'South Academy Afternoon Route', 5, 5, 5);
GO


-- Create Student table
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
    SpecialCare NVARCHAR(255),
    CONSTRAINT FK_Student_School FOREIGN KEY (SchoolID) REFERENCES School(SchoolID),
    CONSTRAINT FK_Student_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID)
);
GO

-- Insert Students with Calgary coordinates
INSERT INTO Student (FullName, Latitude, Longitude, Address, Grade,
GuardianName, GuardianRelationship, GuardianPhone, SchoolID, StopID, SpecialCare)
VALUES
('Alice Smith', 51.0447, -114.0719, '12 Main St SW, Calgary, AB T2P 1H4', '3', 
 'Laura Smith', 'Mother', '403-555-1000', 1, 1, NULL),

('John Doe', 51.0420, -114.0850, '44 Oak St SW, Calgary, AB T2V 0E1', '4', 
 'Mark Doe', 'Father', '403-555-1001', 2, 4, NULL),

('Maria Silva', 51.0480, -114.0550, '77 Pine Rd SE, Calgary, AB T2J 1W2', '5', 
 'Ana Silva', 'Mother', '403-555-1002', 3, 7, 'Peanut Allergy'),

('Lucas Pereira', 51.0455, -114.0725, '99 Elm St SW, Calgary, AB T2V 0E8', '2', 
 'Ricardo Pereira', 'Father', '403-555-1003', 4, 2, NULL),

('Julia Ramos', 51.0475, -114.0530, '35 Palm St SE, Calgary, AB T2J 1V9', '1', 
 'Sara Ramos', 'Mother', '403-555-1004', 5, 9, NULL),

('Sofia Costa', 51.0463, -114.0740, '21 Lake Rd SW, Calgary, AB T2V 0S5', '3', 
 'Paulo Costa', 'Father', '403-555-1005', 6, 3, NULL),

('Henry Martins', 51.0400, -114.0880, '18 River Rd SW, Calgary, AB T2V 1K1', '4', 
 'Fernanda Martins', 'Mother', '403-555-1006', 7, 5, NULL),

('Gabriel Rocha', 51.0385, -114.0900, '22 Hill Rd SW, Calgary, AB T2V 1L1', '5', 
 'Clara Rocha', 'Mother', '403-555-1007', 8, 6, NULL),

('Laura Lima', 51.0470, -114.0510, '19 Valley St SE, Calgary, AB T2H 1M1', '2', 
 'Marcos Lima', 'Father', '403-555-1008', 9, 8, NULL),

('Patrick Cruz', 51.0350, -114.0950, '29 Sunset St SE, Calgary, AB T2H 1G1', '1', 
 'Juliana Cruz', 'Mother', '403-555-1009', 10, 10, 'Wheelchair Access Required');
GO

-- Create Trip table
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

-- Insert Trips (Initial Scheduled Trips)
INSERT INTO Trip (RouteID, DriverID, Status) VALUES
(1, 1, 'Scheduled'),
(2, 2, 'Scheduled'),
(3, 3, 'Scheduled'),
(4, 4, 'Scheduled'),
(5, 5, 'Scheduled'),
(6, 1, 'Scheduled'),
(7, 2, 'Scheduled'),
(8, 3, 'Scheduled'),
(9, 4, 'Scheduled'),
(10, 5, 'Scheduled');
GO

-- Create User table
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    DriverID INT NULL,
    CONSTRAINT FK_User_Driver FOREIGN KEY (DriverID) REFERENCES Driver(DriverID)
);
GO

-- Insert Users
INSERT INTO [User] (Username, Password, Role, DriverID)
VALUES
('admin', 'admin123', 'Admin', NULL),
('thiago', 'pass123', 'Driver', 1),
('bruno', 'pass123', 'Driver', 2),
('patricia', 'pass123', 'Driver', 3),
('marianna', 'pass123', 'Driver', 4),
('daniela', 'pass123', 'Driver', 5);
GO

-- Create RouteStop table for many-to-many relationship between Route and Stop
CREATE TABLE RouteStop (
    RouteStopID INT IDENTITY(1,1) PRIMARY KEY,
    RouteID INT NOT NULL,
    StopID INT NOT NULL,
    StopOrder INT NOT NULL,
    CONSTRAINT FK_RouteStop_Route FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    CONSTRAINT FK_RouteStop_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID),
    CONSTRAINT UQ_RouteStop_Order UNIQUE (RouteID, StopOrder)
);
GO

-- Create StudentTrip table for tracking student attendance on trips
CREATE TABLE StudentTrip (
    StudentTripID INT IDENTITY(1,1) PRIMARY KEY,
    TripID INT NOT NULL,
    StudentID INT NOT NULL,
    StopID INT NOT NULL,
    PickupTime DATETIME NULL,
    DropoffTime DATETIME NULL,
    Status NVARCHAR(20) DEFAULT 'Scheduled',
    CONSTRAINT FK_StudentTrip_Trip FOREIGN KEY (TripID) REFERENCES Trip(TripID),
    CONSTRAINT FK_StudentTrip_Student FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    CONSTRAINT FK_StudentTrip_Stop FOREIGN KEY (StopID) REFERENCES Stop(StopID)
);
GO

-------------------------------------students---------------------------------------

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

--------------------------trips--------------------------------------------------

CREATE PROCEDURE GetTripsByRoute @RouteID INT
AS
BEGIN
    SELECT * FROM Trip WHERE RouteID=@RouteID;
END;
GO

CREATE PROCEDURE GetTripsByDriver 
    @DriverID INT
AS
BEGIN
    SELECT 
        T.TripID,
        T.RouteID,
        T.DriverID,
        T.StartTime,
        T.EndTime,
        T.Status,
        R.RouteNumber,
        R.Description AS RouteDescription,
        S.Name AS SchoolName,
        -- Add a column to determine direction
        CASE 
            WHEN T.RouteID % 2 = 1 THEN 1  -- Inbound
            ELSE 0                          -- Outbound
        END AS IsInbound,
        -- Add a column for status priority
        CASE T.Status
            WHEN 'In Progress' THEN 2
            WHEN 'Scheduled' THEN 1
            WHEN 'Completed' THEN 0
            ELSE -1
        END AS StatusPriority
    FROM Trip T
    INNER JOIN Route R ON T.RouteID = R.RouteID
    INNER JOIN School S ON R.SchoolID = S.SchoolID
    WHERE T.DriverID = @DriverID
    ORDER BY 
        CASE WHEN T.RouteID % 2 = 1 THEN 1 ELSE 0 END DESC, -- Inbound first
        CASE T.Status
            WHEN 'In Progress' THEN 2
            WHEN 'Scheduled' THEN 1
            WHEN 'Completed' THEN 0
            ELSE -1
        END DESC, -- Status priority
        T.StartTime; -- Then by start time
END;
GO

CREATE PROCEDURE GetTripDirection
    @TripID INT
AS
BEGIN
    DECLARE @Time TIME = CAST(GETDATE() AS TIME);
    
    SELECT 
        T.TripID,
        T.RouteID,
        CASE 
            WHEN @Time < '12:00' THEN 'Morning Route'
            ELSE 'Afternoon Route'
        END AS Direction,
        R.RouteNumber,
        R.Description,
        S.Name AS SchoolName
    FROM Trip T
    INNER JOIN Route R ON T.RouteID = R.RouteID
    INNER JOIN School S ON R.SchoolID = S.SchoolID
    WHERE T.TripID = @TripID;
END;
GO

CREATE PROCEDURE sp_StartTrip @TripID INT
AS
BEGIN
    UPDATE Trip SET StartTime=GETDATE(), Status='In Progress'
    WHERE TripID=@TripID AND Status='Scheduled';
END;
GO

CREATE PROCEDURE sp_EndTrip @TripID INT
AS
BEGIN
    UPDATE Trip SET EndTime=GETDATE(), Status='Completed'
    WHERE TripID=@TripID AND Status='In Progress';
END;
GO


-------------------------------------attendance------------------------------------

CREATE PROCEDURE MarkAttendance
    @TripID INT,
    @StudentID INT,
    @StopID INT,
    @Status NVARCHAR(20),
    @Time DATETIME
AS
BEGIN
    -- Use StudentTrip table instead of TripAttendance
    INSERT INTO StudentTrip (TripID, StudentID, StopID, Status, PickupTime)
    VALUES (@TripID, @StudentID, @StopID, @Status, @Time);
END;
GO

CREATE PROCEDURE GetAttendanceByTrip 
    @TripID INT 
AS
BEGIN
    SELECT 
        ST.*,
        S.FullName,
        Stp.Address AS StopAddress
    FROM StudentTrip ST
    JOIN Student S ON ST.StudentID = S.StudentID
    JOIN Stop Stp ON ST.StopID = Stp.StopID
    WHERE ST.TripID = @TripID;
END;
GO

-----------------------------------login validation----------------------------

CREATE PROCEDURE sp_ValidateLogin
    @Username NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SELECT 
        U.UserID, 
        U.Username, 
        U.Password, 
        U.Role, 
        U.DriverID
    FROM [User] U
    WHERE U.Username = @Username 
      AND U.Password = @Password;
END;
GO

-------------------------------------drivers------------------------------------

CREATE PROCEDURE GetAllDrivers 
AS 
	SELECT * FROM Driver 
	ORDER BY FullName;
GO

CREATE OR ALTER PROCEDURE sp_GetAllDrivers
AS
BEGIN
    SELECT 
        d.DriverID,
        d.FullName,
        d.Phone,
        d.Status,
        d.Latitude,
        d.Longitude,
        d.Address,
        -- Get vehicle from the route this driver is assigned to
        ISNULL((
            SELECT TOP 1 v.Plate 
            FROM Route r 
            JOIN Vehicle v ON r.VehicleID = v.VehicleID 
            WHERE r.DriverID = d.DriverID
        ), 'None') AS AssignedVehicle,
        -- Also get Route information
        (SELECT TOP 1 r.RouteNumber FROM Route r WHERE r.DriverID = d.DriverID) AS AssignedRoute
    FROM Driver d
    ORDER BY d.FullName;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateDriver
(
    @DriverID INT,
    @FullName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Address NVARCHAR(200),
    @VehicleID INT = NULL
)
AS
BEGIN
    UPDATE Driver
    SET FullName = @FullName,
        Phone = @Phone,
        Latitude = @Latitude,
        Longitude = @Longitude,
        Address = @Address,
        VehicleID = @VehicleID
    WHERE DriverID = @DriverID;
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertDriver
(
    @FullName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Latitude FLOAT,
    @Longitude FLOAT,
    @Address NVARCHAR(200),
    @VehicleID INT = NULL
)
AS
BEGIN
    INSERT INTO Driver (FullName, Phone, Status, Latitude, Longitude, Address, VehicleID)
    VALUES (@FullName, @Phone, 'Active', @Latitude, @Longitude, @Address, @VehicleID);
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteDriver
(
    @DriverID INT
)
AS
BEGIN
    DELETE FROM Driver
    WHERE DriverID = @DriverID;
END;
GO

---------------------------------------------Vehicle---------------------------
CREATE PROCEDURE sp_GetAvailableVehicles
AS
BEGIN
    SELECT 
        VehicleID,
        Plate,
        Type,
        Company,
        NumberOfSeats
    FROM Vehicle
    WHERE Available = 1
    ORDER BY Plate;
END;
GO

CREATE PROCEDURE sp_AssignVehicleToRoute
    @RouteID INT,
    @VehicleID INT
AS
BEGIN
    UPDATE Route
    SET VehicleID = @VehicleID
    WHERE RouteID = @RouteID;
    
    -- Mark vehicle as unavailable
    UPDATE Vehicle
    SET Available = 0
    WHERE VehicleID = @VehicleID;
END;
GO

---------------------------------Routes------------------------------------

CREATE PROCEDURE sp_GetAllRoutes
AS
BEGIN
    SELECT 
        r.RouteID,
        r.RouteNumber,
        r.Description,
        s.Name AS SchoolName,
        d.FullName AS AssignedDriver,
        v.Plate AS AssignedVehicle
    FROM Route r
    JOIN School s ON r.SchoolID = s.SchoolID
    LEFT JOIN Driver d ON r.DriverID = d.DriverID
    LEFT JOIN Vehicle v ON r.VehicleID = v.VehicleID
    ORDER BY r.RouteNumber;
END;
GO

CREATE PROCEDURE sp_AssignDriverToRoute
    @RouteID INT,
    @DriverID INT
AS
BEGIN
    UPDATE Route
    SET DriverID = @DriverID
    WHERE RouteID = @RouteID;
END;
GO

--------------------------------------
-- PROCEDURES FOR REPORTS (REQUIRED BY C# LOGIC)
--------------------------------------

-- 1. sp_GetRouteList: Returns the list of routes for the selection combo box.
CREATE OR ALTER PROCEDURE sp_GetRouteList
AS
BEGIN
    SELECT RouteID, RouteNumber, Description
    FROM Route
    ORDER BY RouteNumber;
END;
GO

-- 2. sp_GetDailyRouteAttendance: Returns the daily attendance report.
-- IMPORTANT: Parameter name corrected to @ReportDate to match the C# code.
CREATE OR ALTER PROCEDURE sp_GetDailyRouteAttendance
    @RouteID INT,
    @ReportDate DATE 
AS
BEGIN
    SELECT 
        S.FullName,
        STP.Address AS StopAddress,
        R.RouteNumber,
        T.TripID,
        T.StartTime,
        T.EndTime,
        ST.PickupTime,
        ST.DropoffTime,
        ST.Status AS AttendanceStatus,
        D.FullName AS DriverName
    FROM Trip T
    JOIN Route R ON T.RouteID = R.RouteID
    JOIN Driver D ON T.DriverID = D.DriverID
    JOIN StudentTrip ST ON T.TripID = ST.TripID
    JOIN Student S ON ST.StudentID = S.StudentID
    JOIN Stop STP ON ST.StopID = STP.StopID
    WHERE R.RouteID = @RouteID
    -- Ensures the trip started or ended on the selected date
    AND (CAST(T.StartTime AS DATE) = @ReportDate OR CAST(T.EndTime AS DATE) = @ReportDate)
    ORDER BY T.StartTime, ST.PickupTime, ST.DropoffTime;
END;
GO

-- 3. sp_GetTripSummary: Returns the historical trip summary for a route.
-- ** THIS IS THE CORRECT PROCEDURE NAME EXPECTED BY YOUR C# CODE **
CREATE OR ALTER PROCEDURE sp_GetTripSummary 
    @RouteID INT
AS
BEGIN
    SELECT
        T.TripID,
        T.StartTime,
        T.EndTime,
        DATEDIFF(MINUTE, T.StartTime, T.EndTime) AS DurationMinutes,
        T.Status,
        D.FullName AS DriverName,
        V.Plate AS VehiclePlate,
        COUNT(ST.StudentTripID) AS TotalStudentsTracked
    FROM Trip T
    JOIN Route R ON T.RouteID = R.RouteID
    JOIN Driver D ON T.DriverID = D.DriverID
    LEFT JOIN Vehicle V ON R.VehicleID = V.VehicleID 
    LEFT JOIN StudentTrip ST ON T.TripID = ST.TripID
    WHERE R.RouteID = @RouteID AND T.StartTime IS NOT NULL -- Filters only initiated/completed trips
    GROUP BY
        T.TripID, T.StartTime, T.EndTime, T.Status, D.FullName, V.Plate
    ORDER BY T.StartTime DESC;
END;
GO


--------------------------------------
-- INSERT TEST DATA FOR REPORTS
-- (To ensure reports have completed trips to display)
--------------------------------------

-- Define today's and yesterday's date for test data
DECLARE @TestDate DATE = CAST(GETDATE() AS DATE);
DECLARE @YesterdayDate DATE = DATEADD(day, -1, @TestDate);

PRINT 'Inserting test trip and attendance data for reports...';

-- 1. Trip for R001 (RouteID 1) - Today (Morning Trip)
INSERT INTO Trip (RouteID, DriverID, StartTime, EndTime, Status)
VALUES (1, 1, DATEADD(minute, -30, CAST(@TestDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), CAST(@TestDate AS DATETIME) + CAST('08:00:00' AS DATETIME), 'Completed');
DECLARE @Trip1ID INT = SCOPE_IDENTITY();

-- Attendance for Trip 1
-- Student 1: Alice Smith (Stop 1) | Student 2: John Doe (Stop 4)
INSERT INTO StudentTrip (TripID, StudentID, StopID, PickupTime, Status)
VALUES (@Trip1ID, 1, 1, DATEADD(minute, 5, CAST(@TestDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), 'Picked Up');
INSERT INTO StudentTrip (TripID, StudentID, StopID, PickupTime, Status)
VALUES (@Trip1ID, 2, 4, DATEADD(minute, 15, CAST(@TestDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), 'Picked Up');


-- 2. Trip for R006 (RouteID 6) - Today (Afternoon Trip)
INSERT INTO Trip (RouteID, DriverID, StartTime, EndTime, Status)
VALUES (6, 1, DATEADD(minute, -30, CAST(@TestDate AS DATETIME) + CAST('15:30:00' AS DATETIME)), CAST(@TestDate AS DATETIME) + CAST('16:00:00' AS DATETIME), 'Completed');
DECLARE @Trip2ID INT = SCOPE_IDENTITY();

-- Attendance for Trip 2
INSERT INTO StudentTrip (TripID, StudentID, StopID, DropoffTime, Status)
VALUES (@Trip2ID, 1, 1, DATEADD(minute, 25, CAST(@TestDate AS DATETIME) + CAST('15:30:00' AS DATETIME)), 'Dropped Off');
INSERT INTO StudentTrip (TripID, StudentID, StopID, DropoffTime, Status)
VALUES (@Trip2ID, 2, 4, DATEADD(minute, 15, CAST(@TestDate AS DATETIME) + CAST('15:30:00' AS DATETIME)), 'Dropped Off');


-- 3. Trip for R001 (RouteID 1) - Yesterday (For Trip Summary Report)
INSERT INTO Trip (RouteID, DriverID, StartTime, EndTime, Status)
VALUES (1, 1, DATEADD(minute, -30, CAST(@YesterdayDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), CAST(@YesterdayDate AS DATETIME) + CAST('08:00:00' AS DATETIME), 'Completed');
DECLARE @Trip3ID INT = SCOPE_IDENTITY();

-- Attendance for Trip 3 (Yesterday)
INSERT INTO StudentTrip (TripID, StudentID, StopID, PickupTime, Status)
VALUES (@Trip3ID, 1, 1, DATEADD(minute, 5, CAST(@YesterdayDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), 'Picked Up');
INSERT INTO StudentTrip (TripID, StudentID, StopID, PickupTime, Status)
VALUES (@Trip3ID, 2, 4, DATEADD(minute, 15, CAST(@YesterdayDate AS DATETIME) + CAST('07:30:00' AS DATETIME)), 'Picked Up');

PRINT 'Data insertion complete.';
GO