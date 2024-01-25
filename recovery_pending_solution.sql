ALTER DATABASE [GamesCollection] SET EMERGENCY;
GO

ALTER DATABASE [GamesCollection] set single_user
GO

DBCC CHECKDB ([GamesCollection], REPAIR_ALLOW_DATA_LOSS) WITH ALL_ERRORMSGS;
GO 

ALTER DATABASE [GamesCollection] set multi_user
GO

