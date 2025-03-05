	CREATE TABLE dbo.Certificate 
	(
		Id INT PRIMARY KEY IDENTITY(1,1),
		Name nvarchar(200) NOT NULL,
		Abbreviation nvarchar(25) NULL,
		CeusRequired decimal(18,2) NOT NULL,
		CeuDueDate date NOT NULL,
		CertificateTrainingMonths int NOT NULL,
		InProcess bit NOT NULL,
		CONSTRAINT CHK_Certificate_CeusRequired CHECK (CeusRequired >= 0 AND CeusRequired <= 200));