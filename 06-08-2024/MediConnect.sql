CREATE DATABASE MediConnect_db;

USE MediConnect_db;

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) CHECK (Role IN ('admin', 'doctor', 'nurse', 'staff')) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.Users OFF

INSERT INTO Users (UserId, Username, Email, PasswordHash, Role, CreatedAt, UpdatedAt)
VALUES 
('1', 'john_doe', 'john@example.com', 'hashed_password_1', 'Doctor', GETDATE(), GETDATE()),
('2', 'jane_smith', 'jane@example.com', 'hashed_password_2', 'Nurse', GETDATE(), GETDATE()),
('3', 'emily_jones', 'emily@example.com', 'hashed_password_3', 'Admin', GETDATE(), GETDATE()),
('4', 'michael_brown', 'michael@example.com', 'hashed_password_4', 'Doctor', GETDATE(), GETDATE());

SELECT * FROM Users;


CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Dob DATE NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN ('Male', 'Female', 'Other')) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.Patients OFF


INSERT INTO Patients (PatientId, Name, Dob, Gender, Phone, Email, Address, CreatedAt, UpdatedAt)
VALUES 
('1', 'Alice Johnson', '1980-05-12', 'Female', '123-456-7890', 'alice@example.com', '123 Main St', GETDATE(), GETDATE()),
('2', 'Bob Smith', '1975-07-23', 'Male', '234-567-8901', 'bob@example.com', '456 Elm St', GETDATE(), GETDATE()),
('3', 'Charlie Brown', '1990-10-10', 'Male', '345-678-9012', 'charlie@example.com', '789 Oak St', GETDATE(), GETDATE()),
('4', 'Diana Prince', '1985-01-15', 'Female', '456-789-0123', 'diana@example.com', '101 Pine St', GETDATE(), GETDATE());


INSERT INTO Patients (PatientId, Name, Dob, Gender, Phone, Email, Address, CreatedAt, UpdatedAt)
VALUES 
('5', 'Eve Adams', '1978-02-25', 'Female', '567-890-1234', 'eve@example.com', '234 Birch St', GETDATE(), GETDATE()),
('6', 'Frank Miller', '1982-09-30', 'Male', '678-901-2345', 'frank@example.com', '567 Cedar St', GETDATE(), GETDATE()),
('7', 'Grace Lee', '1995-11-10', 'Female', '789-012-3456', 'grace@example.com', '890 Dogwood St', GETDATE(), GETDATE()),
('8', 'Henry Wilson', '1987-06-15', 'Male', '890-123-4567', 'henry@example.com', '123 Fir St', GETDATE(), GETDATE()),
('9', 'Ivy Clark', '1992-03-05', 'Female', '901-234-5678', 'ivy@example.com', '456 Green St', GETDATE(), GETDATE()),
('10', 'Jack Harris', '1980-08-22', 'Male', '012-345-6789', 'jack@example.com', '789 Hawthorn St', GETDATE(), GETDATE()),
('11', 'Kara White', '1975-04-17', 'Female', '123-456-7890', 'kara@example.com', '101 Ivy St', GETDATE(), GETDATE()),
('12', 'Leo King', '1990-12-30', 'Male', '234-567-8901', 'leo@example.com', '202 Jasmine St', GETDATE(), GETDATE()),
('13', 'Mona Scott', '1985-01-25', 'Female', '345-678-9012', 'mona@example.com', '303 Lotus St', GETDATE(), GETDATE()),
('14', 'Nina Perez', '1998-05-10', 'Female', '456-789-0123', 'nina@example.com', '404 Maple St', GETDATE(), GETDATE());


SELECT * FROM Patients;

CREATE TABLE MedicalHistory (
    MedicalHistoryId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT FOREIGN KEY REFERENCES Patients(PatientId) ON DELETE CASCADE,
    Condition NVARCHAR(255) NOT NULL,
    DiagnosisDate DATE NOT NULL,
    Notes NVARCHAR(MAX),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.MedicalHistory OFF



INSERT INTO MedicalHistory (MedicalHistoryId, PatientId, Condition, DiagnosisDate, Notes, CreatedAt, UpdatedAt)
VALUES 
('1', '1', 'Hypertension', '2020-01-01', 'Patient has a history of high blood pressure', GETDATE(), GETDATE()),
('2', '2', 'Diabetes', '2019-05-20', 'Patient diagnosed with type 2 diabetes', GETDATE(), GETDATE()),
('3', '3', 'Asthma', '2018-03-15', 'Patient suffers from chronic asthma', GETDATE(), GETDATE()),
('4', '4', 'Heart Disease', '2021-07-30', 'Patient has a history of heart disease', GETDATE(), GETDATE());

INSERT INTO MedicalHistory (MedicalHistoryId, PatientId, Condition, DiagnosisDate, Notes, CreatedAt, UpdatedAt)
VALUES 
('5', '5', 'Arthritis', '2021-02-01', 'Patient experiencing joint pain.', GETDATE(), GETDATE()),
('6', '6', 'High Cholesterol', '2020-09-15', 'Patient has high cholesterol levels.', GETDATE(), GETDATE()),
('7', '7', 'Migraines', '2019-11-20', 'Patient suffers from chronic migraines.', GETDATE(), GETDATE()),
('8', '8', 'Depression', '2018-06-05', 'Patient undergoing therapy for depression.', GETDATE(), GETDATE()),
('9', '9', 'Eczema', '2022-03-15', 'Patient has skin rash.', GETDATE(), GETDATE()),
('10', '10', 'Osteoporosis', '2019-08-25', 'Patient diagnosed with low bone density.', GETDATE(), GETDATE()),
('11', '11', 'Allergies', '2017-04-10', 'Patient allergic to pollen and dust.', GETDATE(), GETDATE()),
('12', '12', 'Thyroid Disorder', '2021-12-01', 'Patient has hypothyroidism.', GETDATE(), GETDATE()),
('13', '13', 'Chronic Kidney Disease', '2018-01-30', 'Patient has stage 3 CKD.', GETDATE(), GETDATE()),
('14', '14', 'Hypertension', '2023-05-20', 'Patient recently diagnosed with high blood pressure.', GETDATE(), GETDATE());


SELECT * FROM MedicalHistory;

CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT FOREIGN KEY REFERENCES Patients(PatientId) ON DELETE CASCADE,
    DoctorId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Date DATE NOT NULL,
    Time TIME NOT NULL,
    Reason NVARCHAR(255),
    Status NVARCHAR(50) CHECK (Status IN ('scheduled', 'completed', 'canceled')) DEFAULT 'scheduled' NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.Appointments OFF;

INSERT INTO Appointments (AppointmentId, PatientId, DoctorId, Date, Time, Reason, Status, CreatedAt, UpdatedAt)
VALUES 
('1', '1', '1', '2024-08-10', '10:00', 'Regular check-up', 'Scheduled', GETDATE(), GETDATE()),
('2', '2', '1', '2024-08-11', '11:00', 'Follow-up for diabetes management', 'Scheduled', GETDATE(), GETDATE()),
('3', '3', '2', '2024-08-12', '09:00', 'Asthma consultation', 'Scheduled', GETDATE(), GETDATE()),
('4', '4', '2', '2024-08-13', '14:00', 'Cardiology consultation', 'Scheduled', GETDATE(), GETDATE());

INSERT INTO Appointments (AppointmentId, PatientId, DoctorId, Date, Time, Reason, Status, CreatedAt, UpdatedAt)
VALUES 
('5', '5', '1', '2024-08-14', '10:00', 'Joint pain consultation', 'Scheduled', GETDATE(), GETDATE()),
('6', '6', '1', '2024-08-15', '11:00', 'Cholesterol check-up', 'Scheduled', GETDATE(), GETDATE()),
('7', '7', '2', '2024-08-16', '09:00', 'Migraine treatment', 'Scheduled', GETDATE(), GETDATE()),
('8', '8', '2', '2024-08-17', '14:00', 'Therapy session', 'Scheduled', GETDATE(), GETDATE()),
('9', '9', '1', '2024-08-18', '13:00', 'Skin rash consultation', 'Scheduled', GETDATE(), GETDATE()),
('10', '10', '1', '2024-08-19', '10:00', 'Bone density scan', 'Scheduled', GETDATE(), GETDATE()),
('11', '11', '2', '2024-08-20', '11:00', 'Allergy treatment', 'Scheduled', GETDATE(), GETDATE()),
('12', '12', '2', '2024-08-21', '09:00', 'Thyroid check-up', 'Scheduled', GETDATE(), GETDATE()),
('13', '13', '1', '2024-08-22', '14:00', 'Kidney function test', 'Scheduled', GETDATE(), GETDATE()),
('14', '14', '2', '2024-08-23', '13:00', 'Blood pressure monitoring', 'Scheduled', GETDATE(), GETDATE());

SELECT * FROM Appointments;


CREATE TABLE Messages (
    MessageId INT IDENTITY(1,1) PRIMARY KEY,
    FromUserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    ToUserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE NO ACTION,
    Message NVARCHAR(MAX) NOT NULL,
    Timestamp DATETIME2 DEFAULT GETDATE(),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.Messages OFF;



INSERT INTO Messages (MessageId, FromUserId, ToUserId, Message, Timestamp, CreatedAt, UpdatedAt)
VALUES 
('1', '1', '2', 'Please update me on patient Alice Johnson''s status.', GETDATE(), GETDATE(), GETDATE()),
('2', '2', '1', 'Alice Johnson''s status has been updated.', GETDATE(), GETDATE(), GETDATE()),
('3', '3', '1', 'Reminder: Staff meeting tomorrow at 9 AM.', GETDATE(), GETDATE(), GETDATE()),
('4', '4', '3', 'Confirmed for the meeting.', GETDATE(), GETDATE(), GETDATE());

SELECT * FROM Messages;





CREATE TABLE EHR_IntegrationLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    EHRSystem NVARCHAR(100) NOT NULL,
    PatientId INT FOREIGN KEY REFERENCES Patients(PatientId) ON DELETE CASCADE,
    Operation NVARCHAR(50) CHECK (Operation IN ('import', 'update')) NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('success', 'failure')) NOT NULL,
    Details NVARCHAR(MAX),
    Timestamp DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.EHR_IntegrationLogs OFF;

INSERT INTO EHR_IntegrationLogs (LogId, PatientId, EHRSystem,Operation, Status, Details, Timestamp)
VALUES 
('1','1', 'System A','import', 'Success', 'Data synced successfully.', GETDATE()),
('2','2', 'System B','import', 'Failure', 'Data sync failed due to network error.', GETDATE()),
('3','3','System C','update', 'Success', 'Data synced successfully.', GETDATE()),
('4','4','System A','update', 'Failure', 'Data sync failed due to authentication error.', GETDATE());


CREATE TABLE Notifications (
    NotificationId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Message NVARCHAR(255) NOT NULL,
    IsRead BIT DEFAULT 0,
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

SET IDENTITY_INSERT dbo.Notifications ON;

INSERT INTO Notifications (NotificationId, UserId, Message, IsRead, CreatedAt)
VALUES 
('1', '1', 'Your appointment with Alice Johnson is scheduled for 2024-08-10 at 10:00.', 0, GETDATE()),
('2', '2', 'Your appointment with Bob Smith is scheduled for 2024-08-11 at 11:00.', 0, GETDATE()),
('3', '3', 'Your appointment with Charlie Brown is scheduled for 2024-08-12 at 09:00.', 0, GETDATE()),
('4', '4', 'Your appointment with Diana Prince is scheduled for 2024-08-13 at 14:00.', 0, GETDATE())

UPDATE Notifications set isRead = 1 where NotificationId = 1;
SELECT * FROM Notifications;


--mediconnect project
--selecting , filtering and sorting queries

--1.to get users by id
SELECT username , email 
FROM Users 
where userId = '1';

--2.sort users by ascending and descending order of their usernames
SELECT username , email  
FROM Users 
ORDER BY username , email;

SELECT username 
FROM Users 
ORDER BY username DESC;


--3.display all patients whos age is less than 30
SELECT Name , DATEDIFF(YEAR , Dob , GETDATE()) AS AGE 
FROM Patients 
WHERE DATEDIFF(YEAR , Dob , GETDATE()) < 30;

--4.to get all female patients
SELECT Name 
FROM Patients 
WHERE Gender = 'Female';

--5.Order patients by created date
SELECT Name  
FROM Patients 
ORDER BY CreatedAt;

--6.Retrieve all users ordered by their creation date
SELECT username 
FROM Users 
ORDER BY CreatedAt;

--7.Retrieve the details of doctors only:
SELECT username , role
FROM Users 
WHERE role = 'doctor';

--8.Retrieve all appointments for a specific doctor, ordered by appointment date:
SELECT  AppointmentId , PatientId , DoctorId ,CreatedAt
FROM Appointments 
WHERE DoctorId = '1' 
ORDER BY CreatedAt;

--9.Retrieve the medical history of a specific patient:
SELECT  *
FROM MedicalHistory 
WHERE PatientId = '1';

--10.Retrieve all unread notifications for a specific user:
SELECT * 
FROM Notifications 
WHERE IsRead = 0;


--11.Retrieve all integration logs where the operation status is 'failure'
SELECT * 
FROM EHR_IntegrationLogs 
WHERE status = 'failure';

--12.Retrieve messages sent by a specific user:
SELECT * 
FROM Messages 
WHERE  FromUserId = '2';

--13.Retrieve all appointments scheduled for a specific date:
SELECT * 
FROM Appointments 
WHERE date = '2024-08-15';


--14.to get appoinments with reason contains 'pain'
SELECT * FROM Appointments
WHERE Reason LIKE '%pain%';

--15.to get all the scheduled appointments
SELECT * FROM Appointments
WHERE status ='Scheduled';

--16.Retrieve all messages sent between two specific dates
SELECT * FROM Messages WHERE Timestamp BETWEEN '2024-08-01' AND '2024-08-07' ORDER BY Timestamp;

--17.To get details of patients who are diagnosed in a specific date
SELECT * 
FROM MedicalHistory 
WHERE DiagnosisDate = '2020-01-01';

--18.To get details of medical history of a patients before a spectific date
SELECT * 
FROM MedicalHistory 
WHERE DiagnosisDate < '2020-01-01';

--19.To get all the patients who's phone number ends with a specific numbers
SELECT * 
FROM Patients 
WHERE Phone LIKE '%7890';

--20.Retrieve the details of users who registered within the last 30 days:
SELECT * 
FROM Users 
WHERE CreatedAt >= DATEADD(month, -1, GETDATE())
ORDER BY CreatedAt DESC;


















IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'students')

BEGIN
    CREATE TABLE Students
    (Id int PRIMARY KEY IDENTITY(1,1) , FirstName varchar(255) NOT NULL , LastName varchar(255) NOT NULL , Email varchar(100) NOT NULL UNIQUE , PhoneNumber varchar(100));
END


select * from student;


IF OBJECT_ID('dbo.subjects') IS NULL
BEGIN
   CREATE TABLE Subjects (id INT PRIMARY KEY IDENTITY , 
   [Name] varchar(20) NOT NULL
   )
END

IF OBJECT_ID('dbo.Marks') IS NULL
BEGIN
   CREATE TABLE Marks (id INT PRIMARY KEY IDENTITY , 
   student_id int not null,
   subject_id int not null ,
   mark int not null , 
   constraint fk_student foreign key(student_id) references students(id),
   constraint fk_subject foreign key(student_id) references subjects(id),

   )
END

insert in to 
select * from sys.tables;





