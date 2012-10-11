CREATE TABLE dbo.Tmp_Setting
	(
	Id int NOT NULL IDENTITY (1, 1),
	AppVersion int NULL,
	AdminUsername nvarchar(50) NULL,
	AdminPassword nvarchar(50) NULL,
	DateCreated datetime NULL,
	DateModified datetime NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Tmp_Setting SET (LOCK_ESCALATION = TABLE)

SET IDENTITY_INSERT dbo.Tmp_Setting ON

IF EXISTS(SELECT * FROM dbo.Setting)
	 EXEC('INSERT INTO dbo.Tmp_Setting (Id, AppVersion, DateCreated, DateModified)
		SELECT Id, AppVersion, DateCreated, DateModified FROM dbo.Setting WITH (HOLDLOCK TABLOCKX)')

SET IDENTITY_INSERT dbo.Tmp_Setting OFF

DROP TABLE dbo.Setting

EXECUTE sp_rename N'dbo.Tmp_Setting', N'Setting', 'OBJECT' 

ALTER TABLE dbo.Setting ADD CONSTRAINT
	PK__Setting__3214EC0707020F21 PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

