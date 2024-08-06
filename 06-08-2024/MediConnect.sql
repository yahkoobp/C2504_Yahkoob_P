--MediConnect project 
--selection , filtering and sotring queries

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
