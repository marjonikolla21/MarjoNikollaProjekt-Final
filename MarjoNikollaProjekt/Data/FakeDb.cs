using MarjoNikollaProjekt.API.Data.Models;
using MarjoNikollaProjekt.Data.Models;
using System;
using System.Collections.Generic;

namespace CompaniesApp.API.Data
{
    public static class FakeDb
    {
        // Lista e studentëve në databazë
        public static List<Student> StudentsDb = new List<Student>()
        {
            // Krijohen objekte të studentëve me të dhënat e tyre
            new Student()
            {
                Id = 1,
                StName = "Student 01",
                LsName = "LN01",
                DOB = DateTime.UtcNow,
            },
            new Student()
            {
                Id = 2,
                StName = "Student 02",
                LsName = "LN02",
                DOB = DateTime.UtcNow,
            },
            new Student()
            {
                Id = 3,
                StName = "Student 03",
                LsName = "LN03",
                DOB = DateTime.UtcNow,
            },
            new Student()
            {
                Id = 4,
                StName = "Student 04",
                LsName = "LN04",
                DOB = DateTime.UtcNow,
            }
        };

        // Metoda që kthen të gjithë studentët nga databaza
        public static List<Student> GetAllStudents()
        {
            return StudentsDb;
        }

        // Lista e librave në databazë
        public static List<Book> BooksDb = new List<Book>()
        {
            // Krijohen objekte të librave me të dhënat e tyre
            new Book()
            {
                Id = 1,
                Title = "Book 01",
                Author = "Author01",
                Year = 2020,
            },
            new Book()
            {
                Id = 2,
                Title = "Book 02",
                Author = "Author02",
                Year = 2018,
            },
            new Book()
            {
                Id = 3,
                Title = "Book 03",
                Author = "Author03",
                Year = 2022,
            },
            new Book()
            {
                Id = 4,
                Title = "Book 04",
                Author = "Author04",
                Year = 2015,
            }
        };

        // Metoda që kthen të gjithë librat nga databaza
        public static List<Book> GetAllBooks()
        {
            return BooksDb;
        }

        // Lista e shkollave në databazë, secila me librën e saj
        public static List<School> SchoolsDb = new List<School>()
        {
            // Krijohen objekte të shkollave me të dhënat e tyre, përfshirë librat
            new School()
            {
                Id = 1,
                SchoolName = "School A",
                Books = new List<Book>
                {
                    new Book() { Id = 1, Title = "Book 01", Author = "Author01", Year = 2020 },
                    new Book() { Id = 2, Title = "Book 02", Author = "Author02", Year = 2018 }
                }
            },
            new School()
            {
                Id = 2,
                SchoolName = "School B",
                Books = new List<Book>
                {
                    new Book() { Id = 3, Title = "Book 03", Author = "Author03", Year = 2022 }
                }
            },
            new School()
            {
                Id = 3,
                SchoolName = "School C",
                Books = new List<Book>
                {
                    new Book() { Id = 4, Title = "Book 04", Author = "Author04", Year = 2015 }
                }
            }
        };

        // Metoda që kthen të gjitha shkollat nga databaza
        public static List<School> GetAllSchools()
        {
            return SchoolsDb;
        }
    }
}
