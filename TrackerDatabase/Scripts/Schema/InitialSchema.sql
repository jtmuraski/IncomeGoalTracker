CREATE TABLE dbo.Certificate 
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(200) NOT NULL,
	Abbreviation nvarchar(25) NULL,
	CeusRequired decimal(18,2) NOT NULL,
	CeuDueDate date NOT NULL,
	CertificateTrainingMonths int NOT NULL,
	InProcess bit NOT NULL,
	CONSTRAINT CHK_Certificate_CeusRequired CHECK (CeusRequired >= 0 AND CeusRequired <= 200)
);

CREATE TABLE [dbo].[TrainingClass]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(150) NOT NULL,
	Provider nvarchar(150) NOT NULL,
	CeusEarned decimal(18,2) NOT NULL,
	DateComplete Date NOT NULL,
	CertificateLocation nvarchar(500) NULL,
	CONSTRAINT CHK_TrainingClass_CeusEarned CHECK (CeusEarned >= 0 AND CeusEarned <= 200)
);


CREATE TABLE [dbo].[ClassCeu]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CertificateId INT FOREIGN KEY REFERENCES Certificate(Id) NOT NULL,
	TrainingClassId INT FOREIGN KEY REFERENCES TrainingClass(Id) NOT NULL,
	CeuHours decimal(18,2) NOT NULL,
	CONSTRAINT CHK_ClassCeu_CeuHours CHECK (CeuHours >= 0 AND CeuHours <= 200)
)