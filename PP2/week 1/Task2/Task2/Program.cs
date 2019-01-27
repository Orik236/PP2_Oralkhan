using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Student
	{
		public string name;
		public string id;
		public string year;

		public Student ()
		{
			name = Console.ReadLine();
			id = Console.ReadLine();
			year = Console.ReadLine();
		}

		public void PrintInfo()
		{
			Console.Write("Student: ");
			Console.WriteLine(name);
			Console.Write("Student`s id number: ");
			Console.WriteLine(id);
			Console.Write("Student`s year of study: ");
			Console.WriteLine(year);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Student s = new Student();
			s.PrintInfo();
		}
	}
}
