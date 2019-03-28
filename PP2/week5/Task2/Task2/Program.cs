using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task2
{
	public class Mark
	{
		public int point
		{
			get;
			set;
		}
		public string STRmark
		{
			get;
			set;
		}
		public void GetLetter()
		{
			if (point > 95 && point <= 100)
			{
				STRmark = "A";
			}
			else if (point > 90 && point <= 95)
			{
				STRmark = "A-";
			}
			else if(point > 85 && point <= 90)
			{
				STRmark = "B+";
			}
			else if(point > 80 && point <= 85)
			{
				STRmark = "B";
			}
			else if(point > 75 && point <= 80)
			{
				STRmark = "B-";
			}
			else if(point > 70 && point <= 75)
			{
				STRmark = "C+";
			}
			else if(point > 65 && point <= 70)
			{
				STRmark = "C";
			}
			else if(point > 60 && point <= 65)
			{
				STRmark = "C-";
			}
			else if(point > 55 && point <= 60)
			{
				STRmark = "D+";
			}
			else if(point >= 50 && point <= 55)
			{
				STRmark = "D";
			}
			else
			{
				STRmark = "F";
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			F1();
			F2();
		}
		private static void F1()
		{
			List<Mark> marks = new List<Mark>();
			for(int i = 0; i < 5; ++i)
			{
				string s = Console.ReadLine();
				Mark m = new Mark();
				m.point = int.Parse(s);
				m.GetLetter();
				marks.Add(m);
			}
			FileStream fs = new FileStream("marks.txt", FileMode.OpenOrCreate, FileAccess.Write);
			XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
			xs.Serialize(fs, marks);
			fs.Close();
		}
		private static void F2()
		{
			FileStream fs = new FileStream("marks.txt", FileMode.Open, FileAccess.Read);
			XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
			List<Mark> t = (List<Mark>)xs.Deserialize(fs);
			foreach(var x in t)
			{
				Console.WriteLine($"{x.point}  {x.STRmark}");
			}
			fs.Close();
		}
	}
}
