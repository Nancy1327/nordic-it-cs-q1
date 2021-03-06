﻿IF NOT EXISTS(SELECT * FROM sys.objects WHERE [name] = 'Contact' AND [type] = 'U')
    CREATE TABLE [Contact] (
        [Id] UNIQUEIDENTIFIER NOT NULL,
        [Login] VARCHAR(64) NOT NULL,

        CONSTRAINT PK_Contact 
            PRIMARY KEY ([Id]),

        CONSTRAINT UQ_Contact_Login
            UNIQUE ([Login])
    );