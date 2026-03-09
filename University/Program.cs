using System.Runtime.Intrinsics.X86;
using University.Data;
using University.Models;

using UniversityContext context = new UniversityContext();

context.Users.Add(new User("Ahmad Ater", "Student", "ahmadater@88ninety.com"));
context.Users.Add(new User("Abdo Fateh", "Student", "abdofateh@88ninety.com"));
context.Users.Add(new User("Wasim Hariri", "Student", "wasimhariri@88ninety.com"));
context.Users.Add(new User("Salim Hijazi", "Teacher", "salimhijazi@88ninety.com"));
context.Users.Add(new User("Feryal Tlemat", "Teacher", "feryaltlemat@88ninety.com"));
context.SaveChanges();

context.Courses.Add(new Course("SQL", 4, null));
context.Courses.Add(new Course("C#", 4, null));
context.Courses.Add(new Course("React", 5, null));
context.SaveChanges();

context.Assignments.Add(new Assignment("Exam1", 0.25, 100, 1));
context.Assignments.Add(new Assignment("Exam2", 0.25, 100, 1));
context.Assignments.Add(new Assignment("Exam3", 0.25, 100, 1));
context.Assignments.Add(new Assignment("Exam4", 0.25, 100, 1));
context.Assignments.Add(new Assignment("Exam1", 0.25, 100, 2));
context.Assignments.Add(new Assignment("Exam2", 0.25, 100, 2));
context.Assignments.Add(new Assignment("Exam3", 0.25, 100, 2));
context.Assignments.Add(new Assignment("Exam4", 0.25, 100, 2));
context.Assignments.Add(new Assignment("Exam1", 0.25, 100, 3));
context.Assignments.Add(new Assignment("Exam2", 0.25, 100, 3));
context.Assignments.Add(new Assignment("Exam3", 0.25, 100, 3));
context.Assignments.Add(new Assignment("Exam4", 0.25, 100, 3));
context.SaveChanges();


context.Comments.Add(new Comment("This is a comment", 1, 1));
context.Comments.Add(new Comment("This is a comment", 1, 2));
context.Comments.Add(new Comment("This is a comment", 1, 3));
context.Comments.Add(new Comment("This is a comment", 1, 4));
context.Comments.Add(new Comment("This is a comment", 1, 5));
context.Comments.Add(new Comment("This is a comment", 1, 6));
context.Comments.Add(new Comment("This is a comment", 4, 1));
context.Comments.Add(new Comment("This is a comment", 4, 2));
context.Comments.Add(new Comment("This is a comment", 4, 3));
context.Comments.Add(new Comment("This is a comment", 2, 1));
context.SaveChanges();

var Assignments = context.Assignments;
var Students = context.Users
    .Where(u => u.Role == "Student");

Random rnd = new Random();

foreach (User s in Students)
{
    foreach (var a in Assignments)
    {
        context.Grades.Add(new Grade(rnd.Next(0, 101), a.Id, s.Id));
    }
}
context.SaveChanges();

var Courses = context.Courses;
foreach (Course c in Courses)
{
    Syllabus S = new Syllabus("Syllabus for " + c.Name + " course.");
    context.Syllabuses.Add(S);
}
context.SaveChanges();
int cnt = 1;
foreach (Course c in Courses)
{
    c.SyllabusId = cnt;
    cnt++;
}
context.SaveChanges();


var courses = from c in context.Courses select c;
Console.WriteLine("Names of all courses");
foreach (Course c in courses)
{
    Console.WriteLine(c.Name);
}


var assignments = from a in context.Assignments
                  where a.CourseId == 1
                  select a;
Console.WriteLine("Assignments for course 1");
foreach (Assignment a in assignments)
{
    Console.WriteLine(a.Title);
}


var students = from u in context.Users
               where u.Role == "Student"
               select u;
Console.WriteLine("Names of all students");
foreach (User s in students)
{
    Console.WriteLine(s.Name);
}


var comments = from c in context.Comments
               where c.AssignmentId == 1
               select c;
Console.WriteLine("comments for Assignment 1");
foreach (Comment c in comments)
{
    Console.WriteLine(c.Id);
    Console.WriteLine(c.Content);
}


var grades_for_student_1 = from g in context.Grades
                           where g.StudentId == 1
                           select g;
Console.WriteLine("Grades for student 1");
foreach (Grade g in grades_for_student_1)
{
    Console.WriteLine("student 1 got " + g.grade + " in assignment " + g.AssignmentId);
}


var assignments_courses = from a in context.Assignments
                          join c in context.Courses
                          on a.CourseId equals c.Id
                          join t in context.Users
                          on c.TeacherId equals t.Id
                          select new
                          {
                              Title = a.Title,
                              CourseName = c.Name,
                              Teacher = t.Name
                          };

foreach (var ac in assignments_courses)
{
    Console.WriteLine($"Assignment: {ac.Title}, Course: {ac.CourseName}, Teacher: {ac.Teacher}");
}


var marks_for_course_1 = from g in context.Grades
                         join a in context.Assignments
                         on g.AssignmentId equals a.Id
                         where a.CourseId == 1
                         group new
                         {
                             value = (double)(g.grade == null ? 0 : g.grade) * a.Weight
                         }
                         by g.StudentId;
double total = 0;
cnt = 0;
foreach (var valueGroup in marks_for_course_1)
{
    Console.WriteLine($"Student {valueGroup.Key} got {valueGroup.Sum(v => v.value)} in course 1");
    total += valueGroup.Sum(v => v.value);
    cnt += 1;
}
Console.WriteLine("Course 1 average over all students is " + total / cnt);

char GetGrade(int StudentId, int CourseId)
{
    var marks_for_course = from g in context.Grades
                           join a in context.Assignments
                           on g.AssignmentId equals a.Id
                           where a.CourseId == CourseId && g.StudentId == StudentId
                           select new
                           {
                               value = (double)(g.grade == null ? 0 : g.grade) * a.Weight
                           };
    double total = marks_for_course.Sum(v => v.value);
    if (total >= 90) return 'A';
    else if (total >= 80) return 'B';
    else if (total >= 70) return 'C';
    else if (total >= 60) return 'D';
    else return 'F';
}
Console.WriteLine("mark of student_1 in course_1 is " + GetGrade(1, 1));

double GetGPA(int StudentId)
{
    var marks_for_courses = from g in context.Grades
                            join a in context.Assignments
                            on g.AssignmentId equals a.Id
                            where g.StudentId == StudentId
                            group new
                            {
                                value = (double)(g.grade == null ? 0 : g.grade) * a.Weight
                            }
                            by a.CourseId;
    double totalPoints = 0;
    int cnt = 0;
    foreach (var courseGroup in marks_for_courses)
    {
        double total = courseGroup.Sum(v => v.value);
        totalPoints += total;
        cnt += 1;
    }
    return totalPoints / cnt;
}
Console.WriteLine("GPA of student_1 is " + GetGPA(1));

// change the first student to be a teacher
var intern = context.Users
    .Where(u => u.Role == "Student")
    .FirstOrDefault();
if (intern is User)
{
    intern.Role = "Teacher";
}
context.SaveChanges();

// delete a comment with id 1
var comment = context.Comments.FirstOrDefault(c => c.Id == 1);
if (comment != null)
{
    context.Comments.Remove(comment);
    context.SaveChanges();
}
