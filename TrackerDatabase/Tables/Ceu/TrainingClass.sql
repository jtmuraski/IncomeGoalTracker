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
