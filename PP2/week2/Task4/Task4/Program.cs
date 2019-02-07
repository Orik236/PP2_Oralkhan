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
			string folderName = @"C:\Users\Оралхан\Desktop";
			string path = Path.Combine(folderName, "test2");
			Directory.CreateDirectory(path);
			string source = @"C:\Users\Оралхан\Desktop\test";
			string[] files = Directory.GetFiles(source);
			foreach(string file in files)
			{
				File.Copy(file, Path.Combine(path, Path.GetFileName(file)));
				File.Delete(file);
			}
		}
	}
}
