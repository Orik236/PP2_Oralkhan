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
		public int year = 1;

		public Student (string name, string id) //Create constructur with two parametrs
		{
			this.name = name;
			this.id = id;
		}

		public void PrintInfo() //Print all information about student
		{
			Console.WriteLine($"Name: {name} ID: {id} Year: {year}");
			year++;
			Console.WriteLine($"Name: {name} ID: {id} Year: {year}");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Student s = new Student("Oralkhan", "18BD110937");
			s.PrintInfo();
		}
	}
}
