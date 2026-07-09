USE bookish
GO

CREATE TABLE [User] (
    UserID BIGINT PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL
);

CREATE TABLE Author (
    AuthorID BIGINT PRIMARY KEY,
    AuthorName NVARCHAR(255) NOT NULL
);

CREATE TABLE BookVersion (
    BookVersionID BIGINT PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    ISBN NVARCHAR(20),
    NumberCopies BIGINT NOT NULL
);

CREATE TABLE BorrowedBook (
    BookVersionID BIGINT PRIMARY KEY,
    LenderID BIGINT NOT NULL,
	LendedDate DATE NOT NULL,
    DueDate DATE NOT NULL,
	ReturnDate DATE NULL,

    CONSTRAINT FK_BorrowedBook_PhysicalBook
        FOREIGN KEY (BookVersionID)
        REFERENCES BookVersion(BookVersionID),

    CONSTRAINT FK_BorrowedBook_User
        FOREIGN KEY (LenderID)
        REFERENCES [User](UserID)
);

CREATE TABLE AuthorBookVersion (
    BookVersionID BIGINT NOT NULL,
    AuthorID BIGINT NOT NULL,

    CONSTRAINT PK_AuthorBookVersion
        PRIMARY KEY (BookVersionID, AuthorID),

    CONSTRAINT FK_AuthorBookVersion_BookVersion
        FOREIGN KEY (BookVersionID)
        REFERENCES BookVersion(BookVersionID),

    CONSTRAINT FK_AuthorBookVersion_Author
        FOREIGN KEY (AuthorID)
        REFERENCES Author(AuthorID)
);