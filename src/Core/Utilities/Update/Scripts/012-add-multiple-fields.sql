CREATE TABLE dbo.Tmp_Kandidat
	(
	Id int NOT NULL IDENTITY (1, 1),
	Praktikumsjahr int NULL,
	Studienjahr int NULL,
	Geschlecht int NULL,
	Familienname nvarchar(255) NULL,
	FamiliennameKY nvarchar(255) NULL,
	Vorname nvarchar(255) NULL,
	VornameKY nvarchar(255) NULL,
	Vatersname nvarchar(255) NULL,
	VatersnameKY nvarchar(255) NULL,
	EmailAdresse nvarchar(255) NULL,
	Passwort nvarchar(255) NULL,
	Mobilnummer nvarchar(255) NULL,
	Notfallkontakt nvarchar(MAX) NULL,
	Geburtsdatum datetime NULL,
	NummerInlandspass nvarchar(255) NULL,
	NummerReisepass nvarchar(255) NULL,
	Hochschule int NULL,
	Fakultät nvarchar(255) NULL,
	Studienfach int NULL,
	Spezialisierung nvarchar(255) NULL,
	VerkürzterStudiengang bit NULL,
	AngestrebterAbschluss int NULL,
	Deutschkentnisse bit NULL,
	DeutschkentnisseDurchSchule bit NULL,
	DeutschkentnisseDurchUni bit NULL,
	DeutschkentnisseDurchSonstige bit NULL,
	FruehererAufenthalt bit NULL,
	FruehererAufenthaltProgramm nvarchar(255) NULL,
	Kommentar nvarchar(MAX) NULL,
	KommentarApollo nvarchar(MAX) NULL,
	Status int NULL,
	ErfahrungenLandwirtschaft nvarchar(MAX) NULL,
	PraktikumDeutschland nvarchar(MAX) NULL,
	FuehrerscheinPkw bit NULL,
	FuehrerscheinTraktor bit NULL,
	FuehrerscheinMaehdrescher bit NULL,
	FuehrerscheinSonstige bit NULL,
	WarumTeilnehmen nvarchar(MAX) NULL,
	BetriebsTypMilchviehhaltung bit NULL,
	BetriebsTypSchweinemast bit NULL,
	BetriebsTypAckerbau bit NULL,
	BetriebsTypGemüsebauObstbau bit NULL,
	BetriebsTypWeinbau bit NULL,
	BetriebsTypImkerei bit NULL,
	BetriebsTypAndere nvarchar(255) NULL,
	KoerperlichEinsatzfaehig bit NULL,
	Raucher bit NULL,
	KoerperlicheEinschraenkungen nvarchar(MAX) NULL,
	IchEsseNicht nvarchar(255) NULL,
	Groesse nvarchar(255) NULL,
	Schuhgroesse nvarchar(255) NULL,
	Konfektionsgroesse nvarchar(255) NULL,
	DateModified datetime NULL,
	DateCreated datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]

ALTER TABLE dbo.Tmp_Kandidat SET (LOCK_ESCALATION = TABLE)

SET IDENTITY_INSERT dbo.Tmp_Kandidat ON

IF EXISTS(SELECT * FROM dbo.Kandidat)
	 EXEC('INSERT INTO dbo.Tmp_Kandidat (Id, Praktikumsjahr, Studienjahr, Geschlecht, Familienname, FamiliennameKY, Vorname, VornameKY, Vatersname, VatersnameKY, EmailAdresse, Passwort, Mobilnummer, Notfallkontakt, Geburtsdatum, NummerInlandspass, NummerReisepass, Hochschule, Fakultät, Studienfach, Spezialisierung, VerkürzterStudiengang, AngestrebterAbschluss, Deutschkentnisse, DeutschkentnisseDurchSchule, DeutschkentnisseDurchUni, DeutschkentnisseDurchSonstige, FruehererAufenthalt, FruehererAufenthaltProgramm, Kommentar, KommentarApollo, Status, ErfahrungenLandwirtschaft, PraktikumDeutschland, FuehrerscheinPkw, FuehrerscheinTraktor, FuehrerscheinMaehdrescher, FuehrerscheinSonstige, WarumTeilnehmen, BetriebsTypMilchviehhaltung, BetriebsTypSchweinemast, BetriebsTypAckerbau, BetriebsTypGemüsebauObstbau, BetriebsTypWeinbau, BetriebsTypImkerei, BetriebsTypAndere, KoerperlichEinsatzfaehig, Raucher, KoerperlicheEinschraenkungen, IchEsseNicht, Groesse, DateModified, DateCreated)
		SELECT Id, Praktikumsjahr, Studienjahr, Geschlecht, Familienname, FamiliennameKY, Vorname, VornameKY, Vatersname, VatersnameKY, EmailAdresse, Passwort, Mobilnummer, Notfallkontakt, Geburtsdatum, NummerInlandspass, NummerReisepass, Hochschule, Fakultät, Studienfach, Spezialisierung, VerkürzterStudiengang, AngestrebterAbschluss, Deutschkentnisse, DeutschkentnisseDurchSchule, DeutschkentnisseDurchUni, DeutschkentnisseDurchSonstige, FruehererAufenthalt, FruehererAufenthaltProgramm, Kommentar, KommentarApollo, Status, ErfahrungenLandwirtschaft, PraktikumDeutschland, FuehrerscheinPkw, FuehrerscheinTraktor, FuehrerscheinMaehdrescher, FuehrerscheinSonstige, WarumTeilnehmen, BetriebsTypMilchviehhaltung, BetriebsTypSchweinemast, BetriebsTypAckerbau, BetriebsTypGemüsebauObstbau, BetriebsTypWeinbau, BetriebsTypImkerei, BetriebsTypAndere, KoerperlichEinsatzfaehig, Raucher, KoerperlicheEinschraenkungen, IchEsseNicht, FuerArbeitskleidung, DateModified, DateCreated FROM dbo.Kandidat WITH (HOLDLOCK TABLOCKX)')

SET IDENTITY_INSERT dbo.Tmp_Kandidat OFF

DROP TABLE dbo.Kandidat

EXECUTE sp_rename N'dbo.Tmp_Kandidat', N'Kandidat', 'OBJECT' 

ALTER TABLE dbo.Kandidat ADD CONSTRAINT
	PK__Kandidat__3214EC077F60ED59 PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]