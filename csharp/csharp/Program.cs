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
			var studentRepo = new StudentRepo();

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

	public class StudentRepo
	{
		private List<Student> _students = new List<Student>()
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

		public List<Student> GetStudents()
		{
			return _students;
			//throw new NotImplementedException();
		}

		public Student GetStudentByName(string name)
		{
			return _students.FirstOrDefault(x => x.Name == name);
			//throw new NotImplementedException();
		}

		public List<Student> GetStudentWhoIsBornOnFirst()
		{
			return _students.Where(x => x.Birthday.Day == 1).ToList();
			//throw new NotImplementedException();
		}

		public bool IsExistMaleStudent()
		{
			return _students.Any(x => x.Gender == Gender.Male);
			// throw new NotImplementedException();
		}

		public double GetTuitionSum()
		{
			IEnumerable<double> tuition = _students.Select(x => x.Tuition);
			return tuition.Aggregate(0.0, (s, x) => s += x);
			//throw new NotImplementedException();
		}

		public int GetAverageGrade()
		{
			IEnumerable<int> grade = _students.Select(x => x.Grade);
			return grade.Aggregate(0, (s, x) => s += x) / grade.Count();
			//throw new NotImplementedException();
		}
	}

	public class Student
	{
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public Gender Gender { get; set; }
		public double Tuition { get; set; }
		public int Grade { get; set; }
	}

	public enum Gender
	{
		Male,
		Female,
		Others
	}
}