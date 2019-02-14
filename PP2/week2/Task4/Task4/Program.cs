using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			string path= @"C:\Users\Оралхан\Desktop\test2"; //Write path where we create text file
			Directory.CreateDirectory(path); //Create file
			string source = @"C:\Users\Оралхан\Desktop\test"; //Write way to file where we take all files
			string[] files = Directory.GetFiles(source); //Create string array
			foreach(string file in files)//Create cycle
			{
				File.Copy(file, Path.Combine(path, Path.GetFileName(file)));//Copy all files in test to test2
				File.Delete(file);//Delete file test
			}
		}
	}
}
