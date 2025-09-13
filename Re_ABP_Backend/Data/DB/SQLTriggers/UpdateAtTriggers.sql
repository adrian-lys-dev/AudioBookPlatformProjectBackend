-- Genre update trigger
DROP TRIGGER IF EXISTS trg_UpdateGenreUpdatedAt;
GO
CREATE TRIGGER trg_UpdateGenreUpdatedAt
ON dbo.Genre
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE g
    SET UpdatedAt = GETDATE()
    FROM dbo.Genre g
    INNER JOIN inserted i ON g.Id = i.Id;
END;
GO

-- Author update trigger
DROP TRIGGER IF EXISTS trg_UpdateAuthorUpdatedAt;
GO
CREATE TRIGGER trg_UpdateAuthorUpdatedAt
ON dbo.Author
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.Author a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Audiobook update trigger
DROP TRIGGER IF EXISTS trg_UpdateAudioBookUpdatedAt;
GO
CREATE TRIGGER trg_UpdateAudioBookUpdatedAt
ON dbo.AudioBook
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.AudioBook a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Audiofile update trigger
DROP TRIGGER IF EXISTS trg_UpdateBookAudioFileUpdatedAt;
GO
CREATE TRIGGER trg_UpdateBookAudioFileUpdatedAt
ON dbo.BookAudioFile
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.BookAudioFile a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Book language update trigger
DROP TRIGGER IF EXISTS trg_UpdateBookLanguageUpdatedAt;
GO
CREATE TRIGGER trg_UpdateBookLanguageUpdatedAt
ON dbo.BookLanguage
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.BookLanguage a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Book selection update trigger
DROP TRIGGER IF EXISTS trg_UpdateBookSelectionUpdatedAt;
GO
CREATE TRIGGER trg_UpdateBookSelectionUpdatedAt
ON dbo.BookSelection
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.BookSelection a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Book series update trigger
DROP TRIGGER IF EXISTS trg_UpdateBookSeriesUpdatedAt;
GO
CREATE TRIGGER trg_UpdateBookSeriesUpdatedAt
ON dbo.BookSeries
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.BookSeries a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- User library status update trigger
DROP TRIGGER IF EXISTS trg_UpdateLibraryStatusUpdatedAt;
GO
CREATE TRIGGER trg_UpdateLibraryStatusUpdatedAt
ON dbo.LibraryStatus
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.LibraryStatus a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Narrator update trigger
DROP TRIGGER IF EXISTS trg_UpdateNarratorUpdatedAt;
GO
CREATE TRIGGER trg_UpdateNarratorUpdatedAt
ON dbo.Narrator
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.Narrator a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- Review update trigger
DROP TRIGGER IF EXISTS trg_UpdateReviewUpdatedAt;
GO
CREATE TRIGGER trg_UpdateReviewUpdatedAt
ON dbo.Review
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE a
    SET UpdatedAt = GETDATE()
    FROM dbo.Review a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
GO

-- User update trigger
DROP TRIGGER IF EXISTS trg_UpdateUserUpdatedAt;
GO
CREATE TRIGGER trg_UpdateUserUpdatedAt
ON dbo.[User]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE u
    SET UpdatedAt = GETDATE()
    FROM dbo.[User] u
    INNER JOIN inserted i ON u.Id = i.Id;
END;
GO

-- User role update trigger
DROP TRIGGER IF EXISTS trg_UpdateRoleUpdatedAt;
GO
CREATE TRIGGER trg_UpdateRoleUpdatedAt
ON dbo.[Role]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE u
    SET UpdatedAt = GETDATE()
    FROM dbo.[Role] u
    INNER JOIN inserted i ON u.Id = i.Id;
END;
GO
