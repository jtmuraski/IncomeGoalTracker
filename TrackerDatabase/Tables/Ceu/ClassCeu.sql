CREATE TABLE [dbo].[ClassCeu]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CertificateId INT FOREIGN KEY REFERENCES Certificate(Id) NOT NULL,
	TrainingClassId INT FOREIGN KEY REFERENCES TrainingClass(Id) NOT NULL,
	CeuHours decimal(18,2) NOT NULL,
	CONSTRAINT CHK_ClassCeu_CeuHours CHECK (CeuHours >= 0 AND CeuHours <= 200)
)
