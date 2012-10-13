CREATE TABLE [dbo].[Statuswechsel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KandidatId] [int] NULL,
	[Status] [int] NULL,
	[Zeitpunkt] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[DateCreated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]