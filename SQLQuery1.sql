create table Users (UserId INT identity(1, 1) PRIMARY KEY, UserName VARCHAR(64) NOT NULL,
FirstName VARCHAR(64) NOT NULL, LastName VARCHAR(64) NOT NULL,
EmailAddress VARCHAR(128) UNIQUE NOT NULL, PhoneNumber VARCHAR(16) NOT NULL,
Role VARCHAR(32) NOT NULL);

create table Syllabus (SyllabusId INT PRIMARY KEY, Description TEXT NULL);

create table Courses (CourseId INT identity(1, 1) PRIMARY KEY, CourseName VARCHAR(100) NOT NULL,
TeacherId INT Foreign Key references Users(UserId) NULL, StartDate DateTime NOT NULL, EndDate DateTime NOT NULL,
SyllabusId INT Foreign Key references Syllabus(SyllabusId) NULL);

create table Assignments (AssignmentId INT identity(1, 1) PRIMARY KEY, CourseId INT Foreign Key
references Courses(CourseId) NOT NULL, AssignmentTitle VARCHAR(128) NOT NULL, Description TEXT NULL,
Weight float NOT NULL, MaxGrade INT NOT NULL, DueDate DateTime NOT NULL);

create table Comments(CommentId INT identity(1, 1) PRIMARY KEY, AssignmentId INT Foreign Key
references Assignments(AssignmentId)NOT NULL, CreatedByUserId INT Foreign Key references Users(UserId)
not null, CreatedDate TIME NOT NULL, CommentContent TEXT NULL);

create table Grades (GradeId INT identity(1, 1) PRIMARY KEY, AssignmentId INT Foreign Key references
Assignments(AssignmentId) NOT NULL, StudentId INT Foreign Key references Users(UserID) NOT NULL, Grade INT NULL);

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('aater'
           ,'Ahmad'
           ,'Ater'
           ,'ahmadater@88ninety.com'
           ,'+963946946565'
           ,'Student');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('afateh'
           ,'Abod'
           ,'Fateh'
           ,'abodfateh@88ninety.com'
           ,'+963958361088'
           ,'Student');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('iabuwardeh'
           ,'Ihab'
           ,'Abuwardeh'
           ,'ihababuwardeh@88ninety.com'
           ,'+905355807082'
           ,'Student');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('malrimi'
           ,'Mohammad'
           ,'Alrimi'
           ,'mohammadalrimi@88ninety.com'
           ,'+905343346036'
           ,'Student');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('walhariri'
           ,'Wasim'
           ,'Alhariri'
           ,'wasimalhariri@88ninety.com'
           ,'+9639994801706'
           ,'Student');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('salhijazi'
           ,'Sami'
           ,'Alhijazi'
           ,'samialhijazi@88ninety.com'
           ,'+12403819639'
           ,'Teacher');

INSERT INTO Users
           (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           ('ftlemat'
           ,'Feryal'
           ,'Tlemat'
           ,'feryaltlemat@88ninety.com'
           ,'+905523381309'
           ,'Teacher');

INSERT INTO Courses
           (CourseName
           ,TeacherId
           ,StartDate
           ,EndDate)
     VALUES
           ('SQL'
           ,1
           ,'2026-03-01'
           ,'2026-05-15');

INSERT INTO Courses
           (CourseName
           ,TeacherId
           ,StartDate
           ,EndDate)
     VALUES
           ('C#'
           ,1
           ,'2026-03-01'
           ,'2026-05-15');

INSERT INTO Courses
           (CourseName
           ,TeacherId
           ,StartDate
           ,EndDate)
     VALUES
           ('Web API'
           ,1
           ,'2026-03-01'
           ,'2026-05-15');

INSERT INTO Courses
           (CourseName
           ,TeacherId
           ,StartDate
           ,EndDate)
     VALUES
           ('Entitiy Framework'
           ,1
           ,'2026-03-01'
           ,'2026-05-15');

INSERT INTO Courses
           (CourseName
           ,TeacherId
           ,StartDate
           ,EndDate)
     VALUES
           ('React'
           ,1
           ,'2026-03-01'
           ,'2026-05-15');

INSERT INTO Assignments
           (CourseId
           ,AssignmentTitle
           ,Description
           ,Weight
           ,MaxGrade
           ,DueDate)
     VALUES
           (1 ,'exam1' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (1 ,'exam2' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (1 ,'exam3' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (1 ,'exam4' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (1 ,'exam5' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (2 ,'exam1' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (2 ,'exam2' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (2 ,'exam3' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (2 ,'exam4' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (2 ,'exam5' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (3 ,'exam1' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (3 ,'exam2' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (3 ,'exam3' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (3 ,'exam4' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (3 ,'exam5' ,'random description' ,0.2 ,100 ,'2026-04-01'),
           (4 ,'exam1' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (4 ,'exam2' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (4 ,'exam3' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (4 ,'exam4' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (4 ,'exam5' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (5 ,'exam1' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (5 ,'exam2' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (5 ,'exam3' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (5 ,'exam4' ,'random description' ,0.2 ,100 ,'2026-03-01'),
           (5 ,'exam5' ,'random description' ,0.2 ,100 ,'2026-03-01');

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (1 ,1
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (1
           ,2
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (1
           ,3
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (1
           ,4
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (1
           ,5
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (2
           ,1
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (2
           ,2
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (2
           ,3
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (2
           ,4
           ,CURRENT_TIMESTAMP);

INSERT INTO Comments
           (AssignmentId
           ,CreatedByUserId
           ,CreatedDate)
     VALUES
           (2
           ,5
           ,CURRENT_TIMESTAMP);

INSERT INTO Grades
           (AssignmentId ,StudentId ,Grade)
     VALUES
           (1 ,1, FLOOR(RAND() * 100) + 1),
           (1, 2, FLOOR(RAND() * 100) + 1),
           (1, 3, FLOOR(RAND() * 100) + 1),
           (1, 4, FLOOR(RAND() * 100) + 1),
           (1, 5, FLOOR(RAND() * 100) + 1),
           (2 ,1, FLOOR(RAND() * 100) + 1),
           (2, 2, FLOOR(RAND() * 100) + 1),
           (2, 3, FLOOR(RAND() * 100) + 1),
           (2, 4, FLOOR(RAND() * 100) + 1),
           (2, 5, FLOOR(RAND() * 100) + 1),
           (3 ,1, FLOOR(RAND() * 100) + 1),
           (3, 2, FLOOR(RAND() * 100) + 1),
           (3, 3, FLOOR(RAND() * 100) + 1),
           (3, 4, FLOOR(RAND() * 100) + 1),
           (3, 5, FLOOR(RAND() * 100) + 1),
           (4 ,1, FLOOR(RAND() * 100) + 1),
           (4, 2, FLOOR(RAND() * 100) + 1),
           (4, 3, FLOOR(RAND() * 100) + 1),
           (4, 4, FLOOR(RAND() * 100) + 1),
           (4, 5, FLOOR(RAND() * 100) + 1),
           (5, 1, FLOOR(RAND() * 100) + 1),
           (5, 2, FLOOR(RAND() * 100) + 1),
           (5, 3, FLOOR(RAND() * 100) + 1),
           (5, 4, FLOOR(RAND() * 100) + 1),
           (5, 5, FLOOR(RAND() * 100) + 1);

INSERT INTO Syllabus
           (SyllabusId)
     VALUES
           (1);

update courses set SyllabusId = 1;

select * from courses;

select * from Assignments where CourseId = 1;

select * from Users where role = 'Student';

update Users set Role = 'Teacher' where UserId = 1;

delete from comments where commentId = 1;

select g.StudentId, g.Grade, g.AssignmentId
from Grades g join Assignments a on g.AssignmentId = a.AssignmentId
join Courses c on a.CourseId = c.CourseId
where c.CourseId = 1;

select c.CourseId, avg(g.grade) as average
from Grades g join Assignments a on g.AssignmentId = a.AssignmentId
join Courses c on a.CourseId = c.CourseId
group by c.CourseId;

select c.CourseName, s.Description
from Courses c join Syllabus s on c.SyllabusId = s.SyllabusId;

select cm.CommentContent
from Comments cm join Assignments a on cm.AssignmentId = a.AssignmentId
join Courses c on a.CourseId = c.CourseId
where c.CourseId = 1;

create procedure add_student
@UserName VARCHAR(64), @FirstName VARCHAR(64), @LastName VARCHAR(64),
@EmailAddress VARCHAR(128), @PhoneNumber VARCHAR(16), @Role VARCHAR(32)
as
begin
    INSERT INTO Users
            (UserName
           ,FirstName
           ,LastName
           ,EmailAddress
           ,PhoneNumber
           ,Role)
     VALUES
           (@UserName
           ,@FirstName
           ,@LastName
           ,@EmailAddress
           ,@PhoneNumber
           ,@Role);
end;
go

create procedure add_assignment
@CourseId INT, @AssignmentTitle VARCHAR(128), @Description TEXT,
@Weight float, @MaxGrade INT, @DueDate DateTime
as
begin
    if(@Weight <= 100)
    INSERT INTO Assignments
           (CourseId
           ,AssignmentTitle
           ,Description
           ,Weight
           ,MaxGrade
           ,DueDate)
     VALUES
           (@CourseId
           ,@AssignmentTitle
           ,@Description
           ,@Weight
           ,@MaxGrade
           ,@DueDate);
    else
        print 'weight should be less than or equal to 100'
end;
go

create function studentgrade
(
    @StudentId INT, @CourseId INT
)
returns float
as
begin
    declare @finalgrade float
    set @finalgrade =
    (
        select SUM(g.grade * a.weight)
        from Grades g join Assignments a on g.AssignmentId = a.AssignmentId
        where g.StudentId = @StudentId and a.CourseId = @CourseId
    );
    return @finalgrade
end;
go

create function studentgpa
(
    @StudentId INT
)
returns float
as
begin
    declare @gpa float
    set @gpa = 
    (
        select avg(finalgrade)
        from
        (
            select sum(g.Grade * a.Weight) as finalgrade
            from Grades g JOIN Assignments a on g.AssignmentId = a.AssignmentId
            where g.StudentId = @StudentId
            group by a.CourseId
        ) as innerquery
    );
    return @gpa
end;
go


