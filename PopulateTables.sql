USE bookish;
GO

INSERT INTO [User] (UserID, Username, PasswordHash)
VALUES
(1, 'alice', 'hash_alice'),
(2, 'bob', 'hash_bob'),
(3, 'charlie', 'hash_charlie');

INSERT INTO Author (AuthorID, AuthorName)
VALUES
(1, 'J.K. Rowling'),
(2, 'George Orwell'),
(3, 'J.R.R. Tolkien');

INSERT INTO BookVersion (BookVersionID, Title, ISBN, NumberCopies)
VALUES
(1, 'Harry Potter and the Philosopher''s Stone', '9780747532743', 5),
(2, '1984', '9780451524935', 3),
(3, 'The Hobbit', '9780547928227', 4);

INSERT INTO AuthorBookVersion (BookVersionID, AuthorID)
VALUES
(1, 1),
(2, 2),
(3, 3);

-- Borrowed Books
INSERT INTO BorrowedBook (BookVersionID, LenderID, LendedDate, DueDate, ReturnDate)
VALUES
(1, 1, '2025-11-01', '2025-12-01', NULL),
(2, 2, '2025-11-10', '2025-12-10', '2025-11-28');