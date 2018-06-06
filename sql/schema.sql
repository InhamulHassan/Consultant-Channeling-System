CREATE DATABASE MediClinicDatabase

CREATE TABLE ConsultantTable
(
ConsultantID VARCHAR(6) NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Practicing_From DATE NOT NULL,
PRIMARY KEY(ConsultantID)
)

CREATE TABLE AppointmentStatusList
(
AppointmentStatusID INT NOT NULL,
StatusDescription VARCHAR(30) NOT NULL,
PRIMARY KEY(AppointmentStatusID)
)

CREATE TABLE ConsultantLoginTable
(
LoginID VARCHAR(50) NOT NULL,
PinCode VARCHAR(5) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL UNIQUE,
PRIMARY KEY(LoginID),
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable
)

CREATE TABLE HospitalTable
(
HospitalID VARCHAR(6) NOT NULL,
HospitalName VARCHAR(100) NOT NULL,
HospitalAddress VARCHAR(120) NOT NULL,
LocatedCity VARCHAR(30) NOT NULL,
PRIMARY KEY(HospitalID)
)

CREATE TABLE ConsultantOfficeTable
(
ConsultantOfficeID VARCHAR(6) NOT NULL,
OfficeName VARCHAR(100) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL,
HospitalID VARCHAR(6) DEFAULT NULL,
TimeSlotPerClient INT,
FirstConsultationFee INT,
FollowupConsulationFee INT,
[Address] VARCHAR(120) NOT NULL,
LocatedCity VARCHAR(30) NOT NULL,
PRIMARY KEY(ConsultantOfficeID),
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
FOREIGN KEY(HospitalID) REFERENCES HospitalTable,
)

CREATE TABLE AppointmentScheduleTable
(
AppointmentScheduleID VARCHAR(5) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL,
ConsultantOfficeID VARCHAR(6) NOT NULL,
[DayOfWeek] VARCHAR(10) NOT NULL,
StartTime TIME(0) NOT NULL,
EndTime TIME(0) NOT NULL,
ScheduleAvailability CHAR(1) NOT NULL Default 'Y',
PRIMARY KEY(AppointmentScheduleID),
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
FOREIGN KEY(ConsultantOfficeID) REFERENCES ConsultantOfficeTable,
)
ALTER TABLE AppointmentScheduleTable
ADD SessionNumber INT NOT NULL DEFAULT 0

CREATE TABLE AppointmentTable
(
AppointmentID VARCHAR(10) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL,
AppointmentScheduleID VARCHAR(5) NOT NULL,
ConsultantOfficeID VARCHAR(6) NOT NULL,
PatientName VARCHAR(50) NOT NULL,
PatientAge INT NOT NULL,
PatientContactInfo INT NOT NULL,
AppointmentDate DATE NOT NULL,
AppointmentStatusID INT NOT NULL DEFAULT '1',
PRIMARY KEY(AppointmentID),
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
FOREIGN KEY(AppointmentScheduleID) REFERENCES AppointmentScheduleTable,
FOREIGN KEY(ConsultantOfficeID) REFERENCES ConsultantOfficeTable,
FOREIGN KEY(AppointmentStatusID) REFERENCES AppointmentStatusList
)

CREATE TABLE PatientRecordsTable
(
Record_ID VARCHAR(10) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL,
AppointmentID VARCHAR(10) NOT NULL,
PatientFirstName VARCHAR(50) NOT NULL,
PatientLastName VARCHAR(50) NOT NULL,
PatientAge INT NOT NULL,
ProblemDescription VARCHAR(250) DEFAULT 'NOT PROVIDED',
PrescriptionDetails VARCHAR(250) DEFAULT 'NOT PROVIDED',
PRIMARY KEY(Record_ID),
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
FOREIGN KEY(AppointmentID) REFERENCES AppointmentTable,
)

CREATE TABLE QualificationsListTable
(
QualificationID VARCHAR(5) NOT NULL,
QualificationName VARCHAR(100) NOT NULL,
PRIMARY KEY(QualificationID)
)

CREATE TABLE SpecialitiesListTable
(
SpecialityID VARCHAR(5) NOT NULL,
SpecialityName VARCHAR(100) NOT NULL,
PRIMARY KEY(SpecialityID)
)

CREATE TABLE HospitalAffliationsTable
(
PKID INT NOT NULL IDENTITY(1,1),
HospitalID VARCHAR(6) NOT NULL,
ConsultantID VARCHAR(6) NOT NULL,
PRIMARY KEY(PKID),
FOREIGN KEY(HospitalID) REFERENCES HospitalTable,
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
)

CREATE TABLE DoctorSpecialities
(
PKID INT NOT NULL IDENTITY(1,1),
ConsultantID VARCHAR(6) NOT NULL,
SpecialityID VARCHAR(5) NOT NULL,
PRIMARY KEY(PKID),
FOREIGN KEY(SpecialityID) REFERENCES SpecialitiesListTable,
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
)

CREATE TABLE DoctorQualifications
(
PKID INT NOT NULL IDENTITY(1,1),
ConsultantID VARCHAR(6) NOT NULL,
QualificationID VARCHAR(5) NOT NULL,
PRIMARY KEY(PKID),
FOREIGN KEY(QualificationID) REFERENCES QualificationsListTable,
FOREIGN KEY(ConsultantID) REFERENCES ConsultantTable,
)





INSERT INTO ConsultantTable VALUES ('DR0001','Disna','Athukorala','1990/01/02')
INSERT INTO ConsultantTable VALUES ('DR0002','W','Nithyanandan','1990/12/21')
INSERT INTO ConsultantTable VALUES ('DR0003','Suranjith','Seneviratne','2001/04/01')
INSERT INTO ConsultantTable VALUES ('DR0004','Anura','Weerasinghe','1999/12/08')
INSERT INTO ConsultantTable VALUES ('DR0005','G. Neelika','Malavige','1991/01/21')
INSERT INTO ConsultantTable VALUES ('DR0006','H.H.L.K','Fenando','2010/06/30')
INSERT INTO ConsultantTable VALUES ('DR0007','Nimal','Liyanage','2005/05/01')
INSERT INTO ConsultantTable VALUES ('DR0008','S.P','Rajakumar','2003/09/22')

INSERT INTO ConsultantTable VALUES ('DR0009','S','Nithya','2015/01/16')
INSERT INTO ConsultantTable VALUES ('DR0010','F. Nifras','Kariapper','2014/07/04')
INSERT INTO ConsultantTable VALUES ('DR0011','Dulan','Madusanka','2006/03/25')
INSERT INTO ConsultantTable VALUES ('DR0012','T','Wijeysooriya','2008/08/08')
INSERT INTO ConsultantTable VALUES ('DR0013','Buddhima','Samaraweera','1998/10/25')
INSERT INTO ConsultantTable VALUES ('DR0014','Aranjan','Karunannayake','1997/06/18')
INSERT INTO ConsultantTable VALUES ('DR0015','Ishanthi','Perera','1989/02/09')
INSERT INTO ConsultantTable VALUES ('DR0016','Susitha','Amarasinghe','1981/05/21')

INSERT INTO ConsultantTable VALUES ('DR0017','Asunga','Dunuwille','1995/03/26')
INSERT INTO ConsultantTable VALUES ('DR0018','Rohan','Gunawardana','1994/09/04')
INSERT INTO ConsultantTable VALUES ('DR0019','Suresh','Kottegoda','2001/05/01')
INSERT INTO ConsultantTable VALUES ('DR0020','Stanley','Amarasekara','1998/11/17')
INSERT INTO ConsultantTable VALUES ('DR0021','N.L','Amarasena','1994/05/05')
INSERT INTO ConsultantTable VALUES ('DR0022','K','Arulnithy','1995/04/13')
INSERT INTO ConsultantTable VALUES ('DR0023','Pandula','Athaudaarchchi','1997/07/08')
INSERT INTO ConsultantTable VALUES ('DR0024','Sampath','Athukorala','1993/04/05')

INSERT INTO ConsultantTable VALUES ('DR0025','Godvin','Constantine','2010/04/19')
INSERT INTO ConsultantTable VALUES ('DR0026','Dinusha','Darmawardana','2007/10/30')
INSERT INTO ConsultantTable VALUES ('DR0027','S.R De','Silva','2006/06/24')
INSERT INTO ConsultantTable VALUES ('DR0028','Kishan A De','Silva','2003/06/07')
INSERT INTO ConsultantTable VALUES ('DR0029','Chinthaka De','Silva','2017/06/05')
INSERT INTO ConsultantTable VALUES ('DR0030','S.N.B','Dolapihilla','2012/11/11')
INSERT INTO ConsultantTable VALUES ('DR0031','Asunga','Dunuwille','2012/12/31')

INSERT INTO ConsultantTable VALUES ('DR0032','Nimila','Fernando','2008/04/18')
INSERT INTO ConsultantTable VALUES ('DR0033','Janath P','Gunasinghe','2009/08/17')
INSERT INTO ConsultantTable VALUES ('DR0034','S. Roshan Ranil','Gunaratna','2006/09/11')
INSERT INTO ConsultantTable VALUES ('DR0035','Vajira','Gunawardana','2009/12/25')
INSERT INTO ConsultantTable VALUES ('DR0036','M','Guruparan','1997/07/24')
INSERT INTO ConsultantTable VALUES ('DR0037','Chinthaka','Hathalahawaththa','1985/05/06')
INSERT INTO ConsultantTable VALUES ('DR0038','Jagath','Herath','1984/09/09')
INSERT INTO ConsultantTable VALUES ('DR0039','Vasantha S','Hettiarachchi','1979/08/06')
INSERT INTO ConsultantTable VALUES ('DR0040','Z','Jamaldeen','1979/11/15')
INSERT INTO ConsultantTable VALUES ('DR0041','Mohan','Jayathilaka','1980/08/01')
INSERT INTO ConsultantTable VALUES ('DR0042','Priyantha','Kannangara','1986/06/14')
INSERT INTO ConsultantTable VALUES ('DR0043','L','Kapuruge','1983/09/14')

INSERT INTO ConsultantTable VALUES ('DR0044','Wasantha','Kapuwatta','1989/09/30')
INSERT INTO ConsultantTable VALUES ('DR0045','Ajith','Kularathna','2000/06/19')
INSERT INTO ConsultantTable VALUES ('DR0046','Anil','Kuma','2015/07/11')
INSERT INTO ConsultantTable VALUES ('DR0047','A.S.L','Liyanarachchi','2004/12/22')
INSERT INTO ConsultantTable VALUES ('DR0048','Nirishan C','Lokunarangoda','2001/01/01')
INSERT INTO ConsultantTable VALUES ('DR0049','P','Lukshman','2002/02/01')
INSERT INTO ConsultantTable VALUES ('DR0050','J.H.L','Cooray','2003/02/25')
INSERT INTO ConsultantTable VALUES ('DR0051','Bandu','Gunasena','2009/12/31')
INSERT INTO ConsultantTable VALUES ('DR0052','Ravini','Karunathilaka','2007/08/19')
INSERT INTO ConsultantTable VALUES ('DR0053','Saman','Kularathne','2006/10/11')
INSERT INTO ConsultantTable VALUES ('DR0054','Geethal','Perera','1980/11/27')
INSERT INTO ConsultantTable VALUES ('DR0055','Eshantha','Perera','1996/07/08')
INSERT INTO ConsultantTable VALUES ('DR0056','Amila','Rathnapala','1989/08/12')
INSERT INTO ConsultantTable VALUES ('DR0057','S','Rishikesavan','1991/01/08')
INSERT INTO ConsultantTable VALUES ('DR0058','Chandimani','Undugodage','2005/12/28')
INSERT INTO ConsultantTable VALUES ('DR0059','Duminda','Yasarathne','1998/11/28')
INSERT INTO ConsultantTable VALUES ('DR0060','Channa D.','Ranasinghe','1999/11/09')
INSERT INTO ConsultantTable VALUES ('DR0061','Yamuna','Rajapaksha','1979/03/30')
INSERT INTO ConsultantTable VALUES ('DR0062','Gina','Variath','2013/09/14')
INSERT INTO ConsultantTable VALUES ('DR0063','H','Ratnayaka','2013/08/09')
INSERT INTO ConsultantTable VALUES ('DR0064','Sapumal','Jayasinghe','1989/09/09')
INSERT INTO ConsultantTable VALUES ('DR0065','Lanka','Adikara','1988/09/15')
INSERT INTO ConsultantTable VALUES ('DR0066','W M Hilary','Cooray','1979/08/02')

INSERT INTO ConsultantTable VALUES ('DR0067','Sarath','Amaradasa','2009/07/12')
INSERT INTO ConsultantTable VALUES ('DR0068','Asanka De','Silva','2006/04/05')
INSERT INTO ConsultantTable VALUES ('DR0069','Dileep De','Silva','2014/09/16')
INSERT INTO ConsultantTable VALUES ('DR0070','D K','Dias','2016/02/05')
INSERT INTO ConsultantTable VALUES ('DR0071','J Sisiri','Elwatta','2010/11/25')
INSERT INTO ConsultantTable VALUES ('DR0072','A','Fouzan','2011/07/06')
INSERT INTO ConsultantTable VALUES ('DR0073','Amila','Gomis','2007/10/06')
INSERT INTO ConsultantTable VALUES ('DR0074','Maya','Gunasekara','2013/09/14')
INSERT INTO ConsultantTable VALUES ('DR0075','Bandu','Gunathilaka','1989/09/09')
INSERT INTO ConsultantTable VALUES ('DR0076','Rangith Lal','Kandewatta','1989/09/09')
INSERT INTO ConsultantTable VALUES ('DR0077','K I N','Karunarathne','1980/11/27')
INSERT INTO ConsultantTable VALUES ('DR0078','K S','Kithalawaarachchi','2004/12/22')
INSERT INTO ConsultantTable VALUES ('DR0079','Imran','Muhuseen','2000/06/19')
INSERT INTO ConsultantTable VALUES ('DR0080','Shamil Navratna','Raja','1999/11/09')


INSERT INTO HospitalTable VALUES ('H00001','Nawaloka Hospital','No. 23, Sri Sugathodaya Mawatha, Colombo 02. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00002','Durdans Hospital','No. 03, Alfred Place, Colombo 03. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00003','Western Infirmary Hospital','218, Cotta Road, Colombo 08.','Colombo')
INSERT INTO HospitalTable VALUES ('H00004','Park Hospital','No. 186, Park Road Colombo 05.' ,'Colombo')
INSERT INTO HospitalTable VALUES ('H00005','Ceymed Healthcare Services','No. 132, S. de S. Jayasinghe Mawatha, Nugegoda.' ,'Nugegoda')
INSERT INTO HospitalTable VALUES ('H00006','Hemas Southern Hospital','Wackwella Road, Galle. ','Galle')
INSERT INTO HospitalTable VALUES ('H00007','Healthy Life Clinic','No. 10, Deal Place ''A'', Duplication Road, Colombo 03. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00008','Lanka Hospitals','578, Elvitigala Mawatha, Colombo 05. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00009','Oasis Hospital Ltd','18/A, Mohan E.D Dabare Mawatha, Colombo 05. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00010','Golden Key Eye and ENT Hospital','1175, Cotta Road, Rajagiriya. ','Rajagiriya')
INSERT INTO HospitalTable VALUES ('H00011','Ninewells Care Mother & Baby Hospital','55/1, Kirimandala Mawatha, Narahenpita, Colombo 05. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00012','Prabhodha Hospital.','Pandukabaya Mawatha, Ampara. ','Ampara')
INSERT INTO HospitalTable VALUES ('H00013','Prarthana Fertility (IVF) Centre','Rajagiriya, Sri Lanka. ','Rajagiriya')
INSERT INTO HospitalTable VALUES ('H00014','Arogya Hospital','250, Colombo Road, Gampaha ','Gampaha')
INSERT INTO HospitalTable VALUES ('H00015','Ceylinco Healthcare Services','60, Park Street,Colombo 02. ','Colombo')
INSERT INTO HospitalTable VALUES ('H00016','Nawaloka Hospital - Negombo','No.169, Colombo Road, Negombo. ','Negombo')
INSERT INTO HospitalTable VALUES ('H00017','Nawinna Medicare Hospital','No.416, High Level Road, Nawinna, Maharagama. ','Maharagama')
INSERT INTO HospitalTable VALUES ('H00018','Sulaiman`s Hospital','34-54, Grandpass Road, Colombo 14.' ,'Colombo')
INSERT INTO HospitalTable VALUES ('H00019','Joseph Fraser Memorial Hospital','23, Joseph Fraser Road, Colombo 05.','Colombo')
INSERT INTO HospitalTable VALUES ('H00020','New Philip Hospitals (Pvt) Ltd','No. 225, Kalutara South, Kalutara.','Kalutara')
INSERT INTO HospitalTable VALUES ('H00021','Vindana Reproductive Health Centre','No. 9, Barnes place, Colombo 07.','Colombo')
INSERT INTO HospitalTable VALUES ('H00022','Dr. Neville Fernando Teaching Hospital - NFTH','No 60, Millennium Drive, Malabe.','Malabe')
INSERT INTO HospitalTable VALUES ('H00023','Hemas Hospital','389, Negombo Road, Wattala.','Wattala')
INSERT INTO HospitalTable VALUES ('H00024','Winserr Hospital.','129, S.De.S. Jayasinghe Mawatha, Kohuwala.','Kohuwala')
INSERT INTO HospitalTable VALUES ('H00025','Winsetha Hospital (Pvt) Ltd.','55, Ananda Rajakaruna Mawatha, Colombo 10.','Colombo')
INSERT INTO HospitalTable VALUES ('H00026','Damrivi Foundation.','51/A, Isipathana Mawatha, Havelock Town, Colombo 05.','Colombo')
INSERT INTO HospitalTable VALUES ('H00027','Santa Dora Hospital.','#173, Pannipitiya Road, Battaramulla.','Beruwala')
INSERT INTO HospitalTable VALUES ('H00028','Hemas Hospitals (Pvt) Ltd - Thalawathugoda','647, Pannipitiya Road, Thalawathugoda.','Thalawathugoda')
INSERT INTO HospitalTable VALUES ('H00029','Vasan Healthcare Lanka (Pvt) Ltd.','No. 423, Galle Road,Colombo 03.','Colombo')
INSERT INTO HospitalTable VALUES ('H00030','Child Eye Rajagiriya.','198, Parliament Road, Rajagiriya.','Rajagiriya')
INSERT INTO HospitalTable VALUES ('H00031','Ahangama Medical Centre','39/31, Morris Rd, Galle','Ahangama')
INSERT INTO HospitalTable VALUES ('H00032','Amman Medicals','297,Negombo Road,Peliyagoda', 'Peliyagoda')
INSERT INTO HospitalTable VALUES ('H00033','Singapore Medical - Dehiwala','2020/1, Main Road, Attidiya, Dehiwala','Dehiwala')
INSERT INTO HospitalTable VALUES ('H00034','St.Georges Hospital-Biyagama','537/D,New Kandy Road, Biyagama','Biyagama')
INSERT INTO HospitalTable VALUES ('H00035','Blue Cross Medical Laboratory','Mallika Building, Old Road, Balangoda','Balangoda')
INSERT INTO HospitalTable VALUES ('H00036','Clinicare Medical Center-Boralesgamuwa','96/1c, Divulpitiya, Boralesgamuwa','Boralesgamuwa')
INSERT INTO HospitalTable VALUES ('H00037','Pearl Medical Services','94,Church Street,Colombo 02','Colombo')
INSERT INTO HospitalTable VALUES ('H00038','Appollo Care Medical Center','No. 27, Dudly Senanayake Mawatha, Dehiwala.','Dehiwala')
INSERT INTO HospitalTable VALUES ('H00039','Nawaloka Medical Centre - Dehiwala','No. 200f, Galle Road, Dehiwala','Dehiwala')
INSERT INTO HospitalTable VALUES ('H00040','Channelway Medical Center - Homagama','158/11,Akshidana Mw,Godagama,Homagama','Homagama')
INSERT INTO HospitalTable VALUES ('H00041','Eye Care Center - Kandana','104/1, Station Road, Kandana','Kandana')
INSERT INTO HospitalTable VALUES ('H00042','Kish Laboratories (Pvt) Ltd','Asian Buliding , Central Road, Kattankudy-04','Kattankudy')
INSERT INTO HospitalTable VALUES ('H00043','Long Life Laboratory Pvt Ltd - Kochchikade','No. 10, Pallansena Rd,Kochchikade','Kochchikade')



INSERT INTO AppointmentStatusList VALUES (1,'Pending for Approval')
INSERT INTO AppointmentStatusList VALUES (2,'Approved and Booked')
INSERT INTO AppointmentStatusList VALUES (3,'Cancelled by Patient')
INSERT INTO AppointmentStatusList VALUES (4,'Visited')
INSERT INTO AppointmentStatusList VALUES (5,'Patient failed to attend')


INSERT INTO SpecialitiesListTable VALUES ('SP001','Accupunture')
INSERT INTO SpecialitiesListTable VALUES ('SP002','Allergy Specialist')
INSERT INTO SpecialitiesListTable VALUES ('SP003','Arthritis')
INSERT INTO SpecialitiesListTable VALUES ('SP004','Back Pain Treatment')
INSERT INTO SpecialitiesListTable VALUES ('SP005','Behaviour Therapist')
INSERT INTO SpecialitiesListTable VALUES ('SP006','Chemical Pathologist')
INSERT INTO SpecialitiesListTable VALUES ('SP007','Chest Specialist')
INSERT INTO SpecialitiesListTable VALUES ('SP008','Cardiologist')
INSERT INTO SpecialitiesListTable VALUES ('SP009','Child Psycologist')
INSERT INTO SpecialitiesListTable VALUES ('SP010','Child Psychiatrist')
INSERT INTO SpecialitiesListTable VALUES ('SP011','Clinical Embryologist')
INSERT INTO SpecialitiesListTable VALUES ('SP012','Clinical Nuerologist')
INSERT INTO SpecialitiesListTable VALUES ('SP013','Clincal Nutritionist')
INSERT INTO SpecialitiesListTable VALUES ('SP014','Consultant Dental Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP015','Cosmetic Dermatology')
INSERT INTO SpecialitiesListTable VALUES ('SP016','Cosmetologist')
INSERT INTO SpecialitiesListTable VALUES ('SP017','Counsellor')
INSERT INTO SpecialitiesListTable VALUES ('SP018','Dentist')
INSERT INTO SpecialitiesListTable VALUES ('SP019','Dermatologist')
INSERT INTO SpecialitiesListTable VALUES ('SP020','Diabetologist')
INSERT INTO SpecialitiesListTable VALUES ('SP021','Dietician')
INSERT INTO SpecialitiesListTable VALUES ('SP022','Nuerologist')
INSERT INTO SpecialitiesListTable VALUES ('SP023','Educational Therapist')
INSERT INTO SpecialitiesListTable VALUES ('SP024','Endocrinologist')
INSERT INTO SpecialitiesListTable VALUES ('SP025','ENT Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP026','Gastroenterologist')
INSERT INTO SpecialitiesListTable VALUES ('SP027','General Physician')
INSERT INTO SpecialitiesListTable VALUES ('SP028','General Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP029','Geneticist')
INSERT INTO SpecialitiesListTable VALUES ('SP030','Geriatric Physician')
INSERT INTO SpecialitiesListTable VALUES ('SP031','Gynaecologist')
INSERT INTO SpecialitiesListTable VALUES ('SP032','Haemotologist')
INSERT INTO SpecialitiesListTable VALUES ('SP033','Hypnotherapist')
INSERT INTO SpecialitiesListTable VALUES ('SP034','Hepatologist')
INSERT INTO SpecialitiesListTable VALUES ('SP035','Homeopathy Physician')
INSERT INTO SpecialitiesListTable VALUES ('SP036','Immunologist')
INSERT INTO SpecialitiesListTable VALUES ('SP037','Internal Medicine')
INSERT INTO SpecialitiesListTable VALUES ('SP038','Lifestyle Therapist')
INSERT INTO SpecialitiesListTable VALUES ('SP039','Microbiologist')
INSERT INTO SpecialitiesListTable VALUES ('SP040','Neonatologist')
INSERT INTO SpecialitiesListTable VALUES ('SP041','Neuro Physician')
INSERT INTO SpecialitiesListTable VALUES ('SP042','Neuro Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP043','Neurologist')
INSERT INTO SpecialitiesListTable VALUES ('SP044','Obstetrician')
INSERT INTO SpecialitiesListTable VALUES ('SP045','Occupational Medicine')
INSERT INTO SpecialitiesListTable VALUES ('SP046','Oncologist')
INSERT INTO SpecialitiesListTable VALUES ('SP047','Orthodontist')
INSERT INTO SpecialitiesListTable VALUES ('SP048','Orthopaedic Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP049','Paediatrician')
INSERT INTO SpecialitiesListTable VALUES ('SP050','Parasitologist')
INSERT INTO SpecialitiesListTable VALUES ('SP051','Physiotherapist')
INSERT INTO SpecialitiesListTable VALUES ('SP052','Plastic Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP053','Prosthodontist')
INSERT INTO SpecialitiesListTable VALUES ('SP054','Psychiatrist')
INSERT INTO SpecialitiesListTable VALUES ('SP055','Psychologist')
INSERT INTO SpecialitiesListTable VALUES ('SP056','Radiologist')
INSERT INTO SpecialitiesListTable VALUES ('SP057','Respiratory Physician')
INSERT INTO SpecialitiesListTable VALUES ('SP058','Speech And Language Therapist')
INSERT INTO SpecialitiesListTable VALUES ('SP059','Sports Psychology')
INSERT INTO SpecialitiesListTable VALUES ('SP060','Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP061','Transplant Surgeon')
INSERT INTO SpecialitiesListTable VALUES ('SP062','Urologist')
INSERT INTO SpecialitiesListTable VALUES ('SP063','Vaccinologist')
INSERT INTO SpecialitiesListTable VALUES ('SP064','Venerologist')


INSERT INTO QualificationsListTable VALUES ('SP001','MBBS')
INSERT INTO QualificationsListTable VALUES ('SP002','MBChB')
INSERT INTO QualificationsListTable VALUES ('SP003','M.Med')
INSERT INTO QualificationsListTable VALUES ('SP004','MD')
INSERT INTO QualificationsListTable VALUES ('SP005','BMedSc')
INSERT INTO QualificationsListTable VALUES ('SP006','B.DSc')
INSERT INTO QualificationsListTable VALUES ('SP007','BPharm')
INSERT INTO QualificationsListTable VALUES ('SP008','DDS')
INSERT INTO QualificationsListTable VALUES ('SP009','DA')
INSERT INTO QualificationsListTable VALUES ('SP010','ChB')
INSERT INTO QualificationsListTable VALUES ('SP011','GP')
INSERT INTO QualificationsListTable VALUES ('SP012','MCh')
INSERT INTO QualificationsListTable VALUES ('SP013','M.MedSc')
INSERT INTO QualificationsListTable VALUES ('SP014','MS')



INSERT INTO ConsultantLoginTable VALUES ('AF0072', '14581', 'DR0072')
INSERT INTO ConsultantLoginTable VALUES ('EP0055', '12345', 'DR0055')
INSERT INTO ConsultantLoginTable VALUES ('DA0001', '11111', 'DR0001')
INSERT INTO ConsultantLoginTable VALUES ('GC0025', '54321', 'DR0025')