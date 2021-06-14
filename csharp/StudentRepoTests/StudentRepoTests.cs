using System;
using System.Collections.Generic;
using NUnit.Framework;
using csharp;
using Newtonsoft.Json;

namespace StudentRepoTests
{
    public class Tests
    {
        private StudentRepo _studentRepo;
        private StudentList _studentList;

        [SetUp]
        public void Setup()
        {
            _studentList = new StudentList();
            _studentRepo = new StudentRepo(_studentList);
        }

        [Test]
        public void GetStudentsTest()
        {

            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.GetStudents();

            var expect = new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            };

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetStudentsEmptyTest()
        {
            _studentList.Setup(new List<Student>() { });
            var actual = _studentRepo.GetStudents();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void GetStudentsNullTest()
        {
            _studentList.Setup(null);
            var actual = _studentRepo.GetStudents();

            Assert.IsNull(actual);
        }

        [Test]
        public void GetStudentByNameTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Apple",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.GetStudentByName("Apple");

            var expect = new Student
            {
                Name = "Apple",
                Birthday = new DateTime(2020, 1, 1),
                Gender = Gender.Female,
                Tuition = 7000,
                Grade = 70
            };

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetNoStudentByNameTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Alice",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.GetStudentByName("Ben");

            Assert.IsNull(actual);
        }

        [Test]
        public void GetStudentWhoIsBornOnFirstTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.GetStudentWhoIsBornOnFirst();

            var expect = new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                }
            };

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetStudentNoOneIsBornOnFirstTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 3),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 5),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 2),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.GetStudentWhoIsBornOnFirst();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void IsExistMaleStudentTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.IsExistMaleStudent();

            Assert.IsTrue(actual);
        } 

        [Test]
        public void IsNotExistMaleStudentTest()
        {
            _studentList.Setup(new List<Student>()
            {
                new Student
                {
                    Name = "Alice",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 7000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Female,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            });
            var actual = _studentRepo.IsExistMaleStudent();

            Assert.IsFalse(actual);
        } 

        [Test]
        public void GetTuitionSumTest()
        {
            var data = new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 1000,
                    Grade = 70
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            };

            _studentList.Setup(data);
            var actual = _studentRepo.GetTuitionSum();
            var expect = 0d;

            foreach (Student student in data)
            {
                expect += student.Tuition;
            }

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetTuitionSumEmptyTest()
        {
            _studentList.Setup(new List<Student>());
            var actual = _studentRepo.GetTuitionSum();
            var expect = 0d;

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetTuitionSumNullTest() 
        {
            _studentList.Setup(null);

            Assert.Throws<ArgumentNullException>(() => _studentRepo.GetTuitionSum());
        }

        [Test]
        public void GetAverageGradeTest()
        {
            var data = new List<Student>()
            {
                new Student
                {
                    Name = "Becky",
                    Birthday = new DateTime(2020, 1, 1),
                    Gender = Gender.Female,
                    Tuition = 1000,
                    Grade = 80
                },
                new Student
                {
                    Name = "Bob",
                    Birthday = new DateTime(2020, 2, 1),
                    Gender = Gender.Male,
                    Tuition = 5000,
                    Grade = 40
                },
                new Student
                {
                    Name = "Charlie",
                    Birthday = new DateTime(2020, 3, 3),
                    Gender = Gender.Others,
                    Tuition = 10000,
                    Grade = 60
                }
            };

            _studentList.Setup(data);
            var actual = _studentRepo.GetAverageGrade();
            var expect = 0;

            foreach (Student student in data)
            {
                expect += student.Grade;
            }
            expect = expect / data.Count;

            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void GetAverageGradeNullTest()
        {
            _studentList.Setup(new List<Student>(){});

            Assert.Throws<DivideByZeroException>(() => _studentRepo.GetAverageGrade());
        }

    }

}
