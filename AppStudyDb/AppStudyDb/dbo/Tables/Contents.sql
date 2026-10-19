CREATE TABLE [dbo].[Contents]
(
    [Id]           UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Title]        VARCHAR (200)    NOT NULL,
    [Category]     VARCHAR (100)    NULL,
    [OriginalText] VARCHAR (MAX)    NOT NULL,
    [Notes]        VARCHAR (500)    NULL,
    [CreatedAt]    DATETIME2 (7)   NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT [PK_Contents] PRIMARY KEY CLUSTERED ([Id] ASC)
);
