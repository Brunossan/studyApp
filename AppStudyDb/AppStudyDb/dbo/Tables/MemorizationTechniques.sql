CREATE TABLE [dbo].[MemorizationTechniques]
(
    [Id]               UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [ContentId]        UNIQUEIDENTIFIER NOT NULL,
    [TechniqueType]    VARCHAR (50)     NOT NULL,
    [Title]            VARCHAR (200)    NOT NULL,
    [Description]      VARCHAR (MAX)    NULL,
    [GeneratedContent] VARCHAR (MAX)    NOT NULL,
    [GenerationOrigin] VARCHAR (30)     NOT NULL,
    [IsFavorite]       BIT              NOT NULL DEFAULT 0,
    [CreatedAt]        DATETIME2 (7)   NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedAt]        DATETIME2 (7)   NULL,
    CONSTRAINT [PK_MemorizationTechniques] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Techniques_Content] FOREIGN KEY ([ContentId])
        REFERENCES [dbo].[Contents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [CK_TechniqueType] CHECK ([TechniqueType] IN (
        'ACRONYM', 'MIND_PALACE', 'ASSOCIATIVE_STORY', 'SPACED_REPETITION', 'MIND_MAP', 'OTHER'
    )),
    CONSTRAINT [CK_GenerationOrigin] CHECK ([GenerationOrigin] IN ('MANUAL', 'IA_ASSISTED'))
);
