using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var studentRepo = new StudentRepo(new StudentList());

            var allStudents = studentRepo.GetStudents();
			PrintStudentNames(allStudents);

			var bobDetail = studentRepo.GetStudentByName("Bob");
			//Console.WriteLine(PrintProperties(bobDetail));
			Console.WriteLine(bobDetail.Name + "\nBirthday : " + bobDetail.Birthday.ToShortDateString() + "\nGender : " + bobDetail.Gender + "\nTuition : " + bobDetail.Tuition + "\nGrade : " + bobDetail.Grade);

			var bornOnFirst = studentRepo.GetStudentWhoIsBornOnFirst();
			PrintStudentNames(bornOnFirst);

			var isExistMaleStudent = studentRepo.IsExistMaleStudent();
			Console.WriteLine("IsExistMaleStudent : " + isExistMaleStudent);

			var tuitionSum = studentRepo.GetTuitionSum();
			Console.WriteLine("Tuition Sum : " + tuitionSum);

			var averageGrade = studentRepo.GetAverageGrade();
			Console.WriteLine("Average Grade : " + averageGrade);

			Console.ReadKey();
		}

		public static void PrintStudentNames(List<Student> students)
		{
			Console.WriteLine("---Start---");
			foreach (var student in students)
			{
				Console.WriteLine(student.Name);
			}
			Console.WriteLine("---End---");
		}
	}

    public class StudentList
    {
        public List<Student> _students = new List<Student>()
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
        };

        public void Setup(List<Student> students)
        {
            _students = students;
        }
    }

    public class StudentRepo
    {
        private readonly StudentList _studentList;

        public StudentRepo(StudentList studentList)
        {
            _studentList = studentList;
        }

        public List<Student> GetStudents()
		{
			return _studentList._students;
			//throw new NotImplementedException();
		}

		public Student GetStudentByName(string name)
		{
			return _studentList._students.FirstOrDefault(x => x.Name == name);
			//throw new NotImplementedException();
		}

		public List<Student> GetStudentWhoIsBornOnFirst()
		{
			return _studentList._students.Where(x => x.Birthday.Day == 1).ToList();
			//throw new NotImplementedException();
		}

		public bool IsExistMaleStudent()
		{
			return _studentList._students.Any(x => x.Gender == Gender.Male);
			// throw new NotImplementedException();
		}

		public double GetTuitionSum()
		{
			IEnumerable<double> tuition = _studentList._students.Select(x => x.Tuition);
			return tuition.Aggregate(0.0, (s, x) => s += x);
			//throw new NotImplementedException();
		}

		public int GetAverageGrade()
		{
			IEnumerable<int> grade = _studentList._students.Select(x => x.Grade);
			return grade.Aggregate(0, (s, x) => s += x) / grade.Count();
			//throw new NotImplementedException();
		}
	}

	public class Student : IEquatable<Student>
	{
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public Gender Gender { get; set; }
		public double Tuition { get; set; }
		public int Grade { get; set; }

        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Birthday.Equals(other.Birthday) && Gender == other.Gender && Tuition.Equals(other.Tuition) && Grade == other.Grade;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Birthday.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Gender;
                hashCode = (hashCode * 397) ^ Tuition.GetHashCode();
                hashCode = (hashCode * 397) ^ Grade;
                return hashCode;
            }
        }
    }

	public enum Gender
	{
		Male,
		Female,
		Others
	}
}